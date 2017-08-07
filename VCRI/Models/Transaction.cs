using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VCRI.Models
{
    public partial class Transaction
    {
        public string TransactionID { get; set; }
        public string Drug_Code { get; set; }
        public string Sold_By { get; set; }
      [DisplayFormat(DataFormatString = "{0:ddd MMmm yyyy, hh.mm tt}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> Sold_Datetime { get; set; }
        public Nullable<int> Drug_Count { get; set; }
        public string Comment { get; set; }
        public string BuyerName { get; set; }
        public string uname;
        public string drugname;
    }
}