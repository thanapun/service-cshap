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
    public class SalePaymentterm : WebService
    {

        [SoapDocumentMethod]
        [WebMethod]
        public ResponsePaymentTerm paymentTermRequest(List<PaymentTerm> PaymentTerm)
        {
            // ServiceSalePaymentTerm
            // term_of_payment, Term_Of_Payment_Desc, Term_Of_Payment_Condition
            string Acknowledge = "";
            try {
                foreach (PaymentTerm items in PaymentTerm)
                {
                    if (items.Term_Of_Payment != "")
                    {
                        RestClient restClient = new RestClient("https://xxx.xxx.com");
                        RestRequest restRequest = new RestRequest(Method.POST);
                        restRequest.AddHeader("Accept", "application/json");
                        restRequest.AlwaysMultipartFormData = true;
                        restRequest.AddParameter("method", "xxx");
                        restRequest.AddParameter("term_of_payment", items.Term_Of_Payment);
                        restRequest.AddParameter("Term_Of_Payment_Desc", items.Term_Of_Payment_Desc);
                        restRequest.AddParameter("Term_Of_Payment_Condition", items.Term_Of_Payment_Condition);
                        IRestResponse restResponse = restClient.Execute(restRequest);
                        ResponsePaymentTerm responejson = JsonConvert.DeserializeObject<ResponsePaymentTerm>(restResponse.Content);
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
            return new ResponsePaymentTerm()
            {
                Acknowledge = Acknowledge
            };
        }


    }
}
