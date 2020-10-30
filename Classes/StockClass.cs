using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldStarr_Trading.Classes
{
    public class StockClass
    {
        public List<MerchandiseClass> merchandise = new List<MerchandiseClass>();
        public string ItemName { get; set; }
        public string Supplier { get; set; }
        public int Qty { get; set; }

        public StockClass()
        {

        }
        public StockClass(string itemName, string supplier, int qty)
        {
            ItemName = itemName;
            Supplier = supplier;
            Qty = qty;


        }

        public MerchandiseClass Merchandise
        {
            get => default;
            set
            {
            }
        }
    }
}
