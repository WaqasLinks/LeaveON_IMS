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
    
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            this.Calendars = new HashSet<Calendar>();
            this.Rents = new HashSet<Rent>();
            this.Services = new HashSet<Service>();
            this.SOes = new HashSet<SO>();
        }
    
        public decimal Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string TrackLink { get; set; }
        public Nullable<decimal> Balance { get; set; }
        public string Remarks { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string bizId { get; set; }
        public string AccountType { get; set; }
        public string AccountName { get; set; }
        public string CompanyNo { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Website { get; set; }
        public string Cell { get; set; }
        public string Other { get; set; }
        public string BillingAddress { get; set; }
        public string BillingCity { get; set; }
        public string BillingZip { get; set; }
        public string BillingState { get; set; }
        public string BillingCountry { get; set; }
        public string Term { get; set; }
        public string DriversLicense { get; set; }
        public string Picture { get; set; }
        public string Referral { get; set; }
        public string CreditCardInfo { get; set; }
        public string Notes { get; set; }
    
        public virtual BusinessInfo BusinessInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Calendar> Calendars { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rent> Rents { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Service> Services { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SO> SOes { get; set; }
    }
}