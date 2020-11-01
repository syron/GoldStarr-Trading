using GalaSoft.MvvmLight.Command;
using GoldStarr_Trading.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
        public ICommand AddButtonCommand { get; set; }

        List<CustomerClass> CustomerList { get; set; }  //= new List<CustomerClass>();
        List<StockClass> StockList { get; set; }
        //public ObservableCollection<CustomerClass> CustomerList;

        public MainPage()
        {

            this.InitializeComponent();

            DataContext = this;

            StoreClass store = new StoreClass();

            InStockList.ItemsSource = store.GetCurrentStockList();
            StockToAddList.ItemsSource = store.GetCurrentDeliverysList();
            #region OLD            
            //this.CreateOrderTabCustomersComboBox.ItemsSource = store.GetCurrentStockList();
            //InStockList.ItemsSource = dataSets.GetDefaultStockList();
            //StockToAddList.ItemsSource = dataSets.GetDefaultDeliverysList();

            //CustomerList = store.GetCurrentCustomerList();
            //CustomerList = dataSets.GetDefaultCustomerList();
            #endregion
            CustomerList = new List<CustomerClass>(store.GetCurrentCustomerList());
            StockList = new List<StockClass>(store.GetCurrentStockList());


            #region OLD
            //PopulateCustomerComboBox(store);
            //PopulateCreateOrderComboBox(store);
            #endregion


        }

        

        #region OLD
        //private void PopulateCustomerComboBox(StoreClass store)
        //{
        //    List<string> customers = new List<string>();


        //    foreach (var item in store.Customer)
        //    {
        //        customers.Add(item.Name);
        //    }

        //    //DataContext = customers;

        //    this.CustomersTabComboBox.ItemsSource = customers;
        //    this.CreateOrderTabCustomersComboBox.ItemsSource = customers;
        //}

        //private void PopulateCreateOrderComboBox(StoreClass store)
        //{
        //    List<string> merchandise = new List<string>();


        //    foreach (var item in store.Stock)
        //    {
        //        merchandise.Add(item.ItemName);
        //    }

        //    this.CreateOrderTabItemComboBox.ItemsSource = merchandise;
        //}
        #endregion



        private async void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var message = new MessageDialog(DataContextProperty.ToString());

            await message.ShowAsync();
        }
        private async void CustomersTabComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string customerName = e.AddedItems[0].ToString();



            switch (customerName)
            {
                case "Lisa Underwood":
                    //var message = new MessageDialog(DataContextProperty.ToString());
                    var message = new MessageDialog("CustomersTab ComboBox Changed");
                    await message.ShowAsync();
                    break;
            }

            NotifyPropertyChanged();
        }

        private async void CreateOrderTabCustomersComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string customerName = e.AddedItems[0].ToString();

            switch (customerName)
            {
                case "Lisa Underwood":
                    //var message = new MessageDialog(DataContextProperty.ToString());
                    var message = new MessageDialog("CreateOrders Tab ComboBox Changed");
                    await message.ShowAsync();
                    break;
               }
        }

        private void CreateOrderTabItemComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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


        //private static StoreClass CreateCustomers()
        //{
        //    StoreClass store = new StoreClass();

        //    store.AddCustomer(new CustomerClass { Name = "Lisa Underwood", Address = "Smallhill 7",    ZipCode = "215 70", City = "Malmö", Phone = "555-1967" });
        //    store.AddCustomer(new CustomerClass { Name = "Olle Bull",      Address = "Djäknegatan 13", ZipCode = "215 71", City = "Malmö", Phone = "555-0344" });
        //    store.AddCustomer(new CustomerClass { Name = "Ben Knota",      Address = "Stengränd 11",   ZipCode = "215 72", City = "Malmö", Phone = "555-4932" });
        //    store.AddCustomer(new CustomerClass { Name = "Vilma Hypoxia",  Address = "Nikkaluokta",    ZipCode = "215 73", City = "Malmö", Phone = "555-3356" });
        //    store.AddCustomer(new CustomerClass { Name = "Ken Barbie",     Address = "Dockgatan 3",    ZipCode = "215 74", City = "Malmö", Phone = "555-3282" });

        //    return store;
        //}


    }
}
