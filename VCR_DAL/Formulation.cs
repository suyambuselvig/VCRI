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
    
    public partial class Formulation
    {
        public Formulation()
        {
            this.Drugs = new HashSet<Drug>();
        }
    
        public string Formulation_code { get; set; }
        public string Formulation_Name { get; set; }
        public string Description { get; set; }
        public string ShortName { get; set; }
        public string Created_By { get; set; }
        public Nullable<System.DateTime> Created_Datetime { get; set; }
    
        public virtual ICollection<Drug> Drugs { get; set; }
        public virtual Login Login { get; set; }
    }
}
