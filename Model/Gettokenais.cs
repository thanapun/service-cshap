using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TVOSERVICE
{
    // สร้าง class สำหรับรับ JSON response
    public class TokenResponse
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
    }

    // สร้าง class สำหรับ return value
    public class Gettokenais
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }
    }

    public class GetSms
    {
        public string resultCode { get; set; }
        public string resultStatus { get; set; }
        public string developerMessage { get; set; }
    }
    public class SmsRespone {
        public string resultCode { get; set; }
        public string resultStatus { get; set; }
        public string developerMessage { get; set; }
        public ResultData resultData { get; set; }
        public string smidList { get; set; } // <-- เตรียมเก็บตัวแรกจาก resultData.smidList
    }
    public class ResultData
    {
        public List<string> smidList { get; set; }
    }


}