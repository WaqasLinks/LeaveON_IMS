//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MYBUSINESS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Right
    {
        public decimal Id { get; set; }
        public Nullable<decimal> EmployeeId { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public Nullable<bool> Allowed { get; set; }
        public Nullable<bool> MenuView { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}