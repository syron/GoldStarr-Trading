using GalaSoft.MvvmLight.Command;
using GoldStarr_Trading.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
<<<<<<< HEAD
using Windows.Services.Maps.Guidance;
using Windows.UI.Core;
=======
>>>>>>> 53e06a32b9276ae3892417c119585976ed6bbfc0
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
    public sealed partial class MainPage : Page
    {
        public ICommand AddButtonCommand { get; set; }

        public MainPage()
        {
            this.InitializeComponent();

            StoreClass store = new StoreClass();

            PopulateCustomerComboBox(store);

            this.AddButtonCommand = new RelayCommand(this.AddButtonCommandExecute);


        }

        private async void AddButtonCommandExecute()
        {
<<<<<<< HEAD
        //    var message = new MessageDialog("Hahha");
          //  message.ShowAsync();
=======
            var dialog = new MessageDialog("Hi!");
            await dialog.ShowAsync();
>>>>>>> 53e06a32b9276ae3892417c119585976ed6bbfc0
        }

        private void PopulateCustomerComboBox(StoreClass store)
        {
            List<string> customers = new List<string>();


            foreach (var item in store.Customer)
            {
                customers.Add(item.Name);
            }

            this.Customers.ItemsSource = customers;
            this.StockTabCustomersComboBox.ItemsSource = customers;
            InStockList.ItemsSource = store.Stock;
        }

        private async void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var message = new MessageDialog($"");
            await message.ShowAsync();
        }

        //public myViewModel()

        //{
        //    this.AddButtonCommand = new RelayCommand(this.AddButtonCommandExecute);
        //}

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
