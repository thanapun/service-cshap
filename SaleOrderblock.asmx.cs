using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Services;
using System.Web.Services.Protocols;
using Newtonsoft.Json;
using RestSharp;

namespace TVOSERVICE
{
    [ToolboxItem(false)]
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SaleOrderblock : WebService
    {
        [SoapDocumentMethod]
        [WebMethod]
        public ResponseSaleOrderBlock saleOrderBlockRequest(string saleDoc, string soldToParty, string shipToParty, string senderEmail, string recipientEmail, string titleOfEmail,
                        List<ItemData> items)
        {
            string Acknowledge = "";
            try {
                if (saleDoc != "" && soldToParty != "" && shipToParty != "" && senderEmail != "" && recipientEmail != "" && titleOfEmail != "")
                {

                    RestClient restClient = new RestClient("https://xxx.xxx.com");
                    RestRequest restRequest = new RestRequest(Method.POST);
                    restRequest.AddHeader("Accept", "application/json");
                    restRequest.AlwaysMultipartFormData = true;
                    restRequest.AddParameter("h_method", "xxx");
                    restRequest.AddParameter("h_saleDoc", saleDoc);
                    restRequest.AddParameter("h_soldToParty", soldToParty);
                    restRequest.AddParameter("h_shipToParty", shipToParty);
                    restRequest.AddParameter("h_senderEmail", senderEmail);
                    restRequest.AddParameter("h_recipientEmail", recipientEmail);
                    restRequest.AddParameter("h_titleOfEmail", titleOfEmail);
                    foreach (ItemData item in items)
                    {
                        restRequest.AddParameter("i_Sale_Doc[]", item.Sale_Doc);
                        restRequest.AddParameter("i_Item[]", item.Item);
                        restRequest.AddParameter("i_Material_No[]", item.Material_No);
                        restRequest.AddParameter("i_Material_Desc[]", item.Material_Desc);
                        restRequest.AddParameter("i_Item_Category[]", item.Item_Category);
                        restRequest.AddParameter("i_Sale_Qty[]", item.Sale_Qty);
                        restRequest.AddParameter("i_Sale_Uom[]", item.Sale_Uom);
                        restRequest.AddParameter("i_Io_No[]", item.Io_No);
                        restRequest.AddParameter("i_Product_Hierarchy[]", item.Product_Hierarchy);
                        restRequest.AddParameter("i_Remark_Item[]", item.Remark_Item);
                        restRequest.AddParameter("i_Net_Amount[]", item.Net_Amount);
                        restRequest.AddParameter("i_Tax_Amount[]", item.Tax_Amount);
                    }
                    IRestResponse restResponse = restClient.Execute(restRequest);
                    ResponseSaleOrderBlock responejson = JsonConvert.DeserializeObject<ResponseSaleOrderBlock>(restResponse.Content);
                    Acknowledge = responejson.Acknowledge;
                }
                else
                {
                    Acknowledge = "";
                }
            }
            catch (Exception exceptions) {
                Exception exception = exceptions;
                Acknowledge = "";
            }
            return new ResponseSaleOrderBlock()
            {
                Acknowledge = Acknowledge
            };
        }
    }
}