using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using RedHawk.Model.InboundModel;
using System.Xml.Serialization;
using System.IO;
using System.Collections;

namespace RedHawk.UI.Controllers
{
    public class HomeController : Controller
    {
        static List<InboundModel> staticInboundModelList = new List<InboundModel>();
        List<InboundModel> inboundModelList = new List<InboundModel>();
        List<string> processingStatusList = new List<string>(new string[] { "UnProcessed", "Processed", "Hold" });

        public async Task<ActionResult> Index()
        {
            TempData["IsValidLogin"] = true;
            TempData["Username"] = MvcApplication.Username;
            staticInboundModelList = await GetInboundXMLData();
            var Model = staticInboundModelList;
            return View(Model);
        }


        public async Task<List<InboundModel>> GetInboundXMLData()
        {
            List<InboundModel> iboundModelListTemp = new List<InboundModel>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri("http://localhost:65023/");

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllInboundXml using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/Inbound/");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var InboundInfo = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the inbound list  
                    iboundModelListTemp = JsonConvert.DeserializeObject<List<InboundModel>>(InboundInfo);

                }
                //returning the Inbound list to view  

                return iboundModelListTemp.ToList();
            }
        }

        public async Task<InboundXmlViewModel.Policy_transaction_group> GetInboundXMLToEditData(int ceaXmlId)
        {
            InboundXmlViewModel.Policy_transaction_group policyTransactionGroup = new InboundXmlViewModel.Policy_transaction_group();

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync(string.Format("http://localhost:65023/api//Inbound/Edit?ceaXmlId={0}", ceaXmlId));
                if (response.IsSuccessStatusCode)
                {
                    InboundEditModel inboundEditModel = await response.Content.ReadAsAsync<InboundEditModel>();
                    var serializer = new XmlSerializer(typeof(InboundXmlViewModel.Policy_transaction_group));

                    using (TextReader reader = new StringReader(inboundEditModel.InboundXml))
                    {
                        policyTransactionGroup = (InboundXmlViewModel.Policy_transaction_group)serializer.Deserialize(reader);
                    }

                }

                return policyTransactionGroup;
            }
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial()
        {
            var model = staticInboundModelList;
            return PartialView("GridViewPartial", model.ToList());

        }

        [HttpGet]
        public ActionResult PageControlPartial()
        {
            List<InboundModel> inboundModelListTemp = new List<InboundModel>();
            if (Session["TabData"] != null)
                inboundModelListTemp = ((List<InboundModel>)Session["TabData"]) ?? new List<InboundModel>();
            return PartialView(inboundModelListTemp);
        }

        [HttpPost]
        public async Task<ActionResult> PageControlPartial(string command, int parameter)
        {

            if (Session["TabData"] != null)
                inboundModelList = ((List<InboundModel>)Session["TabData"]) ?? new List<InboundModel>();

            switch (command)
            {
                case "ADD":
                    foreach (InboundModel inboundModel in staticInboundModelList)
                    {
                        if (inboundModel.CeaXmlId == parameter)
                            if (inboundModelList.Count == 0)
                            {
                                inboundModel.InboundXml = await GetInboundXMLToEditData(parameter);
                                inboundModelList.Add(inboundModel);
                            }
                            else
                            {
                                bool hasCeaXmlId = inboundModelList.Any(id => id.CeaXmlId == parameter);
                                if (!hasCeaXmlId)
                                {
                                    inboundModel.InboundXml = await GetInboundXMLToEditData(parameter);
                                    inboundModelList.Add(inboundModel);
                                }

                            }
                    }

                    break;
                case "REMOVE":
                    inboundModelList.RemoveAll(info => info.CeaXmlId == parameter);
                    break;

            }

            Session["TabData"] = inboundModelList;
            return PartialView(inboundModelList);
        }

        public ActionResult TabPartial(InboundModel inboundModel)
        {
            InboundXmlViewModel.Policy_transaction_group policyTransactionGroupModel = new InboundXmlViewModel.Policy_transaction_group();
            policyTransactionGroupModel = inboundModel.InboundXml;
            if (processingStatusList != null)
                ViewBag.Status = processingStatusList;
            else
                ViewBag.Status = string.Empty;

            return PartialView(inboundModel);
        }

        [HttpPost]
        public async Task<ActionResult> UpdatedInboundXMl(InboundModel inboundModel)
        {
            List<InboundModel> inboundModelListTemp = new List<InboundModel>();
            inboundModelListTemp = ((List<InboundModel>)Session["TabData"]) ?? new List<InboundModel>(); ;

            using (var client = new HttpClient())
            {
                //Sending request to find web api REST service resource UpateInboundXML using HttpClient  
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
               // var result = await client.PostAsJsonAsync("http://localhost:65023/api/Inbound/Update", inboundModel);
                var result = await client.PostAsJsonAsync<InboundModel>("http://localhost:65023/api/Inbound/Update", inboundModel);

                //Checking the response is successful or not which is sent using HttpClient  
                if (result.IsSuccessStatusCode)
                {
                    inboundModelListTemp.RemoveAll(info => info.CeaXmlId == inboundModel.CeaXmlId);
                    Session["TabData"] = inboundModelListTemp;
                }

            }
            return RedirectToAction("Index", "Home");
        }

    }
}
