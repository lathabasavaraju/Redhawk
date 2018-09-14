using Microsoft.AspNetCore.Mvc;
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
        InboundDAL inboundDAL = new InboundDAL();
        [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Microsoft.AspNetCore.Mvc.ActionName("GetAllInboundXml")]
        public IEnumerable<InboundModel> GetAllInboundXml()
        {
            return inboundDAL.GetInboundXml();
        }

        [Microsoft.AspNetCore.Mvc.Route("api/[controller]/Update")]
        public string UpateInboundXML([Microsoft.AspNetCore.Mvc.FromBody]InboundModel inboundModel)
        {
            string editedInboundXMlString = string.Empty;
            int actionResult = 0;
            if (inboundModel != null)
            {
                var stringwriter = new System.IO.StringWriter();
                var serializer = new XmlSerializer(typeof(InboundXmlViewModel.Policy_transaction_group));
                serializer.Serialize(stringwriter, inboundModel.InboundXml);
                editedInboundXMlString = stringwriter.ToString();
                actionResult = inboundDAL.UpdateInboundXML(inboundModel.CeaXmlId, editedInboundXMlString, inboundModel.ProcessingStatus);
            }
            if (actionResult == 0)
                return "0";
            else
                return "1";
        }

        [Microsoft.AspNetCore.Mvc.Route("api/[controller]/Edit")]
        public InboundEditModel GetInboundEditXml(int ceaXmlId)
        {
            return inboundDAL.GetInboundXmlEditData(ceaXmlId);
        }
    }
}



