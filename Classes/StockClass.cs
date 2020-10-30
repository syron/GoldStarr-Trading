using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldStarr_Trading.Classes
{
    class StockClass
    {
        //public List<MerchandiseClass> merchandise = new List<MerchandiseClass>();
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

//        Merchandise[] merchandiseList =
//{
//new Merchandise { ItemName = "Hydrospanner", Supplier = "Acne AB", Stock = 0 },
//new Merchandise { ItemName = "Airscoop", Supplier = "Acne AB", Stock = 0 },
//new Merchandise { ItemName = "Hyper-transceiver", Supplier = "Corelian Inc", Stock = 0 },
//new Merchandise { ItemName = "Nanosporoid", Supplier = "Corelian Inc", Stock = 0 },
//new Merchandise { ItemName = "Boarding-spike", Supplier = "Joruba Consortium", Stock = 0 },
//};

    }




    //List<string> customers = new List<string>();

    //        foreach (var item in CustomerClass.customerList)
    //        {
    //            customers.Add(item.Name);
    //        }

    //this.Customers.ItemsSource = customers;
}
