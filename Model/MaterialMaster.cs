using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TVOSERVICE
{
    public class Materials
    {
        public string Material { get; set; }
        public string Alt_Unit { get; set; }
        public string Base_Uom { get; set; }
        public string Numerator { get; set; }
        public string Denominatr { get; set; }
        public string Gross_Wt { get; set; }
        public string Unit_Of_Wt { get; set; }
    }
    public class ResponseMaterials
    {
        public string Acknowledge { get; set; }
        public ResponseMaterials()
        {
        }
    }
    public class MaterialMasterArr
    {
        public List<Materials> MaterialMasters { get; set; }
    }
}