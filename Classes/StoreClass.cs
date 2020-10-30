using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GoldStarr_Trading.Classes
{
    public class StoreClass
    {
        public List<CustomerClass> Customer = new List<CustomerClass>();
        public List<StockClass> Stock = new List<StockClass>();

        StockClass stockClass = new StockClass();
        public StoreClass()
        {
            Customer.Add(new CustomerClass("Lisa Underwood", "Smallhill 7", "215 70", "Malmö", "555-1967"));
            Customer.Add(new CustomerClass("Olle Bull", "Djäknegatan 13", "215 71", "Malmö", "555-0344"));
            Customer.Add(new CustomerClass("Ben Knota", "Stengränd 11", "215 72", "Malmö", "555-4932"));
            Customer.Add(new CustomerClass("Vilma Hypoxia", "Nicolaigatan 5", "215 73", "Malmö", "555-3356"));
            Customer.Add(new CustomerClass("Ken Barbie","Dockgatan 3", "215 74", "Malmö", "555-3282"));

            Stock.Add(new StockClass("HydroSpanner", "Acme AB", 1));
            Stock.Add(new StockClass("Airscoop", "Acme AB", 2));
            Stock.Add(new StockClass("Hyper-transceiver", "Corelian Inc", 3));
            Stock.Add(new StockClass("Nanosporoid", "Corelian Inc", 4));
            Stock.Add(new StockClass("Boarding-spike", "Joruba Consortium", 5));
        }


        public void AddToStock(MerchandiseClass merchandise, int stockToAdd)
        {
            foreach (var merch in Stock)
            {
                if (merch.Merchandise.Name == merchandise.Name)
                {
                    merch.Merchandise.Stock += stockToAdd;
                }
                else
                {
                    throw new System.NotImplementedException();
                }
            }
        }

        public void RemoveFromStock(MerchandiseClass merchandise, int stockToRemove)
        {
            foreach (var merch in Stock)
            {
                if (merch.Merchandise.Name == merchandise.Name)
                {
                    merch.Merchandise.Stock -= stockToRemove;
                }
                else
                {
                    throw new System.NotImplementedException();
                }
            }
        }
    }
}
