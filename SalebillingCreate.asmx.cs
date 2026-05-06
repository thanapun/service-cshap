using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

namespace TVOSERVICE
{
    [ToolboxItem(false)]
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SalebillingCreate1 : WebService
    {

        [WebMethod]
        public string billingCreateAndCancelRequest(List<billingCreateAndCancel> billingCreates)
        {
            var request = new SalebillingCreateArr
            {
                billingCreate = billingCreates
            };
            string soapXml = SerializeToSoapXml(request);
            return soapXml;
        }
        private string SerializeToSoapXml(SalebillingCreateArr request)
        {
            var serializer = new XmlSerializer(typeof(SalebillingCreateArr));
            using (var stringWriter = new System.IO.StringWriter())
            {
                using (var writer = System.Xml.XmlWriter.Create(stringWriter))
                {
                    serializer.Serialize(writer, request);
                    return stringWriter.ToString();
                }
            }
        }
    }
}
