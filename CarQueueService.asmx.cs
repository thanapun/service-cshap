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

    public class CarQueueService : WebService
    {
        public CarQueueService()
        {
        }

        [SoapDocumentMethod]
        [WebMethod]
        public QUEUELOAD GetQueueLoad(string QPL_QR_ID)
        {
            RestClient restClient = new RestClient("https://xxx.xxx.com");
            RestRequest restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AlwaysMultipartFormData = true;
            restRequest.AddParameter("method", "xx");
            restRequest.AddParameter("Authorization", "xx");
            restRequest.AddParameter("par_qrcode", QPL_QR_ID);
            IRestResponse restResponse = restClient.Execute(restRequest);
            ROOTQUELOAD rOOTQUELOAD = JsonConvert.DeserializeObject<ROOTQUELOAD>(restResponse.Content);
            if (rOOTQUELOAD.SUCCESSFULLY != "X")
            {
                return new QUEUELOAD()
                {
                    QTY = "0",
                    VENDOR = "0",
                    SUCCESSFULLY = "",
                    MESSAGE = rOOTQUELOAD.MESSAGE,
                    QPL_DATE_START = rOOTQUELOAD.QPL_DATE_START
                };
            }
            return new QUEUELOAD()
            {
                QPL_QR_ID = rOOTQUELOAD.QPL_QR_ID,
                PLANT = rOOTQUELOAD.PLANT,
                TRUCK1 = rOOTQUELOAD.TRUCK1,
                CITY1 = rOOTQUELOAD.CITY1,
                TRUCK2 = rOOTQUELOAD.TRUCK2,
                CITY2 = rOOTQUELOAD.CITY2,
                AGENT = rOOTQUELOAD.AGENT,
                ZGROUP = rOOTQUELOAD.ZGROUP,
                GROUP_NAME = rOOTQUELOAD.GROUP_NAME,
                CUST_NO = rOOTQUELOAD.CUST_NO,
                CUST_NAME = rOOTQUELOAD.CUST_NAME,
                QTY = rOOTQUELOAD.QTY,
                UOM = rOOTQUELOAD.UOM,
                ZSIZE = rOOTQUELOAD.ZSIZE,
                REMARK = rOOTQUELOAD.REMARK,
                VENDOR = rOOTQUELOAD.VENDOR,
                LOADSTS = rOOTQUELOAD.LOADSTS,
                Z_QUOTA = rOOTQUELOAD.Z_QUOTA,
                SIZE_NAME = rOOTQUELOAD.SIZE_NAME,
                UOM_NAME = rOOTQUELOAD.UOM_NAME,
                SUCCESSFULLY = rOOTQUELOAD.SUCCESSFULLY,
                QPL_DATE_START = rOOTQUELOAD.QPL_DATE_START
            };
        }

        [SoapDocumentMethod]
        [WebMethod]
        public STATUSUPDATE StatusUpdate(string QPL_QR_ID, string QPL_Status, string QA_DATE, string QA_TIME, string QA_NO, string Q_IET, string QL_DATE, string QL_TIME, string QL_NO, string QL_GROUP, string PLANT)
        {
            RestClient restClient = new RestClient("https://xxx.xxx.com");
            RestRequest restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AlwaysMultipartFormData = true;
            restRequest.AddParameter("method", "xx");
            restRequest.AddParameter("Authorization", "xx");
            restRequest.AddParameter("QPL_QR_ID", QPL_QR_ID);
            restRequest.AddParameter("QPL_Status", QPL_Status);
            restRequest.AddParameter("QA_DATE", QA_DATE);
            restRequest.AddParameter("QA_TIME", QA_TIME);
            restRequest.AddParameter("QA_NO", QA_NO);
            restRequest.AddParameter("Q_IET", Q_IET);
            restRequest.AddParameter("QL_DATE", QL_DATE);
            restRequest.AddParameter("QL_TIME", QL_TIME);
            restRequest.AddParameter("QL_NO", QL_NO);
            restRequest.AddParameter("QL_GROUP", QL_GROUP);
            restRequest.AddParameter("PLANT", PLANT);
            IRestResponse restResponse = restClient.Execute(restRequest);
            ROOTUPDATESTATUS rOOTUPDATESTATU = JsonConvert.DeserializeObject<ROOTUPDATESTATUS>(restResponse.Content);
            if (!(QPL_Status == "S") && !(QPL_Status == "C"))
            {
                return new STATUSUPDATE()
                {
                    QPL_QR_ID = QPL_QR_ID,
                    SUCCESSFULLY = "",
                    MESSAGE = "Error QPL_Status Value"
                };
            }
            if (rOOTUPDATESTATU.SUCCESSFULLY == "X")
            {
                return new STATUSUPDATE()
                {
                    QPL_QR_ID = rOOTUPDATESTATU.QPL_QR_ID,
                    SUCCESSFULLY = rOOTUPDATESTATU.SUCCESSFULLY
                };
            }
            return new STATUSUPDATE()
            {
                QPL_QR_ID = QPL_QR_ID,
                SUCCESSFULLY = "",
                MESSAGE = "Error QPL_Status Value"
            };
        }
    }
}