using GoldStarr_Trading.Classes;
using System;
using System.Collections.ObjectModel;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace GoldStarr_Trading
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    /// 

    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        /// 

        #region Collections
        public ObservableCollection<CustomerClass> Customer { get; set; } //= new ObservableCollection<CustomerClass>();
        public ObservableCollection<StockClass> Stock { get; set; }  //= new ObservableCollection<StockClass>();
        public ObservableCollection<StockClass> IncomingDeliverys { get; set; } //= new ObservableCollection<StockClass>();
        public ObservableCollection<CustomerOrderClass> CustomerOrders { get; set; }  //= new ObservableCollection<CustomerOrderClass>();  
        // ObsColl with orders not ready to fulfill.
        public ObservableCollection<QueuedOrder> QueuedOrders { get; set; }
        #endregion



        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;

            #region OLD
            //Customer.Add(new CustomerClass("Lisa Underwood", "Smallhill 7", "215 70", "Malmö", "+46 0707-123-456"));
            //Customer.Add(new CustomerClass("Olle Bull", "Djäknegatan 13", "215 71", "Malmö", "0707-234-567"));
            //Customer.Add(new CustomerClass("Ben Knota", "Stengränd 11", "215 72", "Malmö", "0707-345 678"));
            //Customer.Add(new CustomerClass("Vilma Hypoxia", "Nicolaigatan 5", "215 73", "Malmö", "0707 456 789"));
            //Customer.Add(new CustomerClass("Ken Barbie", "Dockgatan 3", "215 74", "Malmö", "0707- 567  890"));

            //Stock.Add(new StockClass("HydroSpanner", "Acme AB", 1));
            //Stock.Add(new StockClass("Airscoop", "Acme AB", 2));
            //Stock.Add(new StockClass("Hyper-transceiver", "Corelian Inc", 3));
            //Stock.Add(new StockClass("Nanosporoid", "Corelian Inc", 4));
            //Stock.Add(new StockClass("Boarding-spike", "Joruba Consortium", 5));

            //IncomingDeliverys.Add(new StockClass("HydroSpanner", "Acme AB", 5));
            //IncomingDeliverys.Add(new StockClass("Airscoop", "Acme AB", 4));
            //IncomingDeliverys.Add(new StockClass("Hyper-transceiver", "Corelian Inc", 3));
            //IncomingDeliverys.Add(new StockClass("Nanosporoid", "Corelian Inc", 2));
            //IncomingDeliverys.Add(new StockClass("Boarding-spike", "Joruba Consortium", 1));

            //CustomerOrders = new ObservableCollection<CustomerOrderClass>();
            #endregion
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected async override void OnLaunched(LaunchActivatedEventArgs e)
        {


            Frame rootFrame = Window.Current.Content as Frame;


            if (Customer == null)
            {
                Customer = new ObservableCollection<CustomerClass>();

                DataHelper CustomerHelper = new DataHelper("Customer.json");
                Customer = await CustomerHelper.ReadFromFile<ObservableCollection<CustomerClass>>();

                if (Customer == null)
                {
                    Customer = new ObservableCollection<CustomerClass>()
                    {
                        new CustomerClass("Lisa Underwood", "Smallhill 7", "215 70", "Malmö", "+46 0707-123-456"),
                        new CustomerClass("Olle Bull", "Djäknegatan 13", "215 71", "Malmö", "0707-234-567"),
                        new CustomerClass("Ben Knota", "Stengränd 11", "215 72", "Malmö", "0707-345 678"),
                        new CustomerClass("Vilma Hypoxia", "Nicolaigatan 5", "215 73", "Malmö", "0707 456 789"),
                        new CustomerClass("Ken Barbie", "Dockgatan 3", "215 74", "Malmö", "0707- 567  890")
                    };
                }

                Customer.CollectionChanged += Customer_CollectionChanged;

            }

            Customer.CollectionChanged += Customer_CollectionChanged;



            if (Stock == null)
            {
                Stock = new ObservableCollection<StockClass>();

                DataHelper StockHelper = new DataHelper("Stock.json");
                Stock = await StockHelper.ReadFromFile<ObservableCollection<StockClass>>();

                if (Stock == null)
                {

                    if (Stock == null)
                    {
                        Stock = new ObservableCollection<StockClass>()
                        {
                            new StockClass("HydroSpanner", "Acme AB", 1),
                            new StockClass("Airscoop", "Acme AB", 2),
                            new StockClass("Hyper-transceiver", "Corelian Inc", 3),
                            new StockClass("Nanosporoid", "Corelian Inc", 4),
                            new StockClass("Boarding-spike", "Joruba Consortium", 5)
                        };

                    }

                }

                Stock.CollectionChanged += Stock_CollectionChanged;

            }

            Stock.CollectionChanged += Stock_CollectionChanged;



            if (IncomingDeliverys == null)
            {

                IncomingDeliverys = new ObservableCollection<StockClass>();

                DataHelper IncomingDeliverysHelper = new DataHelper("IncomingDeliverys.json");
                IncomingDeliverys = await IncomingDeliverysHelper.ReadFromFile<ObservableCollection<StockClass>>();

                if (IncomingDeliverys == null)
                {

                    if (IncomingDeliverys == null)
                    {
                        IncomingDeliverys = new ObservableCollection<StockClass>()
                        {
                            new StockClass("HydroSpanner", "Acme AB", 5),
                            new StockClass("Airscoop", "Acme AB", 4),
                            new StockClass("Hyper-transceiver", "Corelian Inc", 3),
                            new StockClass("Nanosporoid", "Corelian Inc", 2),
                            new StockClass("Boarding-spike", "Joruba Consortium", 1)
                        };
                    }
                }

                IncomingDeliverys.CollectionChanged += IncomingDeliverys_CollectionChanged;

            }
            IncomingDeliverys.CollectionChanged += IncomingDeliverys_CollectionChanged;



            if (CustomerOrders == null)
            {
                CustomerOrders = new ObservableCollection<CustomerOrderClass>();

                DataHelper CustomerOrdersHelper = new DataHelper("CustomerOrders.json");
                CustomerOrders = await CustomerOrdersHelper.ReadFromFile<ObservableCollection<CustomerOrderClass>>();

                if (CustomerOrders == null)
                {
                    StockClass order = new StockClass("HydroSpanner", "Acme AB", 1);
                    CustomerClass orderer = new CustomerClass("Lisa Underwood", "Smallhill 7", "215 70", "Malmö", "+46 0707-123-456");

                    CustomerOrders = new ObservableCollection<CustomerOrderClass> { new CustomerOrderClass(orderer, order, DateTime.UtcNow) };

                }

                CustomerOrders.CollectionChanged += CustomerOrders_CollectionChanged;
            }
            CustomerOrders.CollectionChanged += CustomerOrders_CollectionChanged;






            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);
                }
                // Ensure the current window is active
                Window.Current.Activate();
            }
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        /// 








        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }


        #region Methods
        public ObservableCollection<CustomerClass> GetDefaultCustomerList()
        {
            return Customer;
        }

        public ObservableCollection<StockClass> GetDefaultStockList()
        {
            return Stock;
        }

        public ObservableCollection<StockClass> GetDefaultDeliverysList()
        {
            return IncomingDeliverys;
        }

        public ObservableCollection<CustomerOrderClass> GetDefaultCustomerOrdersList()
        {
            return CustomerOrders;
        }

        public async void Customer_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            DataHelper helper = new DataHelper("Customer.json");
            helper.WriteToFile(Customer);
        }

        public async void Stock_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            DataHelper helper = new DataHelper("Stock.json");
            helper.WriteToFile(Stock);
        }

        public async void IncomingDeliverys_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            DataHelper helper = new DataHelper("IncomingDeliverys.json");
            helper.WriteToFile(IncomingDeliverys);
        }

        public async void CustomerOrders_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            DataHelper helper = new DataHelper("CustomerOrders.json");
            helper.WriteToFile(CustomerOrders);
        }
        #endregion






    }
}
