using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth.Advertisement;
using Windows.UI.Popups;

namespace GoldStarr_Trading.Classes
{
    class StoreClass
    {
        #region Collections
        private static ObservableCollection<CustomerClass> CurrentCustomerList = new ObservableCollection<CustomerClass>();
        private ObservableCollection<CustomerOrderClass> CustomerOrders = new ObservableCollection<CustomerOrderClass>();
        private static ObservableCollection<StockClass> CurrentStockList = new ObservableCollection<StockClass>();
        private static ObservableCollection<StockClass> CurrentDeliverysList = new ObservableCollection<StockClass>();

        
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
        public static void AddToStock(StockClass merchandise, int stockToAdd)
        {
            int stockToRemove = stockToAdd;

            foreach (var item in CurrentStockList)
            {
                if (item.ItemName == merchandise.ItemName)
                {
                    item.Qty += stockToAdd;
                    RemoveFromDeliveryList(merchandise, stockToRemove);
                }
            }

            //foreach (var merch in CurrentStockList)
            //{
            //    if (merch.Merchandise.MerchandiseName == merchandise.MerchandiseName)
            //    {
            //        merch.Merchandise.MerchandiseStock += stockToAdd;
            //    }
            //    else
            //    {
            //        throw new System.NotImplementedException();
            //    }
            //}
        }

        public static void RemoveFromStock(StockClass merchandise, int stockToRemove)
        {

            foreach (var item in CurrentStockList)
            {
                
                if (item.ItemName == merchandise.ItemName)
                {
                    if (item.Qty - stockToRemove < 0)
                    {
                        ShowMessage("Not enough items in stock, order more from supplier");
                        break;
                    }
                    else
                    {
                        item.Qty -= stockToRemove;

                    }
                }
            }

            //foreach (var merch in CurrentStockList)
            //{
            //    if (merch.Merchandise.MerchandiseName == merchandise.MerchandiseName)
            //    {
            //        merch.Merchandise.MerchandiseStock -= stockToRemove;
            //    }
            //    else
            //    {
            //        throw new System.NotImplementedException();
            //    }
            //}
        }

        public static void RemoveFromDeliveryList(StockClass merchandise, int stockToRemove)
        {

            foreach (var item in CurrentDeliverysList)
            {

                if (item.ItemName == merchandise.ItemName)
                {
                    item.Qty -= stockToRemove;
                }
            }

            //foreach (var merch in CurrentStockList)
            //{
            //    if (merch.Merchandise.MerchandiseName == merchandise.MerchandiseName)
            //    {
            //        merch.Merchandise.MerchandiseStock -= stockToRemove;
            //    }
            //    else
            //    {
            //        throw new System.NotImplementedException();
            //    }
            //}
        }
        public void CreateOrder(CustomerClass customer, List<StockClass> merch)
        {
            CustomerOrderClass customerOrder = new CustomerOrderClass(customer, merch);
            CustomerOrders.Add(customerOrder);
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

        public static async void ShowMessage(string inputMessage)
        {
            var message = new MessageDialog(inputMessage);
            await message.ShowAsync();
        }
        #endregion

    }
}
