using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VCRI.Models
{
    public partial class Drug
    {
        public string Drug_Code { get; set; }
        [Required]
        public string Drug_Name { get; set; }
        [Required]
        public string Trade_Code { get; set; }
        [Required]
        public string Dosage_Code { get; set; }
        [Required]
        public string Formulation_code { get; set; }
        public Nullable<System.DateTime> Created_Datetime { get; set; }
        public string Created_By { get; set; }
        public string uname;
        public string tname;
        public string dname;
        public string fname;
    
    }
}