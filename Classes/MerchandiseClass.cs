using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldStarr_Trading.Classes
{
    class MerchandiseClass
    {

        public string name { get; set; }
        public string supplier { get; set; }
        public int stock { get; set; }

        public string ShowStock => $"Supplier: {supplier}  Item: {name}  Stock: {stock}"; 

        public MerchandiseClass[] merchandiseList =
            {
            new MerchandiseClass { name = "Hydrospanner", supplier = "Acne AB", stock = 0 },
            new MerchandiseClass { name = "Airscoop", supplier = "Acne AB", stock = 1 },
            new MerchandiseClass { name = "Hyper-transceiver", supplier = "Corelian Inc", stock = 2 },
            new MerchandiseClass { name = "Nanosporoid", supplier = "Corelian Inc", stock = 3 },
            new MerchandiseClass { name = "Boarding-spike", supplier = "Joruba Consortium", stock = 4 },
            };

        
    }
}
