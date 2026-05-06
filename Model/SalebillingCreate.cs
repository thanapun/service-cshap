using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TVOSERVICE
{
    public class billingCreateAndCancel
    {
            public string Billing_Doc { get; set; }
            public string Billing_Item { get; set; }
            public string Billing_Date { get; set; }
            public string Billing_Type { get; set; }
            public string Billing_Qty { get; set; }
            public string Product_Hierarchy { get; set; }
            public string Sale_District { get; set; }
            public string Create_On { get; set; }
            public string Sale_Doc { get; set; }
            public string Sale_Doc_Item { get; set; }
            public string Cancelled_Doc { get; set; }
            public string Cancelled_Doc_Item { get; set; }
            public string Cancelled_Status { get; set; }
            public string List_Price { get; set; }
            public string Discount_Price { get; set; }
            public string Net_Price { get; set; }
            public string Net_Value { get; set; }
            public string Sale_Unit { get; set; }
            public string Material_Code { get; set; }
            public string Sold_To_Party { get; set; }
            public string Ship_To_Party { get; set; }
            public string Bill_To_Party { get; set; }
            public string Ship_To_Billing { get; set; }
            public string Payer { get; set; }
            public string Currency { get; set; }
            public string Item_Category { get; set; }
            public string Tax_Invoice_No { get; set; }
            public string Internal_Price { get; set; }
            public string Insert_Update { get; set; }
            public string Reference_Doc { get; set; }
            public string Reference_Doc_Item { get; set; }

    }
    public class SalebillingCreateArr
    {
        public List<billingCreateAndCancel> billingCreate { get; set; }
    }
}