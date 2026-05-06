using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;
using System.ComponentModel;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace TVOSERVICE
{
    [ToolboxItem(false)]
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class CustomerMasterService : WebService
    {
        public CustomerMasterService()
        {
        }

        [SoapDocumentMethod]
        [WebMethod]
        public ResponseModel InsertCustomerMaster(List<CustomerMaster> modelData)
        {
            string ACKNOWLEDGE = "E";
            string MESSAGE = "Unknown error occurred";

            try
            {
                // ตรวจสอบว่าข้อมูลที่รับเข้ามาเป็น null หรือไม่
                if (modelData == null || modelData.Count == 0)
                {
                    return new ResponseModel()
                    {
                        ACKNOWLEDGE = "E",
                        MESSAGE = "Invalid input data: modelData is null or empty"
                    };
                }

                foreach (CustomerMaster modelDatum in modelData)
                {
                    // ตรวจสอบ CUSTOMER_NUMBER ไม่ให้เป็น null หรือค่าว่าง
                    if (!string.IsNullOrEmpty(modelDatum.CUSTOMER_NUMBER) && modelDatum.CUSTOMER_NUMBER != "?")
                    {
                        RestClient restClient = new RestClient("https://xxx.xxx.com");
                        if (restClient == null)
                        {
                            return new ResponseModel()
                            {
                                ACKNOWLEDGE = "E",
                                MESSAGE = "Failed to initialize RestClient"
                            };
                        }

                        RestRequest restRequest = new RestRequest(Method.POST);
                        restRequest.AddHeader("Accept", "application/json");
                        restRequest.AlwaysMultipartFormData = true;
                        restRequest.AddParameter("method", "xx");
                        restRequest.AddParameter("Authorization", "xx");
                        restRequest.AddParameter("CUSTOMER_NUMBER", modelDatum.CUSTOMER_NUMBER);
                        restRequest.AddParameter("SALES_ORG", "9000");
                        restRequest.AddParameter("DISTR_CHAN", modelDatum.DISTR_CHAN);
                        restRequest.AddParameter("DIVISION", modelDatum.DIVISION);
                        restRequest.AddParameter("ACCOUNT_GROUP", modelDatum.ACCOUNT_GROUP);
                        restRequest.AddParameter("SEARCH_TERM1", modelDatum.SEARCH_TERM1);
                        restRequest.AddParameter("SEARCH_TERM2", modelDatum.SEARCH_TERM2);
                        restRequest.AddParameter("NAME1", modelDatum.NAME1);
                        restRequest.AddParameter("NAME2", modelDatum.NAME2);
                        restRequest.AddParameter("NAME3", modelDatum.NAME3);
                        restRequest.AddParameter("NAME4", modelDatum.NAME4);
                        restRequest.AddParameter("STREET2", modelDatum.STREET2);
                        restRequest.AddParameter("STREET3", modelDatum.STREET3);
                        restRequest.AddParameter("STREET", modelDatum.STREET);
                        restRequest.AddParameter("HOUSE_NUMBER", modelDatum.HOUSE_NUMBER);
                        restRequest.AddParameter("STREET4", modelDatum.STREET4);
                        restRequest.AddParameter("STREET5", modelDatum.STREET5);
                        restRequest.AddParameter("DISTRICT", modelDatum.DISTRICT);
                        restRequest.AddParameter("CITY", modelDatum.CITY);
                        restRequest.AddParameter("POST_CODE", modelDatum.POST_CODE);
                        restRequest.AddParameter("REGION", modelDatum.REGION);
                        restRequest.AddParameter("SALE_DISTRICT", modelDatum.SALE_DISTRICT);
                        restRequest.AddParameter("TRANSPORT", modelDatum.TRANSPORT);
                        restRequest.AddParameter("PAYMENT_TERM", modelDatum.PAYMENT_TERM);
                        restRequest.AddParameter("MAKRO_ID", modelDatum.MAKRO_ID);
                        restRequest.AddParameter("CREATE_ON", modelDatum.CREATE_ON);
                        restRequest.AddParameter("ORDER_BLOCK", modelDatum.ORDER_BLOCK);
                        restRequest.AddParameter("DELET_INDICATOR", modelDatum.DELET_INDICATOR);
                        restRequest.AddParameter("SALE_DISTRICT_NAME", modelDatum.SALE_DISTRICT_NAME);
                        restRequest.AddParameter("CUSTOMER_GROUP", modelDatum.CUSTOMER_GROUP);
                        restRequest.AddParameter("CUST_GROUP_NAME", modelDatum.CUST_GROUP_NAME);
                        restRequest.AddParameter("PRICE_LIST", modelDatum.PRICE_LIST);
                        restRequest.AddParameter("PRIC_LIST_NAME", modelDatum.PRIC_LIST_NAME);
                        restRequest.AddParameter("INSERT_UPDATE", modelDatum.INSERT_UPDATE);
                        restRequest.AddParameter("BUYING_GROUP", modelDatum.BUYING_GROUP);
                        restRequest.AddParameter("EMAIL", modelDatum.EMAIL);
                        restRequest.AddParameter("UPDATE_DATE", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                        IRestResponse restResponse = restClient.Execute(restRequest);

                        if (restResponse == null)
                        {
                            return new ResponseModel()
                            {
                                ACKNOWLEDGE = "E",
                                MESSAGE = "API request failed or returned no response"
                            };
                        }

                        // ตรวจสอบว่าข้อมูล JSON มีค่าหรือไม่
                        ResponseModel responejson = null;
                        if (!string.IsNullOrEmpty(restResponse.Content))
                        {
                            responejson = JsonConvert.DeserializeObject<ResponseModel>(restResponse.Content);
                        }

                        if (responejson != null)
                        {
                            ACKNOWLEDGE = responejson.ACKNOWLEDGE;
                            MESSAGE = responejson.MESSAGE;
                        }
                        else
                        {
                            ACKNOWLEDGE = "E";
                            MESSAGE = "Invalid response from API"; //1
                        }
                    }
                    else
                    {
                        ACKNOWLEDGE = "E";
                        MESSAGE = "Not Insert Empty CUSTOMER_NUMBER";
                    }
                }
            }
            catch (Exception ex)
            {
                ACKNOWLEDGE = "E";
                MESSAGE = "Exception: " + ex.Message;
            }

            return new ResponseModel()
            {
                ACKNOWLEDGE = ACKNOWLEDGE,
                MESSAGE = MESSAGE
            };
        }
    }
}
