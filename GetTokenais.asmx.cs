using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;

namespace TVOSERVICE
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class GetTokenais : WebService
    {
        public static string GenerateNonce(string clientName)
        {
            var date = DateTime.Now.ToString("yyyyMMdd");
            var random = new Random();
            var randomNumber = random.Next(100000, 999999);
            return $"{clientName}-{date}-{randomNumber}";
        }
        [WebMethod]
        public Gettokenais gettokenais()
        {
            try
            {
                var client = new RestClient("https://xxx.xxx.com");
                var request = new RestRequest("xxx", Method.POST);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                // สร้าง POST body ด้วยรูปแบบ x-www-form-urlencoded
                request.AddParameter("client_id", "xxx");
                request.AddParameter("client_secret", "xxx");
                request.AddParameter("grant_type", "client_credentials");
                request.AddParameter("nonce", GenerateNonce("ClientName"));
                // เรียกแบบ synchronous
                var response = client.Execute(request);
                // ตรวจสอบว่า response สำเร็จหรือไม่
                if (!string.IsNullOrEmpty(response.Content))
                {
                    // แปลง JSON response เป็น object
                    var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(response.Content);
                    // สร้าง return object
                    return new Gettokenais()
                    {
                        access_token = tokenResponse.access_token,
                        token_type = tokenResponse.token_type,
                        expires_in = tokenResponse.expires_in.ToString()
                    };
                }
                else
                {
                    // กรณี error
                    return new Gettokenais()
                    {
                        access_token = "ERROR",
                        token_type = "Request failed: " + response.ErrorMessage,
                        expires_in = "0"
                    };
                }
            }
            catch (Exception ex)
            {
                // กรณี exception
                return new Gettokenais()
                {
                    access_token = "ERROR",
                    token_type = "Exception: " + ex.Message,
                    expires_in = "0"
                };
            }
        }

        [WebMethod]
        public SmsRespone SendSMS(string token, string tel, string content)
        {
            try
            {
                var client = new RestClient("https://xxx.xxx.com");
                var request = new RestRequest("xxx", Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", "Bearer "+ token);
                var body = new
                {
                    senderName = "xxx",
                    destinationNumber = tel,
                    serviceNumber = "xxx",
                    content = content,
                    contentType = "TEXT"
                };
                request.AddJsonBody(body);
                var response = client.Execute(request);
                // แปลง JSON response เป็น object
                var smsResponse = JsonConvert.DeserializeObject<SmsRespone>(response.Content);
                if (!string.IsNullOrEmpty(response.Content))
                {
                    return new SmsRespone()
                    {
                        resultCode = smsResponse.resultCode,
                        resultStatus = smsResponse.resultStatus,
                        developerMessage = smsResponse.developerMessage,
                        smidList = smsResponse?.resultData?.smidList?.FirstOrDefault() ?? ""
                    };
                }
                else
                {
                    return new SmsRespone
                    {
                        resultCode = smsResponse.resultCode,
                        resultStatus = "FAIL",
                        developerMessage = response.ErrorMessage ?? "Failed to send SMS",
                        smidList = ""
                    };
                }
            }
            catch (Exception ex)
            {
                return new SmsRespone
                {
                    resultCode = "Exception",
                    resultStatus = "ERROR",
                    developerMessage = ex.Message,
                    smidList = ""
                };
            }
        }


    }
}
