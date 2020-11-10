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
        #region Properties
        private App _app { get; set; }
        #endregion

        #region Constructors
        public StoreClass()
        {
            _app = (App)App.Current;
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
                        _app.GetDefaultStockList().CollectionChanged += _app.Stock_CollectionChanged;
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
            _app.GetDefaultCustomerOrdersList().CollectionChanged += _app.CustomerOrders_CollectionChanged;
        }
        #endregion


        public void RemoveFromDeliveryList(StockClass merchandise, int stockToRemove)
        {
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

            foreach(var item in _app.GetDefaultStockList())
            {
                if (item.ItemName == merchandise.ItemName)
                {
                    item.Qty += stockToAdd;
                    RemoveFromDeliveryList(merchandise, stockToRemove);
                }
            }

        }

        public static async void ShowMessage(string inputMessage)
        {
            var message = new MessageDialog(inputMessage);
            await message.ShowAsync();
        }
        #endregion

    }
}
