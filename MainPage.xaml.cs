using GoldStarr_Trading.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace GoldStarr_Trading
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // ObservableCollection Properties

        #region Collections

        private ObservableCollection<CustomerClass> CustomerList { get; set; }
        private ObservableCollection<StockClass> StockList { get; set; }
        private ObservableCollection<CustomerOrderClass> CustomerOrders { get; set; }

        #endregion Collections

        public MainPage()
        {
            this.InitializeComponent();

            DataContext = this;

            StoreClass store = new StoreClass();

            InStockList.ItemsSource = store.GetCurrentStockList();
            StockToAddList.ItemsSource = store.GetCurrentDeliverysList();
            CustomerList = new ObservableCollection<CustomerClass>(store.GetCurrentCustomerList());
            StockList = new ObservableCollection<StockClass>(store.GetCurrentStockList());
            CustomerOrders = new ObservableCollection<CustomerOrderClass>(store.GetCurrentCustomerOrders());
        }

        #region Events

        private void AddOrderContent_Click(object sender, RoutedEventArgs e)
        {
            var parent = (sender as Button).Parent;
            CustomerClass customerOrderer = null;
            StockClass stockOrder = null;
            List<StockClass> stockClass = new List<StockClass>();

            DateTime orderDate = DateTime.UtcNow;

            string orderQuantity = OrderQuantity.Text;
            int.TryParse(orderQuantity, out int amount);

            customerOrderer = (CustomerClass)CreateOrderTabCustomersComboBox.SelectedValue;

            stockOrder = (StockClass)CreateOrderTabItemComboBox.SelectedValue;
            // If customer or merchandise are null
            if (customerOrderer == null || stockOrder == null)
            {
                MessageToUser("You must choose a customer and an item");
            }
            // if orderQuantity is empty
            else if (orderQuantity == "" || orderQuantity == " " ||  amount == 0)
            {
                MessageToUser("You must enter an integer");
            }
            else
            {
                // If orderQuantity is parseable, and orderQuantity isn't empty and stock - amount is larger or equal to zero
                if (orderQuantity != "" && stockOrder.Qty - amount >= 0)
                {
                    // if no orders are present, simply add an order to the collection.
                    if (CustomerOrders.Count == 0)
                    {
                        stockOrder.Qty -= amount;
                        StockClass order = new StockClass(stockOrder.ItemName, stockOrder.Supplier, amount);
                        stockClass.Add(order);

                        CustomerOrders.Add(new CustomerOrderClass(customerOrderer, stockClass, orderDate));

                        MessageToUser($"You have successfully created a new Customer order \n\nCustomer:{customerOrderer.CustomerName} \nItem: {order.ItemName} \nAmount: {order.Qty} \nOrderdate: {orderDate.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")}");
                        
                        CreateOrderTabCustomersComboBox.SelectedIndex = -1;
                        CreateOrderTabItemComboBox.SelectedIndex = -1;
                        OrderQuantity.Text = "";
                    }

                    // Otherwise create a new order object, prepared for future functionality
                    else
                    {
                        stockOrder.Qty -= amount;
                        StockClass orderToAdd = new StockClass(stockOrder.ItemName, stockOrder.Supplier, amount);
                        stockClass.Add(orderToAdd);

                        CustomerOrders.Add(new CustomerOrderClass(customerOrderer, stockClass, orderDate));

                        MessageToUser($"You have successfully created a new Customer order \n\nCustomer:{customerOrderer.CustomerName} \nItem: {orderToAdd.ItemName} \nAmount: {orderToAdd.Qty} \nOrderdate: {orderDate.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss")}");

                        CreateOrderTabCustomersComboBox.SelectedIndex = -1;
                        CreateOrderTabItemComboBox.SelectedIndex = -1;
                        OrderQuantity.Text = "";
                    }
                }
                else
                {
                    MessageToUser("Not enough items in stock, order more from supplier, or change amount to add");

                    OrderQuantity.Text = "";
                }
            }
        }

        // Add item from the Deliveries page to stock.
        private void BtnAddDeliveredMerchandise_Click(object sender, RoutedEventArgs e)
        {
            var parent = (sender as Button).Parent;
            // Get the objects containing data.
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

                    foreach (var item in StockList)
                    {
                        if (item.ItemName == itemToAdd.Text)
                        {
                            merch = item;
                        }
                    }

                    StoreClass.AddToStock(merch, intValueToAdd);
                    MessageToUser($"You have added: {valueToAdd.Text} {itemToAdd.Text} to your stock");
                    valueToAdd.Text = "";
                }
            }
            else
            {
                MessageToUser("You must enter an integer");
            }
        }

        private void CustomersTabComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string customerName = e.AddedItems[0].ToString();

            CustomerClass newCustomer = CustomerList.First(x => x.CustomerName == customerName);
            CustomerName.Text = newCustomer.CustomerName;
            CustomerPhoneNumber.Text = newCustomer.CustomerPhone;
            CustomerAddress.Text = newCustomer.CustomerAddress;
            CustomerZipCode.Text = newCustomer.CustomerZipCode;
            CustomerCity.Text = newCustomer.CustomerCity;
        }

        #endregion Events

        #region Methods

        public static async void MessageToUser(string inputMessage)
        {
            var message = new MessageDialog(inputMessage);
            await message.ShowAsync();
        }

        #endregion Methods
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

    #endregion Help Class
}