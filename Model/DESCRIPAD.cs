using System;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace TVOSERVICE
{
    [Serializable]
    [SoapInclude(typeof(QUEUELOAD))]
    public class DESCRIPAD
    {
        public string DEPARTMENT
        {
            get;
            set;
        }

        public string DESCRIPTION
        {
            get;
            set;
        }

        public string EMAIL
        {
            get;
            set;
        }

        public string FULLNAME
        {
            get;
            set;
        }

        public string LASTLOGON
        {
            get;
            set;
        }

        public string OFFICENAME
        {
            get;
            set;
        }

        public string PWDLASTSET
        {
            get;
            set;
        }

        public string STATUS
        {
            get;
            set;
        }
        public string EXPIRES {
            get;
            set;
        }
        public string DATEEXPIRE {
            get;
            set;
        }

        public DESCRIPAD()
        {
        }
    }
}