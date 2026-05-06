using Newtonsoft.Json;
using RestSharp;
using System;
using System.ComponentModel;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace TVOSERVICE
{
    [ToolboxItem(false)]
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class TURNSTATUSCARQ : WebService
    {
        public TURNSTATUSCARQ()
        {
        }

        [SoapDocumentMethod]
        [WebMethod]
        public TRUNSTATUSCARQ STATUSCARQ(string QR_CODE, string QR_STATUS)
        {
            RestClient restClient = new RestClient("https://xxx.xxx.com");
            RestRequest restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AlwaysMultipartFormData = true;
            restRequest.AddParameter("method", "xxx");
            restRequest.AddParameter("Authorization", "xxx");
            restRequest.AddParameter("QR_CODE", QR_CODE);
            restRequest.AddParameter("QR_STATUS", QR_STATUS);
            IRestResponse restResponse = restClient.Execute(restRequest);
            ROOTSTATUSCARQ rOOTSTATUSCARQ = JsonConvert.DeserializeObject<ROOTSTATUSCARQ>(restResponse.Content);
            return new TRUNSTATUSCARQ()
            {
                MSG_TYPE = rOOTSTATUSCARQ.MSG_TYPE
            };
        }
    }
}