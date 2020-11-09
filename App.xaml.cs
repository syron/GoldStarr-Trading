using GoldStarr_Trading.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
        private ObservableCollection<CustomerClass> Customer = new ObservableCollection<CustomerClass>();
        private ObservableCollection<StockClass> Stock = new ObservableCollection<StockClass>();
        private ObservableCollection<StockClass> IncomingDeliverys = new ObservableCollection<StockClass>();
        private ObservableCollection<CustomerOrderClass> CustomerOrders = new ObservableCollection<CustomerOrderClass>();
        #endregion



        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;


            Customer.Add(new CustomerClass("Lisa Underwood", "Smallhill 7", "215 70", "Malmö", "+46 0707-123-456"));
            Customer.Add(new CustomerClass("Olle Bull", "Djäknegatan 13", "215 71", "Malmö", "0707-234-567"));
            Customer.Add(new CustomerClass("Ben Knota", "Stengränd 11", "215 72", "Malmö", "0707-345 678"));
            Customer.Add(new CustomerClass("Vilma Hypoxia", "Nicolaigatan 5", "215 73", "Malmö", "0707 456 789"));
            Customer.Add(new CustomerClass("Ken Barbie", "Dockgatan 3", "215 74", "Malmö", "0707- 567  890"));

            Stock.Add(new StockClass("HydroSpanner", "Acme AB", 1));
            Stock.Add(new StockClass("Airscoop", "Acme AB", 2));
            Stock.Add(new StockClass("Hyper-transceiver", "Corelian Inc", 3));
            Stock.Add(new StockClass("Nanosporoid", "Corelian Inc", 4));
            Stock.Add(new StockClass("Boarding-spike", "Joruba Consortium", 5));

            IncomingDeliverys.Add(new StockClass("HydroSpanner", "Acme AB", 5));
            IncomingDeliverys.Add(new StockClass("Airscoop", "Acme AB", 4));
            IncomingDeliverys.Add(new StockClass("Hyper-transceiver", "Corelian Inc", 3));
            IncomingDeliverys.Add(new StockClass("Nanosporoid", "Corelian Inc", 2));
            IncomingDeliverys.Add(new StockClass("Boarding-spike", "Joruba Consortium", 1));

            CustomerOrders = new ObservableCollection<CustomerOrderClass>();

        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

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
        #endregion






    }
}
