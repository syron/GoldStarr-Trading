using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldStarr_Trading.Classes
{
    class StockClass
    {
        public List<MerchandiseClass> merchandise = new List<MerchandiseClass>();

        public MerchandiseClass Merchandise
        {
            get => default;
            set
            {
            }
        }
    }


    //List<string> customers = new List<string>();

    //        foreach (var item in CustomerClass.customerList)
    //        {
    //            customers.Add(item.Name);
    //        }

    //this.Customers.ItemsSource = customers;
}
