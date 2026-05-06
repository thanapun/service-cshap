using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.CompilerServices;

namespace TVOSERVICE
{
    public class PaymentTerm
    {
        public string Term_Of_Payment { get; set; }
        public string Term_Of_Payment_Desc { get; set; }
        public string Term_Of_Payment_Condition { get; set; }
    }
    public class ResponsePaymentTerm
    {
        public string Acknowledge { get;set;}
        public ResponsePaymentTerm()
        {
        }
    }
    public class SalePaymentTerm
    {
        public List<PaymentTerm> PaymentTerms { get; set; }
    }
}