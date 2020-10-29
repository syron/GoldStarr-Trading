using GoldStarr_Trading.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GoldStarr_Trading
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private StoreClass store;

        public MainPage()
        {
            this.InitializeComponent();

            #region OLD
            //ListView Merchandise = new ListView();
            //Merchandise.Items.Add("Item\t\t\t Supplier\t\t Qty");
            //Merchandise.Items.Add("Hydrospanner\t\t Acme AB\t\t 1");
            //Merchandise.Items.Add("Airscoop\t\t\t Acme AB\t\t 2");
            //Merchandise.Items.Add("Hyper-transceiver\t\t\t Corelian Inc\t\t 3");
            //Merchandise.Items.Add("Nanosporoid\t\t\t Corelian Inc\t\t 4");
            //Merchandise.Items.Add("Boarding-spike\t\t\t Joruba Consortium\t\t 5");

            //// Add the ListView to a parent container in the visual tree (that you created in the corresponding XAML file).
            //MerchandisePanel.Children.Add(Merchandise);

            //ObservableCollection<MerchandiseClass> merchandise = new ObservableCollection<MerchandiseClass>();

            //merchandise.Add(new MerchandiseClass("Hydrospanner", "Acme AB", 1));
            //merchandise.Add(new MerchandiseClass("Airscoop", "Acme AB", 2));
            //merchandise.Add(new MerchandiseClass("Hyper-transceiver", "Acme AB", 3));
            //merchandise.Add(new MerchandiseClass("Nanosporoid", "Acme AB", 4));
            //merchandise.Add(new MerchandiseClass("Boarding-spike", "Acme AB", 5));

            ////ListView merchandiseLV = new ListView();
            ////merchandiseLV.ItemsSource = merchandise;
            ////MerchandisePanel.Children.Add(merchandiseLV);

            ////ObservableCollection<MerchandiseClass> merchandise = new ObservableCollection<MerchandiseClass>();

            //ListView merchandiseLV = new ListView();
            //merchandiseLV.ItemsSource = merchandise;
            //MerchandisePanel.Children.Add(merchandiseLV);


            //MerchandisePanel.Children.Add(MerchandiseClass.merchandiseList);


            //ObservableCollection<MerchandiseClass> merchandise = new ObservableCollection<MerchandiseClass>();


            //public MerchandiseClass[] merchandiseList =
            //{
            //new MerchandiseClass { Name = "Hydrospanner", Supplier = "Acne AB", Stock = 0 },
            //new MerchandiseClass { Name = "Airscoop", Supplier = "Acne AB", Stock = 1 },
            //new MerchandiseClass { Name = "Hyper-transceiver", Supplier = "Corelian Inc", Stock = 2 },
            //new MerchandiseClass { Name = "Nanosporoid", Supplier = "Corelian Inc", Stock = 3 },
            //new MerchandiseClass { Name = "Boarding-spike", Supplier = "Joruba Consortium", Stock = 4 },
            //};

            //    MerchandiseClass newMerch = new MerchandiseClass();


            //    MerchandiseView.ItemsSource = merchandise
            //    ObservableCollection<MerchandiseClass> merchandise = new ObservableCollection<MerchandiseClass>();
            //public ObservableCollection<MerchandiseClass> Merchandise { get { return merchandise; } }

            //CustomerClass customers = new CustomerClass();
            //this.Customers.ItemsSource = customers.Name;
            #endregion

            //List<string> titles = new List<string> { "Mr", "Mrs", "Ms", "Miss" };
            //this.Customers.ItemsSource = titles;

            //    List<CustomerClass> customers =
            //        {
            //    new CustomerClass { Name = "Lisa Underwood", Address = "Smallhill 7",    ZipCode = "215 70", City = "Malmö", Phone = "555-1967" },
            //    new CustomerClass { Name = "Olle Bull",      Address = "Djäknegatan 13", ZipCode = "215 71", City = "Malmö", Phone = "555-0344" },
            //    new CustomerClass { Name = "Ben Knota",      Address = "Stengränd 11",   ZipCode = "215 72", City = "Malmö", Phone = "555-4932" },
            //    new CustomerClass { Name = "Vilma Hypoxia",  Address = "Nikkaluokta",    ZipCode = "215 73", City = "Malmö", Phone = "555-3356" },
            //    new CustomerClass { Name = "Ken Barbie",     Address = "Dockgatan 3",    ZipCode = "215 74", City = "Malmö", Phone = "555-3282" }
            //};

            //CustomerClass newCust = new CustomerClass();

            //List<string> customers = new List<string>();

            //foreach (var item in CustomerClass.customerList)
            //{
            //    customers.Add(item.Name);
            //}

            //this.Customers.ItemsSource = customers;

            store = CreateCustomers();

            Customers.ItemsSource = store.Customers;


        }

        private static StoreClass CreateCustomers()
        {
            StoreClass store = new StoreClass();

            store.AddCustomer(new CustomerClass { Name = "Lisa Underwood", Address = "Smallhill 7",    ZipCode = "215 70", City = "Malmö", Phone = "555-1967" });
            store.AddCustomer(new CustomerClass { Name = "Olle Bull",      Address = "Djäknegatan 13", ZipCode = "215 71", City = "Malmö", Phone = "555-0344" });
            store.AddCustomer(new CustomerClass { Name = "Ben Knota",      Address = "Stengränd 11",   ZipCode = "215 72", City = "Malmö", Phone = "555-4932" });
            store.AddCustomer(new CustomerClass { Name = "Vilma Hypoxia",  Address = "Nikkaluokta",    ZipCode = "215 73", City = "Malmö", Phone = "555-3356" });
            store.AddCustomer(new CustomerClass { Name = "Ken Barbie",     Address = "Dockgatan 3",    ZipCode = "215 74", City = "Malmö", Phone = "555-3282" });

            return store;
        }


    }
}
