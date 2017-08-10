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
        [Display(Name = "Trade Code")]
        public string trade_Code { get; set; }
        [Display(Name = "Trade Name")]
        public string trade_Name { get; set; }
        [Display(Name = "Created By")]
        public string created_By { get; set; }

        [Display(Name = "Created Date")]
        [DisplayFormat(DataFormatString="{0:ddd MMmm yyyy, hh.mm tt}",ApplyFormatInEditMode=true)]
        public Nullable<System.DateTime> date_Created { get; set; }
        [Display(Name = "Description")]
        public string description { get; set; }
        public string uname;
       
    }
}