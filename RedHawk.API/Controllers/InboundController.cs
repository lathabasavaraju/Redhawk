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

        public IEnumerable<InboundModel> Get()
        {
            string redHawkTokenUsername = Request.Headers.GetValues("redHawkTokenUsername").First();
            string redHawkTokenPassword = Request.Headers.GetValues("redHawkTokenPassword").First();

            var validUser = accountController.ValidateRedHawkToken(redHawkTokenUsername, redHawkTokenPassword);
            if (validUser)
                return inboundDAL.GetInboundXml();
            else
                return null;
        }

        public IEnumerable<InboundModel> Search(InboundSearchModel inboundSearchModel)
        {
            string redHawkTokenUsername = Request.Headers.GetValues("redHawkTokenUsername").First();
            string redHawkTokenPassword = Request.Headers.GetValues("redHawkTokenPassword").First();

            var validUser = accountController.ValidateRedHawkToken(redHawkTokenUsername, redHawkTokenPassword);
            if (validUser)
                return inboundDAL.InboundSearch(inboundSearchModel);
            else
                return null;

        }

        [HttpPost]
        public string Update([FromBody]InboundModel inboundModel)
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

        public InboundEditModel Edit(int ceaXmlId)
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
