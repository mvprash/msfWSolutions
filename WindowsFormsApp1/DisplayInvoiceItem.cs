using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFWSoftSolutions
{
    class DisplayInvoiceItem 
    {
        public int? InvID { get; set; }
        public int Rate { get; set; }

        public int Quantity { get; set; }

        public string ItemDescription { get; set; }

        public bool isWithoutItemCodeBill { get; set; }

        public int TotalAmount { get; set; }

        public long? SizeID { get; set; }

        public string Size { get; set; }

    }
}
