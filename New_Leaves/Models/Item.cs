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
    
    public partial class Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item()
        {
            this.Wish_List = new HashSet<Wish_List>();
        }
    
        public int Item_ID { get; set; }
        public string Item_Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> Estimated_Price { get; set; }
        public string Status { get; set; }
        public string Icon { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Wish_List> Wish_List { get; set; }
    }
}