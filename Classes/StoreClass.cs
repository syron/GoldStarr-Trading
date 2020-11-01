using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GoldStarr_Trading.Classes
{
    class StoreClass
    {

        private List<CustomerClass> CurrentCustomerList = new List<CustomerClass>();
        private List<StockClass> CurrentStockList = new List<StockClass>();
        private List<StockClass> CurrentDeliverysList = new List<StockClass>();

        #region OLD Code
        //public ObservableCollection<CustomerClass> Customer { get; set; } //= new List<CustomerClass>();
        //public ObservableCollection<StockClass> Stock { get; set; } //= new List<StockClass>();
        #endregion

        DataSets newDataSet = new DataSets();
        

        public StoreClass()
        {
            CurrentStockList = newDataSet.GetDefaultStockList();
            CurrentCustomerList = newDataSet.GetDefaultCustomerList();
            CurrentDeliverysList = newDataSet.GetDefaultDeliverysList();

            #region OLD Code
            //Moved to DataSets Class
            //CurrentCustomerList.Add(new CustomerClass("Lisa Underwood", "Smallhill 7", "215 70", "Malmö", "555-1967"));
            //CurrentCustomerList.Add(new CustomerClass("Olle Bull", "Djäknegatan 13", "215 71", "Malmö", "555-0344"));
            //CurrentCustomerList.Add(new CustomerClass("Ben Knota", "Stengränd 11", "215 72", "Malmö", "555-4932"));
            //CurrentCustomerList.Add(new CustomerClass("Vilma Hypoxia", "Nicolaigatan 5", "215 73", "Malmö", "555-3356"));
            //CurrentCustomerList.Add(new CustomerClass("Ken Barbie","Dockgatan 3", "215 74", "Malmö", "555-3282"));

            //CurrentStockList.Add(new StockClass("HydroSpanner", "Acme AB", 1));
            //CurrentStockList.Add(new StockClass("Airscoop", "Acme AB", 2));
            //CurrentStockList.Add(new StockClass("Hyper-transceiver", "Corelian Inc", 3));
            //CurrentStockList.Add(new StockClass("Nanosporoid", "Corelian Inc", 4));
            //CurrentStockList.Add(new StockClass("Boarding-spike", "Joruba Consortium", 5));
            #endregion
        }


        public void AddToStock(MerchandiseClass merchandise, int stockToAdd)
        {
            foreach (var merch in CurrentStockList)
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
            foreach (var merch in CurrentStockList)
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

        public List<CustomerClass> GetCurrentCustomerList()
        {
            return CurrentCustomerList;
        }

        public List<StockClass> GetCurrentStockList()
        {
            return CurrentStockList;
        }

        public List<StockClass> GetCurrentDeliverysList()
        {
            return CurrentDeliverysList;
        }

    }
}
