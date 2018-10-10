using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using RedHawk.Model.AccountModel;
using RedHawk.Model.InboundModel;
using RedHawk.Service.DataAccessLayer;
using System.Collections.Generic;
using System.Web.Http;
using System.Xml.Serialization;

namespace RedHawk.Service.Controllers
{
    public class InboundController : Controller
    {
        //Data Layer Object
        AccountController accountController = new AccountController();
        InboundDAL inboundDAL = new InboundDAL();

        [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Microsoft.AspNetCore.Mvc.ActionName("GetAllInboundXml")]
        public IEnumerable<InboundModel> GetAllInboundXml([FromHeader]string redHawkTokenUsername, [FromHeader]string redHawkTokenPassword)
        {
            var validUser = accountController.ValidateRedHawkToken(redHawkTokenUsername, redHawkTokenPassword);
            if (validUser)
                return inboundDAL.GetInboundXml();
            else
                return null;
        }

        [Microsoft.AspNetCore.Mvc.Route("api/[controller]/Search")]
        public IEnumerable<InboundModel> InboundSearch(InboundSearchModel inboundSearchModel, [FromHeader]string redHawkTokenUsername, [FromHeader]string redHawkTokenPassword)
        {
            var validUser = accountController.ValidateRedHawkToken(redHawkTokenUsername, redHawkTokenPassword);
            if (validUser)
                return inboundDAL.InboundSearch(inboundSearchModel);
            else
                return null;

        }
        [Microsoft.AspNetCore.Mvc.Route("api/[controller]/Update")]
        public string UpateInboundXML([Microsoft.AspNetCore.Mvc.FromBody]InboundModel inboundModel, [FromHeader]string redHawkTokenUsername, [FromHeader]string redHawkTokenPassword)
        {
            string editedInboundXMlString = string.Empty;
            int actionResult = 0;
            var validUser = accountController.ValidateRedHawkToken(redHawkTokenUsername, redHawkTokenPassword);

            if (validUser)
            {
                if (inboundModel != null)
                {
                    var stringwriter = new System.IO.StringWriter();
                    var serializer = new XmlSerializer(typeof(InboundXmlViewModel.Policy_transaction_group));
                    serializer.Serialize(stringwriter, inboundModel.InboundXml);
                    editedInboundXMlString = stringwriter.ToString();
                    actionResult = inboundDAL.UpdateInboundXML(inboundModel.CeaXmlId, editedInboundXMlString, inboundModel.ProcessingStatus);
                }
            }
            if (actionResult == 0)
                return "0";
            else
                return "1";
        }

        [Microsoft.AspNetCore.Mvc.Route("api/[controller]/Edit")]
        public InboundEditModel GetInboundEditXml(int ceaXmlId, [FromHeader]string redHawkTokenUsername, [FromHeader]string redHawkTokenPassword)
        {
            var validUser = accountController.ValidateRedHawkToken(redHawkTokenUsername, redHawkTokenPassword);

            if (validUser)
            {
                return inboundDAL.GetInboundXmlEditData(ceaXmlId);
            }
            else
                return null;
        }
    }
}



