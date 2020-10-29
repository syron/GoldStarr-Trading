using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GoldStarr_Trading.Classes
{
    class StoreClass
    {
        List<CustomerClass> Customer = new List<CustomerClass>();

        StockClass stockClass = new StockClass();
        public StoreClass()
        {
            Customer.Add(new CustomerClass("Lisa Underwood", "Smallhill 7", "215 70", "Malmö", "555-1967"));
            Customer.Add(new CustomerClass("Olle Bull", "Djäknegatan 13", "215 71", "Malmö", "555-0344"));
            Customer.Add(new CustomerClass("Ben Knota", "Stengränd 11", "215 72", "Malmö", "555-4932"));
            Customer.Add(new CustomerClass("Vilma Hypoxia", "Nikkaluokta", "215 73", "Malmö", "555-3356"));
            Customer.Add(new CustomerClass("Ken Barbie","Dockgatan 3", "215 74", "Malmö", "555-3282"));
        }
        

        public void AddToStock(MerchandiseClass merchandise, int stockToAdd)
        {
            foreach (var merch in stockClass.merchandise)
            {
                if (merch.Name == merchandise.Name)
                {
                    merch.Stock += stockToAdd;
                }
                else
                {
                    throw new System.NotImplementedException();
                }
            }
        }

        public void RemoveFromStock(MerchandiseClass merchandise, int stockToRemove)
        {
            foreach (var merch in stockClass.merchandise)
            {
                if (merch.Name == merchandise.Name)
                {
                    merch.Stock -= stockToRemove;
                }
                else
                {
                    throw new System.NotImplementedException();
                }
            }
        }
    }
}
