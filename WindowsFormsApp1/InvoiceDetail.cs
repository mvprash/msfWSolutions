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
    
    public partial class InvoiceDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InvoiceDetail()
        {
            this.InvoiceItems = new HashSet<InvoiceItem>();
        }
    
        public long InvoiceID { get; set; }
        public System.DateTime InvoiceDate { get; set; }
        public string InvoiceNumber { get; set; }
        public int TaxableAmount { get; set; }
        public int CGST { get; set; }
        public int SGST { get; set; }
        public int TotalPayable { get; set; }
        public byte[] InvoicePDF { get; set; }
        public bool Digital { get; set; }
        public bool Cash { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }
    }
}