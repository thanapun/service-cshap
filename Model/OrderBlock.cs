using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TVOSERVICE
{

    public class Header
    {
        public string Sale_Doc { get; set; }
        public string Sold_To_Party { get; set; }
        public string Ship_To_Party { get; set; }
        public string Sender_Email { get; set; }
        public string Recipient_Email { get; set; }
        public string Title_Of_Email { get; set; }
    }

    public class ItemData
    {
        public string Sale_Doc { get; set; }
        public string Item { get; set; }
        public string Material_No { get; set; }
        public string Material_Desc { get; set; }
        public string Item_Category { get; set; }
        public string Sale_Qty { get; set; }
        public string Sale_Uom { get; set; }
        public string Io_No { get; set; }
        public string Product_Hierarchy { get; set; }
        public string Remark_Item { get; set; }
        public string Net_Amount { get; set; }
        public string Tax_Amount { get; set; }
    }
    public class saleOrderBlock
    {
        public Header Header { get; set; }
        public List<ItemData> Items { get; set; }
    }
    public class ResponseSaleOrderBlock
    {
        public string Acknowledge { get; set; }
        public ResponseSaleOrderBlock()
        {
        }
    }
    public class SaleOrderBlockResponse
    {
        public string Status { get; set; }
    }

}