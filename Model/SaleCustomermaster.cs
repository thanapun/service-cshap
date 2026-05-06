using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TVOSERVICE
{
    public class customer
    {
        public string Customer_Number { get; set; }
        public string Sales_Org { get; set; }
        public string Distr_Chan { get; set; }
        public string Division { get; set; }
        public string Account_Group { get; set; }
        public string Search_Term1 { get; set; }
        public string Search_Term2 { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Name3 { get; set; }
        public string Name4 { get; set; }
        public string Street2 { get; set; }
        public string Street3 { get; set; }
        public string Street { get; set; }
        public string House_Number { get; set; }
        public string Street4 { get; set; }
        public string Street5 { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Post_Code { get; set; }
        public string Region { get; set; }
        public string Sale_District { get; set; }
        public string Transport { get; set; }
        public string Payment_Term { get; set; }
        public string Makro_Id { get; set; }
        public string Create_On { get; set; }
        public string Order_Block { get; set; }
        public string Delet_Indicator { get; set; }
        public string Sale_District_Name { get; set; }
        public string Customer_Group { get; set; }
        public string Cust_Group_Name { get; set; }
        public string Price_List { get; set; }
        public string Pric_List_Name { get; set; }
        public string Insert_Update { get; set; }
    }
    public class SaleCustomermasterArr
    {
        public List<customer> customer { get; set; }
    }
    public class ResponseCustomerMaster
    {
        public string Acknowledge { get; set; }
        public ResponseCustomerMaster()
        {
        }
    }
    public class SaleCustomermasterResponse
    {
        public string Status { get; set; }
    }
}