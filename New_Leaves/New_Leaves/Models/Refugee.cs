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
    
    public partial class Refugee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Refugee()
        {
            this.Wish_List = new HashSet<Wish_List>();
        }
    
        public int RID { get; set; }
        public Nullable<int> AthorityCode { get; set; }
        public string RefugeeFName { get; set; }
        public string RefugeeLName { get; set; }
        public string Password { get; set; }
        public string PostCode { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
        public string Family_Description { get; set; }
        public string icon { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Wish_List> Wish_List { get; set; }
    }
}
