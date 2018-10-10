using RedHawk.Model.InboundModel;
using RedHawk.Service.DataAccessLayer;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Xml.Serialization;

namespace RedHawk.API.Controllers
{
    public class InboundController : ApiController
    {

        //Data Layer Object
        AccountController accountController = new AccountController();
        InboundDAL inboundDAL = new InboundDAL();

        [Route("api/[controller]")]
        [HttpGet]
        [ActionName("GetAllInboundXml")]
        public IEnumerable<InboundModel> GetAllInboundXml()
        {
            string redHawkTokenUsername = Request.Headers.GetValues("redHawkTokenUsername").First();
            string redHawkTokenPassword = Request.Headers.GetValues("redHawkTokenPassword").First();

            var validUser = accountController.ValidateRedHawkToken(redHawkTokenUsername, redHawkTokenPassword);
            if (validUser)
                return inboundDAL.GetInboundXml();
            else
                return null;
        }

        [Route("api/[controller]/Search")]
        public IEnumerable<InboundModel> InboundSearch(InboundSearchModel inboundSearchModel)
        {
            string redHawkTokenUsername = Request.Headers.GetValues("redHawkTokenUsername").First();
            string redHawkTokenPassword = Request.Headers.GetValues("redHawkTokenPassword").First();

            var validUser = accountController.ValidateRedHawkToken(redHawkTokenUsername, redHawkTokenPassword);
            if (validUser)
                return inboundDAL.InboundSearch(inboundSearchModel);
            else
                return null;

        }
        [Route("api/[controller]/Update")]
        public string UpateInboundXML([FromBody]InboundModel inboundModel)
        {
            string redHawkTokenUsername = Request.Headers.GetValues("redHawkTokenUsername").First();
            string redHawkTokenPassword = Request.Headers.GetValues("redHawkTokenPassword").First();

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

        [Route("api/[controller]/Edit")]
        public InboundEditModel GetInboundEditXml(int ceaXmlId)
        {
            string redHawkTokenUsername = Request.Headers.GetValues("redHawkTokenUsername").First();
            string redHawkTokenPassword = Request.Headers.GetValues("redHawkTokenPassword").First();

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
