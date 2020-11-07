using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Popups;

namespace GoldStarr_Trading.Classes
{
    internal class StoreClass
    {
        #region Collections

        private static ObservableCollection<CustomerClass> CurrentCustomerList = new ObservableCollection<CustomerClass>();
        private static ObservableCollection<CustomerOrderClass> CustomerOrders = new ObservableCollection<CustomerOrderClass>();
        private static ObservableCollection<StockClass> CurrentStockList = new ObservableCollection<StockClass>();
        private static ObservableCollection<StockClass> CurrentDeliverysList = new ObservableCollection<StockClass>();

        private DataSets newDataSet = new DataSets();

        #endregion Collections

        #region Constructors

        public StoreClass()
        {
            CurrentStockList = newDataSet.GetDefaultStockList();
            CurrentCustomerList = newDataSet.GetDefaultCustomerList();
            CurrentDeliverysList = newDataSet.GetDefaultDeliverysList();
            CustomerOrders = new ObservableCollection<CustomerOrderClass>();
        }

        #endregion Constructors

        #region Methods

        #region Not Used Yet

        DateTime orderDate = DateTime.UtcNow;

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
        }

        public void CreateOrder(CustomerClass customer, List<StockClass> merch)
        {
            CustomerOrderClass customerOrder = new CustomerOrderClass(customer, merch, orderDate);
            CustomerOrders.Add(customerOrder);
        }

        #endregion Not Used Yet

        // Remove from incoming deliveries.
        public static void RemoveFromDeliveryList(StockClass merchandise, int stockToRemove)
        {
            foreach (var item in CurrentDeliverysList)
            {
                if (item.ItemName == merchandise.ItemName)
                {
                    item.Qty -= stockToRemove;
                }
            }
        }

        // Add to current stock
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

        public ObservableCollection<CustomerOrderClass> GetCurrentCustomerOrders()
        {
            return CustomerOrders;
        }

        public static async void ShowMessage(string inputMessage)
        {
            var message = new MessageDialog(inputMessage);
            await message.ShowAsync();
        }

        #endregion Methods
    }
}