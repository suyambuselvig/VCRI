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
    
    public partial class Dosage
    {
        public Dosage()
        {
            this.Drugs = new HashSet<Drug>();
        }
    
        public string Dosage_Code { get; set; }
        public string Dosage_Description { get; set; }
        public string Created_By { get; set; }
        public Nullable<System.DateTime> Created_Datetime { get; set; }
    
        public virtual Login Login { get; set; }
        public virtual ICollection<Drug> Drugs { get; set; }
    }
}