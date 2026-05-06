using System;
using System.Collections;
using System.ComponentModel;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace TVOSERVICE
{
    [ToolboxItem(false)]
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class TVOAD : WebService
    {
        public TVOAD()
        {
        }

        [SoapDocumentMethod]
        [WebMethod]
        public DESCRIPAD GetOneUser(string username)
        {
            CONNECTAD cONNECTAD = new CONNECTAD();
            string str = "";
            string str1 = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            string str6 = "";
            string str7 = "";
            string str8 = "";
            string str9 = "";
            string str10 = "";
            if (!cONNECTAD.GetOneUser(username))
            {
                str = "0";
            }
            else
            {
                DirectoryEntry directoryEntry = new DirectoryEntry("LDAP://xxx.xxx.com");
                DirectorySearcher directorySearcher = cONNECTAD.BuildUserSearcher(directoryEntry);
                directorySearcher.Filter = string.Concat("(&(objectCategory=Person)(objectClass=User)(SAMAccountName=", username, "))");
                SearchResult searchResult = directorySearcher.FindOne();
                if (searchResult != null)
                {
                    ResultPropertyCollection properties = searchResult.Properties;
                    foreach (string propertyName in searchResult.Properties.PropertyNames)
                    {
                        foreach (object item in properties[propertyName])
                        {
                            if (propertyName == "pwdlastset")
                            {
                                str8 = DateTime.FromFileTimeUtc((long)item).ToString();
                                TimeSpan duration = DateTime.FromFileTimeUtc((long)item).AddDays(90) - DateTime.UtcNow;
                                double totalDays = duration.TotalDays;
                                int roundedNumber = (int)Math.Round(totalDays, MidpointRounding.AwayFromZero);
                                str9 = roundedNumber.ToString();
                                DateTime date = DateTime.Parse(DateTime.FromFileTimeUtc((long)item).AddDays(90).ToString());
                                str10 = date.ToString("yyyy-MM-dd");
                            }
                            else if (propertyName == "lastlogon")
                            {
                                str7 = DateTime.FromFileTimeUtc((long)item).ToString();
                            }
                            else if (propertyName == "name")
                            {
                                str1 = item.ToString();
                            }
                            else if (propertyName == "sn")
                            {
                                str2 = item.ToString();
                            }
                            else if (propertyName == "mail")
                            {
                                str3 = item.ToString();
                            }
                            else if (propertyName == "physicaldeliveryofficename")
                            {
                                str4 = item.ToString();
                            }
                            else if (propertyName != "department")
                            {
                                if (propertyName != "description")
                                {
                                    continue;
                                }
                                str6 = item.ToString();
                            }
                            else
                            {
                                str5 = item.ToString();
                            }
                        }
                    }
                    str = "1";
                    directoryEntry.Dispose();
                }
            }
            return new DESCRIPAD()
            {
                STATUS = str,
                FULLNAME = string.Concat(str1, " ", str2),
                EMAIL = str3,
                OFFICENAME = str4,
                DEPARTMENT = str5,
                DESCRIPTION = str6,
                LASTLOGON = str7,
                PWDLASTSET = str8,
                EXPIRES = str9,
                DATEEXPIRE = str10
            };
        }

        [SoapDocumentMethod]
        [WebMethod]
        public DESCRIPAD LoginAD(string username, string password)
        {
            CONNECTAD cONNECTAD = new CONNECTAD();
            string str = "";
            string str1 = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            string str6 = "";
            string str7 = "";
            string str8 = "";
            string str9 = "";
            string str10 = "";
            if (!cONNECTAD.AuthenUser(username, password))
            {
                str = "0";
            }
            else
            {
                DirectoryEntry directoryEntry = new DirectoryEntry("LDAP://xxx.xxx.com", username, password);
                DirectorySearcher directorySearcher = cONNECTAD.BuildUserSearcher(directoryEntry);
                directorySearcher.Filter = string.Concat("(&(objectCategory=Person)(objectClass=User)(SAMAccountName=", username, "))");
                SearchResult searchResult = directorySearcher.FindOne();
                if (searchResult != null)
                {
                    ResultPropertyCollection properties = searchResult.Properties;
                    foreach (string propertyName in searchResult.Properties.PropertyNames)
                    {
                        foreach (object item in properties[propertyName])
                        {
                            if (propertyName == "pwdlastset")
                            {
                                str8 = DateTime.FromFileTimeUtc((long)item).ToString();
                                TimeSpan duration = DateTime.FromFileTimeUtc((long)item).AddDays(90) - DateTime.UtcNow;
                                double totalDays = duration.TotalDays;
                                int roundedNumber = (int)Math.Round(totalDays, MidpointRounding.AwayFromZero);
                                str9 = roundedNumber.ToString();
                                DateTime date = DateTime.Parse(DateTime.FromFileTimeUtc((long)item).AddDays(90).ToString());
                                str10 = date.ToString("yyyy-MM-dd");
                            }
                            else if (propertyName == "lastlogon")
                            {
                                str7 = DateTime.FromFileTimeUtc((long)item).ToString();
                            }
                            else if (propertyName == "name")
                            {
                                str1 = item.ToString();
                            }
                            else if (propertyName == "sn")
                            {
                                str2 = item.ToString();
                            }
                            else if (propertyName == "mail")
                            {
                                str3 = item.ToString();
                            }
                            else if (propertyName == "physicaldeliveryofficename")
                            {
                                str4 = item.ToString();
                            }
                            else if (propertyName != "department")
                            {
                                if (propertyName != "description")
                                {
                                    continue;
                                }
                                str6 = item.ToString();
                            }
                            else
                            {
                                str5 = item.ToString();
                            }
                        }
                    }
                    str = "1";
                    directoryEntry.Dispose();
                }
            }
            return new DESCRIPAD()
            {
                STATUS = str,
                FULLNAME = string.Concat(str1, " ", str2),
                EMAIL = str3,
                OFFICENAME = str4,
                DEPARTMENT = str5,
                DESCRIPTION = str6,
                LASTLOGON = str7,
                PWDLASTSET = str8,
                EXPIRES = str9,
                DATEEXPIRE = str10
            };
        }

        [SoapDocumentMethod]
        [WebMethod]
        public RESETPASSWORD Resetpassword(string username, string newpassword)
        {
            string str = "";
            string str1 = "";
            string str2 = "";
            try
            {
                DirectoryEntry directoryEntry = new DirectoryEntry("LDAP://xxx.xxx.com", "xxxx", "xxx");
                if (directoryEntry != null)
                {
                    DirectorySearcher directorySearcher = new DirectorySearcher(directoryEntry)
                    {
                        Filter = string.Concat("(samaccountname=", username, ")")
                    };
                    SearchResult searchResult = directorySearcher.FindOne();
                    if (searchResult == null)
                    {
                        str = "0";
                        str2 = "Failed";
                        str1 = "Account Empty";
                    }
                    else
                    {
                        // Get the DirectoryEntry object of the user account
                        DirectoryEntry userEntry = searchResult.GetDirectoryEntry();
                        if (userEntry != null)
                        {
                            userEntry.Invoke("SetPassword", new object[] { newpassword });
                            userEntry.Properties["lockouttime"].Value = 0;
                            str = "1";
                            str2 = "Success";
                            str1 = string.Concat("New Pass : ", newpassword);
                        }
                    }
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                str = "0";
                str2 = string.Concat("The account will be active if it already exists, but if it does not exist, it cannot be active :", exception.InnerException.Message);
                str1 = "";
            }
            return new RESETPASSWORD()
            {
                STATUS = str,
                NEWPASSWORD = str1,
                MSG = str2
            };
        }

        [SoapDocumentMethod]
        [WebMethod]
        public UNLOCKAD unloclUserad(string username) {
            // admis
            // edp@5206
            string str = "";
            string str1 = "";
            // Set the LDAP path, username and password for the domain
            string ldapPath = "LDAP://xxx.xxx.com";
            string user = "xxxx";
            string pass = "xxxx";
            try {
                // Create a DirectoryEntry object with the domain and credentials
                DirectoryEntry directoryEntry = new DirectoryEntry(ldapPath, user, pass);

                // Create a DirectorySearcher object to find the user account by its SAM account name
                DirectorySearcher directorySearcher = new DirectorySearcher(directoryEntry)
                {
                    Filter = string.Concat("(samaccountname=", username, ")")
                };
                SearchResult searchResult = directorySearcher.FindOne();

                if (searchResult == null)
                {
                    // The user account was not found
                    str = "0";
                    str1 = "The account will be active if it already exists, but if it does not exist, it cannot be active.";
                }
                else
                {
                    // Get the DirectoryEntry object of the user account
                    DirectoryEntry userEntry = searchResult.GetDirectoryEntry();
                    // Unlock the user account by setting the LockOutTime property to 0
                    userEntry.Properties["LockOutTime"].Value = 0;
                    // Save the changes to the AD
                    userEntry.CommitChanges();
                    // Close the DirectoryEntry object
                    userEntry.Close();
                    str = "1";
                    str1 = "The account will be active if it already exists, but if it does not exist, it cannot be active.";
                }
            }
            catch (Exception exception1) {
                if (exception1.InnerException != null)
                {
                    str = "0";
                    str1 = exception1.InnerException.Message+" -> "+ username;
                }
                else
                {
                    str = "0";
                    str1 = exception1.Message + " # " + username;
                }
            }
            return new UNLOCKAD()
            {
                STATUS = str,
                MSG = str1
            };
        }

    }
}