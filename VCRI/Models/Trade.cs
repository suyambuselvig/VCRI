using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VCRI.Models
{
    public partial class Trade
    {
        
        public string Trade_Code { get; set; }
        public string Trade_Name { get; set; }

        public string Created_By { get; set; }
        
        [DisplayFormat(DataFormatString="{0:ddd MMmm yyyy, hh.mm tt}",ApplyFormatInEditMode=true)]
        public Nullable<System.DateTime> Created_datetime { get; set; }
        public string Description { get; set; }
        public string uname;
       
    }
}