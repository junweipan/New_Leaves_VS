//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace New_Leaves.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Donor
    {
        public int DId { get; set; }
        public string DonorFName { get; set; }
        public string DonorLName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
    
        public virtual Donation Donation { get; set; }
    }
}