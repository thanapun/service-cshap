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
    public class SaleCustomermaster : WebService
    {
        [SoapDocumentMethod]
        [WebMethod]
        public ResponseCustomerMaster Salecustomer(List<customer> customerRequest)
        {
            string Acknowledge = "E";

            try
            {
                // ตรวจสอบว่ารายการ customerRequest ไม่เป็น null หรือว่าง
                if (customerRequest == null || customerRequest.Count == 0)
                {
                    return new ResponseCustomerMaster()
                    {
                        Acknowledge = "E - Invalid input: customerRequest is null or empty"
                    };
                }

                foreach (customer items in customerRequest)
                {
                    if (items == null || string.IsNullOrEmpty(items.Customer_Number))
                    {
                        return new ResponseCustomerMaster()
                        {
                            Acknowledge = "E - Invalid data: Customer_Number is required"
                        };
                    }

                    RestClient restClient = new RestClient("https://xxx.xxx.com");
                    RestRequest restRequest = new RestRequest(Method.POST);
                    restRequest.AddHeader("Accept", "application/json");
                    restRequest.AlwaysMultipartFormData = true;
                    restRequest.AddParameter("method", "xxx");
                    restRequest.AddParameter("Customer_Number", items.Customer_Number);
                    restRequest.AddParameter("Sales_Org", "9000");
                    restRequest.AddParameter("Distr_Chan", items.Distr_Chan);
                    restRequest.AddParameter("Division", items.Division);
                    restRequest.AddParameter("Account_Group", items.Account_Group);
                    restRequest.AddParameter("Search_Term1", items.Search_Term1);
                    restRequest.AddParameter("Search_Term2", items.Search_Term2);
                    restRequest.AddParameter("Name1", items.Name1);
                    restRequest.AddParameter("Name2", items.Name2);
                    restRequest.AddParameter("Name3", items.Name3);
                    restRequest.AddParameter("Name4", items.Name4);
                    restRequest.AddParameter("Street2", items.Street2);
                    restRequest.AddParameter("Street3", items.Street3);
                    restRequest.AddParameter("Street", items.Street);
                    restRequest.AddParameter("House_Number", items.House_Number);
                    restRequest.AddParameter("Street4", items.Street4);
                    restRequest.AddParameter("Street5", items.Street5);
                    restRequest.AddParameter("District", items.District);
                    restRequest.AddParameter("City", items.City);
                    restRequest.AddParameter("Post_Code", items.Post_Code);
                    restRequest.AddParameter("Region", items.Region);
                    restRequest.AddParameter("Sale_District", items.Sale_District);
                    restRequest.AddParameter("Transport", items.Transport);
                    restRequest.AddParameter("Payment_Term", items.Payment_Term);
                    restRequest.AddParameter("Makro_Id", items.Makro_Id);
                    restRequest.AddParameter("Create_On", items.Create_On);
                    restRequest.AddParameter("Order_Block", items.Order_Block);
                    restRequest.AddParameter("Delet_Indicator", items.Delet_Indicator);
                    restRequest.AddParameter("Sale_District_Name", items.Sale_District_Name);
                    restRequest.AddParameter("Customer_Group", items.Customer_Group);
                    restRequest.AddParameter("Cust_Group_Name", items.Cust_Group_Name);
                    restRequest.AddParameter("Price_List", items.Price_List);
                    restRequest.AddParameter("Pric_List_Name", items.Pric_List_Name);
                    restRequest.AddParameter("Insert_Update", items.Insert_Update);

                    IRestResponse restResponse = restClient.Execute(restRequest);

                    // ตรวจสอบว่าการร้องขอ API สำเร็จหรือไม่
                    if (restResponse == null)
                    {
                        return new ResponseCustomerMaster()
                        {
                            Acknowledge = "E - API request failed or returned no response"
                        };
                    }

                    // ตรวจสอบว่า API ตอบกลับข้อมูล JSON หรือไม่
                    ResponseCustomerMaster responseJson = null;
                    if (!string.IsNullOrEmpty(restResponse.Content))
                    {
                        responseJson = JsonConvert.DeserializeObject<ResponseCustomerMaster>(restResponse.Content);
                    }

                    if (responseJson != null)
                    {
                        Acknowledge = responseJson.Acknowledge;
                    }
                    else
                    {
                        Acknowledge = "E - Invalid API response format";
                    }
                }
            }
            catch (Exception ex)
            {
                Acknowledge = "E - "+ ex.ToString();
            }

            return new ResponseCustomerMaster()
            {
                Acknowledge = Acknowledge
            };
        }
    }
}
