using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;

namespace TVOSERVICE
{
    [ToolboxItem(false)]
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SaleMaterials : WebService
    {
        [SoapDocumentMethod]
        [WebMethod]
        public ResponseMaterials materialMasterRequest(List<Materials> Materials)
        {
            string Acknowledge = "";
            try
            {
                foreach (Materials items in Materials)
                {
                    if (items.Material != "" && items.Alt_Unit != "" && items.Base_Uom != "")
                    {
                        RestClient restClient = new RestClient("https://xxx.xxx.com");
                        RestRequest restRequest = new RestRequest(Method.POST);
                        restRequest.AddHeader("Accept", "application/json");
                        restRequest.AlwaysMultipartFormData = true;
                        restRequest.AddParameter("method", "xxx");
                        restRequest.AddParameter("Material", items.Material);
                        restRequest.AddParameter("Alt_Unit", items.Alt_Unit);
                        restRequest.AddParameter("Base_Uom", items.Base_Uom);
                        restRequest.AddParameter("Numerator", items.Numerator);
                        restRequest.AddParameter("Denominatr", items.Denominatr);
                        restRequest.AddParameter("Gross_Wt", items.Gross_Wt);
                        restRequest.AddParameter("Unit_Of_Wt", items.Unit_Of_Wt);
                        IRestResponse restResponse = restClient.Execute(restRequest);
                        ResponseMaterials responejson = JsonConvert.DeserializeObject<ResponseMaterials>(restResponse.Content);
                        Acknowledge = responejson.Acknowledge;
                    }
                    else
                    {
                        Acknowledge = "";
                    }
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                Acknowledge = "";
            }
            //ServiceSaleMaterials
            //Material, Alt_Unit, Base_Uom, Numerator, Denominatr, Gross_Wt, Unit_Of_Wt
            return new ResponseMaterials()
            {
                Acknowledge = Acknowledge
            };
        }
    }
}
