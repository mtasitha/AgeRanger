//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AgeRanger.Web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AgeGroup
    {
        public long Id { get; set; }
        public Nullable<long> MinAge { get; set; }
        public Nullable<long> MaxAge { get; set; }
        public string Description { get; set; }
    }
}