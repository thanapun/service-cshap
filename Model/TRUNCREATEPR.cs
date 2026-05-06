using System;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace TVOSERVICE
{
    [Serializable]
    [SoapInclude(typeof(TRUNCREATEPR))]
    public class TRUNCREATEPR
    {
        public string MESSAGE
        {
            get;
            set;
        }

        public string MSG_TYPE
        {
            get;
            set;
        }

        public TRUNCREATEPR()
        {
        }
    }
}