using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VCRI.Models
{
    public partial class Stock
    {
        public string Drug_Code { get; set; }
        public int Quantity { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}",ApplyFormatInEditMode=true)]
        public System.DateTime Expiry_Date { get; set; }
        public bool IsActive { get; set; }
        public string drugname;
    }
}