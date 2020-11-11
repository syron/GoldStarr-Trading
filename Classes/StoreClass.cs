using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using Windows.Networking.Vpn;
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
        /// <summary>
        /// Overload to create a queued order.
        /// </summary>
        /// <param name="customer">A customer object, preferably of the customer who placed the order.</param>
        /// <param name="merch">The merchandise to be shipped</param>
        /// <param name="queueID">What place in line to place the order, generate from querying the ObsColl</param>
        public void CreateOrder(CustomerClass customer, StockClass merch, int amount, int queueID)
        {
            // Define CultureInfo
            CultureInfo cultureInfo = new CultureInfo("sv-SV");
            DateTime dateTimeOfOrder = DateTime.Now;

            QueuedOrder order = new QueuedOrder(customer, new StockClass(merch.ItemName, merch.Supplier, amount), dateTimeOfOrder, queueID);
            _app.QueuedOrders.Add(order);
        }

        public void RemoveFromDeliveryList(StockClass merchandise, int stockToRemove)
        {
            foreach (var item in _app.GetDefaultDeliverysList())
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

            foreach (var item in _app.GetDefaultStockList())
            {
                if (item.ItemName == merchandise.ItemName)
                {
                    item.Qty += stockToAdd;
                    RemoveFromDeliveryList(merchandise, stockToRemove);
                }
            }

        }
        public void TrySendQO()
        {
            foreach (var item in _app.QueuedOrders)
            {
                try
                {
                    SendOrder(item);
                }
                catch (Exception ex)
                {

                    ShowMessage(ex.ToString());
                }
            }
        }
        /// <summary>
        /// Method to send a queued order
        /// </summary>
        /// <param name="queuedOrder">Object of a queued order</param>
        public void SendOrder(QueuedOrder queuedOrder)
        {
            var product = FindProduct(queuedOrder.Merchandise.ItemName);
            if (product.Qty - queuedOrder.Merchandise.Qty >= 0)
            {
                RemoveFromStock(product, queuedOrder.Merchandise.Qty);
                // Remove from collection, the collection starts at 0
                // but IDs at 1 so ID - 1 gets you the correct number
                _app.QueuedOrders.RemoveAt(queuedOrder.QueueID - 1);
                // Update the remaining objects with a new qID
                foreach (var item in _app.QueuedOrders)
                {
                    if (item.QueueID > 1) { item.QueueID -= 1; }
                    else { continue; }
                }
            }
            else
            {
                throw new Exception("Not enough items in stock");
            }

        }

        private StockClass FindProduct(string merchName)
        {
            StockClass stock = null;
            foreach (var item in _app.Stock)
            {
                if (item.ItemName == merchName)
                {
                    stock = item;
                }
            }
            return stock;
        }
        /// <summary>
        /// Locate a queued order
        /// </summary>
        /// <param name="name">Name of customer</param>
        /// <returns></returns>
        public QueuedOrder FindQueued(string name)
        {
            QueuedOrder queuedOrder = null;
            foreach (var item in _app.QueuedOrders)
            {
                if (item.Customer.CustomerName == name)
                {
                    queuedOrder = item;
                }
            }
            return queuedOrder;
        }
        public static async void ShowMessage(string inputMessage)
        {
            var message = new MessageDialog(inputMessage);
            await message.ShowAsync();
        }
        #endregion

    }
}
