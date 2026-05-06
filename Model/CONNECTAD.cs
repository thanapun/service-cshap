using System;
using System.Collections.Specialized;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace TVOSERVICE
{
    public class CONNECTAD
    {
        public CONNECTAD()
        {
        }

        public bool AuthenUser(string username, string password)
        {
            bool flag = false;
            try
            {
                DirectorySearcher directorySearcher = new DirectorySearcher(new DirectoryEntry("LDAP://xx.xx.com", username, password));
                SearchResult searchResult = null;
                searchResult = directorySearcher.FindOne();
                flag = true;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public DirectorySearcher BuildUserSearcher(DirectoryEntry de)
        {
            DirectorySearcher directorySearcher = null;
            directorySearcher = new DirectorySearcher(de);
            directorySearcher.PropertiesToLoad.Add("name");
            directorySearcher.PropertiesToLoad.Add("sn");
            directorySearcher.PropertiesToLoad.Add("mail");
            directorySearcher.PropertiesToLoad.Add("physicalDeliveryOfficeName");
            directorySearcher.PropertiesToLoad.Add("department");
            directorySearcher.PropertiesToLoad.Add("description");
            directorySearcher.PropertiesToLoad.Add("lastLogon");
            directorySearcher.PropertiesToLoad.Add("pwdLastSet");
            directorySearcher.PropertiesToLoad.Add("accountExpires");  //accountexpires
            return directorySearcher;
        }

        public bool GetOneUser(string username)
        {
            bool flag = false;
            try
            {
                DirectorySearcher directorySearcher = new DirectorySearcher(new DirectoryEntry("LDAP://xx.xx.com"));
                SearchResult searchResult = null;
                searchResult = directorySearcher.FindOne();
                flag = true;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public void UnlockAccount(string username) {
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain,
                                     "LDAP://xx.xx.com",
                                     "xx",
                                     "xx");
            UserPrincipal usr = UserPrincipal.FindByIdentity(ctx, username);
            if (usr != null)
            {
                if (usr.IsAccountLockedOut())
                    usr.UnlockAccount();
                usr.Dispose();
            }
            ctx.Dispose();
        }



    }
}