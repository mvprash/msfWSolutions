using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFWSoftSolutions
{
    class barCodeItem
    {
        public string ICode { get; set; }
        public string Description { get; set; }

        public DateTime? DateOfEntry { get; set; }

        

        public int ItemCount { get; set; }

        public bool IsSaleDiscount { get; set; }

        public int SellingPrice { get; set; }

        public int SaleDiscountP { get; set; }

        public string Rack { get; set; }

        public bool IsChecked { get; set; }




    }
}
