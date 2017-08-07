using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VCRI.Models
{
    public partial class Formulation
    {
        public string Formulation_code { get; set; }
        [Required]
        public string Formulation_Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ShortName { get; set; }
        public string Created_By { get; set; }
        public Nullable<System.DateTime> Created_Datetime { get; set; }
        public string uname;
    }
}