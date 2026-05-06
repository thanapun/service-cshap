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
    public class SaleOrderchange1 : WebService
    {

        [SoapDocumentMethod]
        [WebMethod]
        public string saleOrderChangeRequest(string Salesdocument, string Bill_Block, string Billing_Block_Desc, List<Items> Items)
        {
            var request = new SaleOrderchangeArr
            {
                Header = new Headers {
                    Salesdocument = Salesdocument,
                    Bill_Block = Bill_Block,
                    Billing_Block_Desc = Billing_Block_Desc
                },
                Items = Items
            };
            // Example
            //foreach (var items in Items)
            //{
            //    Console.WriteLine("Salesdocument: " + items.Salesdocument);
            //    Console.WriteLine("Sale_Item: " + items.Sale_Item);
            //    Console.WriteLine("Reason_For_Jejection: " + items.Reason_For_Jejection);
            //    Console.WriteLine("Reason_For_Jejection_Desc: " + items.Reason_For_Jejection_Desc);
            //}
            string soapXml = SerializeToSoapXml(request);
            return soapXml;
        }
        private string SerializeToSoapXml(SaleOrderchangeArr request)
        {
            var serializer = new XmlSerializer(typeof(SaleOrderchangeArr));
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
