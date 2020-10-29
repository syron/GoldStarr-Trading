using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldStarr_Trading.Classes
{
    public class MerchandiseClass
    {

        public string Name { get; set; }
        public string Supplier { get; set; }
        public int Stock { get; set; }

        public string ShowStock => $"Supplier: {Supplier}  Item: {Name}  Stock: {Stock}";

        //public MerchandiseClass(string itemName, string inputSupplier, int qty)
        //{
        //    this.Name = itemName;
        //    this.Supplier = inputSupplier;
        //    this.Stock = qty;

        //}


        public static MerchandiseClass[] merchandiseList =
        {
            new MerchandiseClass { Name = "Hydrospanner",       Supplier = "Acme AB",           Stock = 0 },
            new MerchandiseClass { Name = "Airscoop",           Supplier = "Acme AB",           Stock = 1 },
            new MerchandiseClass { Name = "Hyper-transceiver",  Supplier = "Corelian Inc",      Stock = 2 },
            new MerchandiseClass { Name = "Nanosporoid",        Supplier = "Corelian Inc",      Stock = 3 },
            new MerchandiseClass { Name = "Boarding-spike",     Supplier = "Joruba Consortium", Stock = 4 },
        };

        


    }
}
