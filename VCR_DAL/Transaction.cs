//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VCR_DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Transaction
    {
        public string TransactionID { get; set; }
        public string Drug_Code { get; set; }
        public string Sold_By { get; set; }
        public Nullable<System.DateTime> Sold_Datetime { get; set; }
        public Nullable<int> Drug_Count { get; set; }
        public string Comment { get; set; }
        public string BuyerName { get; set; }
    
        public virtual Drug Drug { get; set; }
        public virtual Login Login { get; set; }

       
    }
}