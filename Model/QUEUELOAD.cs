using System;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace TVOSERVICE
{
    [Serializable]
    [SoapInclude(typeof(QUEUELOAD))]
    public class QUEUELOAD
    {
        public string AGENT
        {
            get;
            set;
        }

        public string CITY1
        {
            get;
            set;
        }

        public string CITY2
        {
            get;
            set;
        }

        public string CUST_NAME
        {
            get;
            set;
        }

        public string CUST_NO
        {
            get;
            set;
        }

        public string GROUP_NAME
        {
            get;
            set;
        }

        public string LOADSTS
        {
            get;
            set;
        }

        public string MESSAGE
        {
            get;
            set;
        }

        public string PLANT
        {
            get;
            set;
        }

        public string QPL_DATE_START
        {
            get;
            set;
        }

        public string QPL_QR_ID
        {
            get;
            set;
        }

        public string QTY
        {
            get;
            set;
        }

        public string REMARK
        {
            get;
            set;
        }

        public string SIZE_NAME
        {
            get;
            set;
        }

        public string SUCCESSFULLY
        {
            get;
            set;
        }

        public string TRUCK1
        {
            get;
            set;
        }

        public string TRUCK2
        {
            get;
            set;
        }

        public string UOM
        {
            get;
            set;
        }

        public string UOM_NAME
        {
            get;
            set;
        }

        public string VENDOR
        {
            get;
            set;
        }

        public string Z_QUOTA
        {
            get;
            set;
        }

        public string ZGROUP
        {
            get;
            set;
        }

        public string ZSIZE
        {
            get;
            set;
        }

        public QUEUELOAD()
        {
        }
    }
}