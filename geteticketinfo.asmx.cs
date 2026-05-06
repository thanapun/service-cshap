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

    public class geteticketinfo : System.Web.Services.WebService
    {
        public geteticketinfo()
        {
        }

        [SoapDocumentMethod]
        [WebMethod]
        public ResponseModel InsertWeight(List<GetEticketInfo> modelData)
        {
            string ACKNOWLEDGE = "";
            string MESSAGE = "";
            try
            {
                foreach (GetEticketInfo modelDatum in modelData)
                {
                    if (modelDatum.QPL_QR_ID != "" || ((modelDatum.TRUCK1 != "" && modelDatum.CITY != "") && modelDatum.FLOW_TYPE_ID != ""))
                    {
                        var client = new RestClient("https://xxx.xxx.com");
                        var request = new RestRequest(Method.POST);
                        request.AddHeader("Accept", "application/json");
                        request.AddHeader("Authorization", "x.x-x");
                        request.AlwaysMultipartFormData = true;
                        request.AddParameter("method", "xx");
                        request.AddParameter("QPL_QR_ID", modelDatum.QPL_QR_ID);
                        request.AddParameter("SALEORDER", modelDatum.SALEORDER);
                        request.AddParameter("INVOICE", modelDatum.INVOICE);
                        request.AddParameter("BATCH_NO", modelDatum.BATCH_NO);
                        request.AddParameter("MFG", modelDatum.MFG);
                        request.AddParameter("BBE", modelDatum.BBE);
                        request.AddParameter("TRUCK1", modelDatum.TRUCK1);
                        request.AddParameter("CITY", modelDatum.CITY);
                        request.AddParameter("TRUCK2", modelDatum.TRUCK2);
                        request.AddParameter("CITY2", modelDatum.CITY2);
                        request.AddParameter("FLOW_TYPE_ID", modelDatum.FLOW_TYPE_ID);
                        request.AddParameter("CUSTOMER_NO", modelDatum.CUSTOMER_NO);
                        request.AddParameter("VENDOR_NO", modelDatum.VENDOR_NO);
                        request.AddParameter("MATERIAL_NO", modelDatum.MATERIAL_NO);
                        request.AddParameter("WEIGHT_IN", modelDatum.WEIGHT_IN);
                        request.AddParameter("WEIGHT_OUT", modelDatum.WEIGHT_OUT);
                        request.AddParameter("WEIGHT_DATEIN", modelDatum.WEIGHT_DATEIN);
                        request.AddParameter("WEIGHT_DATEOUT", modelDatum.WEIGHT_DATEOUT);
                        IRestResponse response = client.Execute(request);
                        ResponseModel resjson = JsonConvert.DeserializeObject<ResponseModel>(response.Content);
                        ACKNOWLEDGE = resjson.ACKNOWLEDGE;
                        MESSAGE = resjson.MESSAGE;
                    }
                    else
                    {
                        ACKNOWLEDGE = "0";
                        MESSAGE = "Not Insert Empty";
                    }
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                ACKNOWLEDGE = "0";
                MESSAGE = exception.Message;
            }
            return new ResponseModel()
            {
                ACKNOWLEDGE = ACKNOWLEDGE,
                MESSAGE = MESSAGE
            };
        }
        //
    }
}
