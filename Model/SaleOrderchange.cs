using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TVOSERVICE
{
    public class Headers
    {
        public string Salesdocument { get; set; }
        public string Bill_Block { get; set; }
        public string Billing_Block_Desc { get; set; }
    }
    public class Items
    {
        public string Salesdocument { get; set; }
        public string Sale_Item { get; set; }
        public string Reason_For_Jejection { get; set; }
        public string Reason_For_Jejection_Desc { get; set; }
    }
    public class SaleOrderchangeArr {
        public Headers Header { get; set; }
        public List<Items> Items { get; set; }
    }

}