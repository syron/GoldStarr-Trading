using GalaSoft.MvvmLight.Command;
using GoldStarr_Trading.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Globalization.DateTimeFormatting;
using Windows.Services.Maps.Guidance;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace GoldStarr_Trading
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        #region Collections Not Used
        //ObservableCollection<CustomerClass> CustomerList { get; set; }
        //ObservableCollection<StockClass> StockList { get; set; }
        //ObservableCollection<CustomerOrderClass> CustomerOrders { get; set; } //= new ObservableCollection<CustomerOrderClass>();

        StoreClass store;
        #endregion

        private App _app { get; set; }

        public MainPage()
        {

            this.InitializeComponent();


            store = new StoreClass();

            _app = (App)App.Current;

            #region OLD
            //DataContext = this;

            //CustomerOrders = new ObservableCollection<CustomerOrderClass>();

            //InStockList.ItemsSource = store.GetCurrentStockList();
            //StockToAddList.ItemsSource = store.GetCurrentDeliverysList();
            //CustomersTabComboBoxCustomerName.ItemsSource = store.GetCurrentCustomerList();
            //CustomerView.ItemsSource = store.GetCurrentCustomerList();
            //CustomerList = new ObservableCollection<CustomerClass>(store.GetCurrentCustomerList());

            //StockList = new ObservableCollection<StockClass>(store.GetCurrentStockList());
            //CustomerOrders = new ObservableCollection<CustomerOrderClass>(store.GetCurrentCustomerOrdersList());
            #endregion

        }


        #region Events

        private void AddOrderContent_Click(object sender, RoutedEventArgs e)
        {
            var parent = (sender as Button).Parent;
            CustomerClass customerOrderer = null;
            StockClass stockOrder = null;


            string orderQuantity = OrderQuantity.Text;
            customerOrderer = (CustomerClass)CreateOrderTabCustomersComboBox.SelectedValue;
            stockOrder = (StockClass)CreateOrderTabItemComboBox.SelectedValue;



            if (customerOrderer == null || stockOrder == null)
            {
                MessageToUser("You must choose a customer and an item");
            }
            else if (orderQuantity == "")
            {

                MessageToUser("You must enter an integer");
            }
            else
            {

                if (int.TryParse(orderQuantity, out int amount) && orderQuantity != "" && stockOrder.Qty - amount >= 0)
                {
                    DateTime orderDate = DateTime.UtcNow;

                    stockOrder.Qty = stockOrder.Qty - amount;
                    StockClass order = new StockClass(stockOrder.ItemName, stockOrder.Supplier, amount);

                    _app.GetDefaultCustomerOrdersList().Add(new CustomerOrderClass(customerOrderer, order, orderDate));

                    //MessageToUser($"You have successfully created a new Customer order for: \n{customerOrderer.CustomerName} with {amount} {stockOrder.ItemName} in it");
                    MessageToUser($"You have successfully created a new Customer order \n\nCustomer: {customerOrderer.CustomerName} \nItem: {order.ItemName} \nAmount: {order.Qty} \nOrderdate: {orderDate.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")}");

                    CreateOrderTabCustomersComboBox.SelectedIndex = -1;
                    CreateOrderTabItemComboBox.SelectedIndex = -1;
                    OrderQuantity.Text = "";

                    #region Code for Release 2
                    //for (int i = 0; i < CustomerOrders.Count; ++i)
                    //{
                    //if (CustomerOrders[i].Customer == customerOrderer)
                    //{
                    //    stockOrder.Qty -= amount;
                    //    StockClass orderToUpdate = new StockClass(stockOrder.ItemName, stockOrder.Supplier, amount);
                    //    CustomerOrders.Add(new CustomerOrderClass(customerOrderer, stockClass));

                    //    //StoreClass.RemoveFromStock(orderToUpdate, amount);

                    //    //MessageToUser($"You have successfully created a new Customer order for: \n{customerOrderer.CustomerName} with {amount} {stockOrder.ItemName} in it");
                    //    MessageToUser($"You have successfully created a new Customer order \n\nCustomer: {customerOrderer.CustomerName} \nItem: {stockOrder.ItemName} \nAmount: {amount}");

                    //    OrderQuantity.Text = "";
                    //}
                    //else
                    //{
                    //stockOrder.Qty -= amount;
                    //StockClass orderToAdd = new StockClass(stockOrder.ItemName, stockOrder.Supplier, amount);
                    //stockClass.Add(orderToAdd);

                    //CustomerOrders.Add(new CustomerOrderClass(customerOrderer, stockClass));

                    ////MessageToUser($"You have successfully created a new Customer order for: \n{customerOrderer.CustomerName} with {amount} {stockOrder.ItemName} in it");
                    //MessageToUser($"You have successfully created a new Customer order \n\nCustomer:{customerOrderer.CustomerName} \nItem: {orderToAdd.ItemName} \nAmount: {orderToAdd.Qty}");

                    //OrderQuantity.Text = "";
                    //break;
                    //}
                    //}
                    #endregion
                }
                else
                {
                    MessageToUser("Not enough items in stock, order more from supplier, or change amount to add");

                    OrderQuantity.Text = "";
                }
            }

            

        }

        private void BtnAddDeliveredMerchandise_Click(object sender, RoutedEventArgs e)
        {
            var parent = (sender as Button).Parent;


            TextBox valueToAdd = parent.GetChildrenOfType<TextBox>().First(x => x.Name == "TxtBoxAddQty");
            TextBlock valueToCheck = parent.GetChildrenOfType<TextBlock>().First(x => x.Name == "QTY");
            TextBlock itemToAdd = parent.GetChildrenOfType<TextBlock>().First(x => x.Name == "ItemName");

            string toConvert = valueToAdd.Text;
            int intValueToAdd = 0;
            int intValueToCheck = Convert.ToInt32(valueToCheck.Text);

            if (int.TryParse(toConvert, out intValueToAdd))
            {
                if (intValueToAdd > intValueToCheck)
                {
                    MessageToUser($"Enter the correct number of stock to submit, maximum number to submit is: {intValueToCheck} ");
                    valueToAdd.Text = "";
                }
                else
                {
                    StockClass merch = null;

                    foreach (var item in _app.GetDefaultStockList())
                    {
                        if (item.ItemName == itemToAdd.Text)
                        {
                            merch = item;
                        }
                    }

                    store.AddToStock(merch, intValueToAdd);
                    MessageToUser($"You have added: {valueToAdd.Text} {itemToAdd.Text} to your stock");
                    valueToAdd.Text = "";
                }
            }
            else
            {
                MessageToUser("You must enter an integer");
            }


            #region For Debug
            Debug.WriteLine(valueToAdd.Text);
            Debug.WriteLine(valueToCheck.Text);
            #endregion

        }

        private void CustomersTabComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string customerName = e.AddedItems[0].ToString();

            //CustomerClass newCustomer = CustomerList.First(x => x.CustomerName == customerName);
            CustomerClass newCustomer = _app.GetDefaultCustomerList().First(x => x.CustomerName == customerName);
            CustomerName.Text = newCustomer.CustomerName;
            CustomerPhoneNumber.Text = newCustomer.CustomerPhone;
            CustomerAddress.Text = newCustomer.CustomerAddress;
            CustomerZipCode.Text = newCustomer.CustomerZipCode;
            CustomerCity.Text = newCustomer.CustomerCity;


            


        }

        private void AddNewCustomersTabComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //string customerName = e.AddedItems[0].ToString();

            //CustomerClass newCustomer = CustomerList.First(x => x.CustomerName == customerName);
            //CustomerName.Text = newCustomer.CustomerName;
            //CustomerPhoneNumber.Text = newCustomer.CustomerPhone;
            //CustomerAddress.Text = newCustomer.CustomerAddress;
            //CustomerZipCode.Text = newCustomer.CustomerZipCode;
            //CustomerCity.Text = newCustomer.CustomerCity;

        }

        private void CustomerAddButton_Click(object sender, RoutedEventArgs e)
        {
            //if (AddNewCustomerName == null || AddNewCustomerPhoneNumber == null || AddNewCustomerAddress == null || AddNewCustomerZipCode == null || AddNewCustomerCity == null)
            //{
            //    CustomerAddButton.IsEnabled = false;
            //}
            //else
            //{
            string name = AddNewCustomerName.Text;
            string phone = AddNewCustomerPhoneNumber.Text;
            string address = AddNewCustomerAddress.Text;
            string zipCode = AddNewCustomerZipCode.Text;
            string city = AddNewCustomerCity.Text;

            MessageToUser($"You have successfully added a new customer to your customer list \n\nCustomer name: {name}");

            _app.GetDefaultCustomerList().Add(new CustomerClass(name, address, zipCode, city, phone));

            AddNewCustomerName.Text = "";
            AddNewCustomerPhoneNumber.Text = "";
            AddNewCustomerAddress.Text = "";
            AddNewCustomerZipCode.Text = "";
            AddNewCustomerCity.Text = "";
            //}


            

        }


        #endregion


        #region Methods

        public static async void MessageToUser(string inputMessage)
        {
            var message = new MessageDialog(inputMessage);
            await message.ShowAsync();
        }

        #region PropertyChangedEventHandler
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #endregion

    }

    #region Help Class
    public static class Extensions
    {
        public static IEnumerable<T> GetChildrenOfType<T>(this DependencyObject start) where T : class
        {
            var queue = new Queue<DependencyObject>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var item = queue.Dequeue();

                var realItem = item as T;
                if (realItem != null)
                {
                    yield return realItem;
                }

                int count = VisualTreeHelper.GetChildrenCount(item);
                for (int i = 0; i < count; i++)
                {
                    queue.Enqueue(VisualTreeHelper.GetChild(item, i));
                }
            }
        }
    }
    #endregion

}
