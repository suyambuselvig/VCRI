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
    
    public partial class Order
    {
        public string Order_Code { get; set; }
        public Nullable<System.DateTime> Order_Date { get; set; }
        public string Drug_Code { get; set; }
        public Nullable<int> Order_Count { get; set; }
        public string Ordered_By { get; set; }
    
        public virtual Drug Drug { get; set; }
        public virtual Login Login { get; set; }
    }
}