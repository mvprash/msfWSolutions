//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MSFWSoftSolutions
{
    using System;
    using System.Collections.Generic;
    
    public partial class ItemSize
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ItemSize()
        {
            this.InvoiceItems = new HashSet<InvoiceItem>();
        }
    
        public long SizeID { get; set; }
        public string ICode { get; set; }
        public string Size { get; set; }
        public int Count { get; set; }
        public string BatchNumber { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }
    }
}
