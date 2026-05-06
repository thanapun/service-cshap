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

    public class CREATEFOLDER : WebService
    {
        public CREATEFOLDER()
        {
        }

        [SoapDocumentMethod]
        [WebMethod]
        public TRUNCREATEFOLDER Createfolder(string PR_NO)
        {
            RestClient restClient = new RestClient("https://xxx.xxx.com");
            RestRequest restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AlwaysMultipartFormData = true;
            restRequest.AddParameter("method", "xx");
            restRequest.AddParameter("Authorization", "xx");
            restRequest.AddParameter("PR_NO", PR_NO);
            IRestResponse restResponse = restClient.Execute(restRequest);
            ROOTCREATEFOLDER rOOTCREATEFOLDER = JsonConvert.DeserializeObject<ROOTCREATEFOLDER>(restResponse.Content);
            return new TRUNCREATEFOLDER()
            {
                MESSAGE = rOOTCREATEFOLDER.MESSAGE,
                MSG_TYPE = rOOTCREATEFOLDER.MSG_TYPE
            };
        }
    }
}