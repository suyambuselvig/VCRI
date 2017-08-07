using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VCRI.Models
{
    public partial class Dosage
    {
        [Required]
        public string Dosage_Code { get; set; }
        [Required]
        public string Dosage_Description { get; set; }
        public string Created_By { get; set; }
        [Required]
        public Nullable<System.DateTime> Created_Datetime { get; set; }

        public string uname;
       
        
    }
}