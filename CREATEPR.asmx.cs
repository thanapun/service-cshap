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
    public class CREATEPR : WebService
    {
        public CREATEPR()
        {
        }

        [SoapDocumentMethod]
        [WebMethod]
        public TRUNCREATEPR Createpr(string PR_NO, string PR_TYPE, string PR_TYPE_DESC, string REQUISTIONER_ID, string REQUISTIONER_NAME, string HEADER_TEXT, string ADDRESS_ID, string ADDRESS_SEARCH_TERM1, string PR_REF_TYPE, string ACC_ASSIGNMT, string GL, string MAT_TYPE, string MAT_GROUP, string LOCAL_TOTAL_VALUE, string TOTAL_VALUE, string CURRENCY, string REL_GRP, string REL_STRATEGY, string TOTAL_PR_ITEM, string iPR_NO, string PR_ITEM, string ACC_ASSIGNMENT, string MATERIAL_CODE, string iMAT_GROUP, string SHORT_TEXT, string ITEM_TEXT, string MATERIAL_PO_TEXT, string QUANTITY, string UNIT, string PRICE_UNIT, string iTOTAL_VALUE, string LOCAL_PRICE_UNIT, string iLOCAL_TOTAL_VALUE, string iCURRENCY, string PURCHASE_GROUP, string REQUEST_DATE, string DELIVERY_DATE, string CHANGED_DATE, string iGL, string iIO, string COST_CENTER, string ASSET, string ASSET_SUB_NO, string GL_DESC, string IO_DESC, string COST_CENTER_DESC, string ASSET_DESC)
        {
            RestClient restClient = new RestClient("https://xxx.xxx.com");
            RestRequest restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AlwaysMultipartFormData = true;
            restRequest.AddParameter("method", "xx");
            restRequest.AddParameter("Authorization", "xx");
            restRequest.AddParameter("PR_NO", PR_NO);
            restRequest.AddParameter("PR_TYPE", PR_TYPE);
            restRequest.AddParameter("PR_TYPE_DESC", PR_TYPE_DESC);
            restRequest.AddParameter("REQUISTIONER_ID", REQUISTIONER_ID);
            restRequest.AddParameter("REQUISTIONER_NAME", REQUISTIONER_NAME);
            restRequest.AddParameter("HEADER_TEXT", HEADER_TEXT);
            restRequest.AddParameter("ADDRESS_ID", ADDRESS_ID);
            restRequest.AddParameter("ADDRESS_SEARCH_TERM1", ADDRESS_SEARCH_TERM1);
            restRequest.AddParameter("PR_REF_TYPE", PR_REF_TYPE);
            restRequest.AddParameter("ACC_ASSIGNMT", ACC_ASSIGNMT);
            restRequest.AddParameter("GL", GL);
            restRequest.AddParameter("MAT_TYPE", MAT_TYPE);
            restRequest.AddParameter("MAT_GROUP", MAT_GROUP);
            restRequest.AddParameter("LOCAL_TOTAL_VALUE", LOCAL_TOTAL_VALUE);
            restRequest.AddParameter("TOTAL_VALUE", TOTAL_VALUE);
            restRequest.AddParameter("CURRENCY", CURRENCY);
            restRequest.AddParameter("REL_GRP", REL_GRP);
            restRequest.AddParameter("REL_STRATEGY", REL_STRATEGY);
            restRequest.AddParameter("TOTAL_PR_ITEM", TOTAL_PR_ITEM);
            restRequest.AddParameter("iPR_NO", iPR_NO);
            restRequest.AddParameter("PR_ITEM", PR_ITEM);
            restRequest.AddParameter("ACC_ASSIGNMENT", ACC_ASSIGNMENT);
            restRequest.AddParameter("MATERIAL_CODE", MATERIAL_CODE);
            restRequest.AddParameter("iMAT_GROUP", iMAT_GROUP);
            restRequest.AddParameter("SHORT_TEXT", SHORT_TEXT);
            restRequest.AddParameter("ITEM_TEXT", ITEM_TEXT);
            restRequest.AddParameter("MATERIAL_PO_TEXT", MATERIAL_PO_TEXT);
            restRequest.AddParameter("QUANTITY", QUANTITY);
            restRequest.AddParameter("UNIT", UNIT);
            restRequest.AddParameter("PRICE_UNIT", PRICE_UNIT);
            restRequest.AddParameter("iTOTAL_VALUE", iTOTAL_VALUE);
            restRequest.AddParameter("LOCAL_PRICE_UNIT", LOCAL_PRICE_UNIT);
            restRequest.AddParameter("iLOCAL_TOTAL_VALUE", iLOCAL_TOTAL_VALUE);
            restRequest.AddParameter("iCURRENCY", iCURRENCY);
            restRequest.AddParameter("PURCHASE_GROUP", PURCHASE_GROUP);
            restRequest.AddParameter("REQUEST_DATE", REQUEST_DATE);
            restRequest.AddParameter("DELIVERY_DATE", DELIVERY_DATE);
            restRequest.AddParameter("CHANGED_DATE", CHANGED_DATE);
            restRequest.AddParameter("iGL", iGL);
            restRequest.AddParameter("iIO", iIO);
            restRequest.AddParameter("COST_CENTER", COST_CENTER);
            restRequest.AddParameter("ASSET", ASSET);
            restRequest.AddParameter("ASSET_SUB_NO", ASSET_SUB_NO);
            restRequest.AddParameter("GL_DESC", GL_DESC);
            restRequest.AddParameter("IO_DESC", IO_DESC);
            restRequest.AddParameter("COST_CENTER_DESC", COST_CENTER_DESC);
            restRequest.AddParameter("ASSET_DESC", ASSET_DESC);
            IRestResponse restResponse = restClient.Execute(restRequest);
            ROOTCREATEPR rOOTCREATEPR = JsonConvert.DeserializeObject<ROOTCREATEPR>(restResponse.Content);
            return new TRUNCREATEPR()
            {
                MESSAGE = rOOTCREATEPR.MESSAGE,
                MSG_TYPE = rOOTCREATEPR.MSG_TYPE
            };
        }
    }
}