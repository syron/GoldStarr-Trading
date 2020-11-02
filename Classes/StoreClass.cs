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
        #region Collections
        private ObservableCollection<CustomerClass> CurrentCustomerList = new ObservableCollection<CustomerClass>();
        private ObservableCollection<StockClass> CurrentStockList = new ObservableCollection<StockClass>();
        private ObservableCollection<StockClass> CurrentDeliverysList = new ObservableCollection<StockClass>();
        
        DataSets newDataSet = new DataSets();

        #region OLD Code
        //public ObservableCollection<CustomerClass> Customer { get; set; } //= new List<CustomerClass>();
        //public ObservableCollection<StockClass> Stock { get; set; } //= new List<StockClass>();
        #endregion

        #endregion


        #region Constructors
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
        #endregion


        #region Methods
        public void AddToStock(MerchandiseClass merchandise, int stockToAdd)
        {
            foreach (var merch in CurrentStockList)
            {
                if (merch.Merchandise.MerchandiseName == merchandise.MerchandiseName)
                {
                    merch.Merchandise.MerchandiseStock += stockToAdd;
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
                if (merch.Merchandise.MerchandiseName == merchandise.MerchandiseName)
                {
                    merch.Merchandise.MerchandiseStock -= stockToRemove;
                }
                else
                {
                    throw new System.NotImplementedException();
                }
            }
        }

        public ObservableCollection<CustomerClass> GetCurrentCustomerList()
        {
            return CurrentCustomerList;
        }

        public ObservableCollection<StockClass> GetCurrentStockList()
        {
            return CurrentStockList;
        }

        public ObservableCollection<StockClass> GetCurrentDeliverysList()
        {
            return CurrentDeliverysList;
        }
        #endregion

    }
}
