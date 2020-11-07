using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
        //private static ObservableCollection<CustomerClass> CurrentCustomerList { get; set; } //= new ObservableCollection<CustomerClass>();
        //private static ObservableCollection<CustomerOrderClass> CustomerOrders { get; set; } //= new ObservableCollection<CustomerOrderClass>();
        //private static ObservableCollection<StockClass> CurrentStockList { get; set; } //= new ObservableCollection<StockClass>();
        //private static ObservableCollection<StockClass> CurrentDeliverysList { get; set; } //= new ObservableCollection<StockClass>();
        private App _app { get; set; }
        

        #endregion


        #region Constructors
        public StoreClass()
        {
            _app = (App)App.Current;
            //CurrentStockList = _app.GetDefaultStockList();
            //CurrentCustomerList = _app.GetDefaultCustomerList();
            //CurrentDeliverysList = _app.GetDefaultDeliverysList();
            //CustomerOrders = _app.GetDefaultCustomerOrdersList();

        }
        #endregion


        #region Methods


        #region  Not Used Yet
        public void RemoveFromStock(StockClass merchandise, int stockToRemove)
        {

            foreach (var item in _app.GetDefaultStockList())
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

        public void CreateOrder(CustomerClass customer, StockClass merch)
        {
            CultureInfo myCultureInfo = new CultureInfo("sv-SV");
            DateTime orderDate = DateTime.Now;

            CustomerOrderClass customerOrder = new CustomerOrderClass(customer, merch, orderDate);
            _app.GetDefaultCustomerOrdersList().Add(customerOrder);
            //CustomerOrders.Add(customerOrder);
        }
        #endregion


        public void RemoveFromDeliveryList(StockClass merchandise, int stockToRemove)
        {
            //App _app = new App();
            //_app = (App)App.Current;

            //foreach (var item in CurrentDeliverysList)
            foreach(var item in _app.GetDefaultDeliverysList())
            {

                if (item.ItemName == merchandise.ItemName)
                {
                    item.Qty -= stockToRemove;
                }
            }

        }

        public void AddToStock(StockClass merchandise, int stockToAdd)
        {
            int stockToRemove = stockToAdd;

            //foreach (var item in CurrentStockList)
            foreach(var item in _app.GetDefaultStockList())
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
            //_app = (App)App.Current;
            return _app.GetDefaultCustomerList();
            //return CurrentCustomerList;
        }

        public ObservableCollection<StockClass> GetCurrentStockList()
        {
            //_app = (App)App.Current;
            return _app.GetDefaultStockList();
            //return CurrentStockList;
        }

        public ObservableCollection<StockClass> GetCurrentDeliverysList()
        {
            //_app = (App)App.Current;
            return _app.GetDefaultDeliverysList();
            //return CurrentDeliverysList;
        }
        public ObservableCollection<CustomerOrderClass> GetCurrentCustomerOrdersList()
        {
            //_app = (App)App.Current;
            return _app.GetDefaultCustomerOrdersList();
            //return CustomerOrders;
        }

        public static async void ShowMessage(string inputMessage)
        {
            var message = new MessageDialog(inputMessage);
            await message.ShowAsync();
        }
        #endregion

    }
}
