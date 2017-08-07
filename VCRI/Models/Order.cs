using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VCRI.Models
{
    public partial class Order
    {
        public string Order_Code { get; set; }
        [Required]
        public Nullable<System.DateTime> Order_Date { get; set; }
        [Required]
        public string Drug_Code { get; set; }
        [Required]
        public Nullable<int> Order_Count { get; set; }
        
        public string Ordered_By { get; set; }
        public string uname;
        public string drugname;
    
    }
}