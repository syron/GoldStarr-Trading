using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldStarr_Trading.Classes
{
    class DataSets
    {
        #region Collections
        private ObservableCollection<CustomerClass> Customer = new ObservableCollection<CustomerClass>();
        private ObservableCollection<StockClass> Stock = new ObservableCollection<StockClass>();
        private ObservableCollection<StockClass> IncomingDeliverys = new ObservableCollection<StockClass>();
        private ObservableCollection<CustomerOrderClass> CustomerOrders = new ObservableCollection<CustomerOrderClass>();
        #endregion

        
        #region Constructors
        public DataSets()
        {
            Customer.Add(new CustomerClass("Lisa Underwood", "Smallhill 7", "215 70", "Malmö", "555-1967"));
            Customer.Add(new CustomerClass("Olle Bull", "Djäknegatan 13", "215 71", "Malmö", "555-0344"));
            Customer.Add(new CustomerClass("Ben Knota", "Stengränd 11", "215 72", "Malmö", "555-4932"));
            Customer.Add(new CustomerClass("Vilma Hypoxia", "Nicolaigatan 5", "215 73", "Malmö", "555-3356"));
            Customer.Add(new CustomerClass("Ken Barbie", "Dockgatan 3", "215 74", "Malmö", "555-3282"));

            Stock.Add(new StockClass("HydroSpanner", "Acme AB", 1));
            Stock.Add(new StockClass("Airscoop", "Acme AB", 2));
            Stock.Add(new StockClass("Hyper-transceiver", "Corelian Inc", 3));
            Stock.Add(new StockClass("Nanosporoid", "Corelian Inc", 4));
            Stock.Add(new StockClass("Boarding-spike", "Joruba Consortium", 5));

            IncomingDeliverys.Add(new StockClass("HydroSpanner", "Acme AB", 2));
            IncomingDeliverys.Add(new StockClass("Airscoop", "Acme AB", 4));
            IncomingDeliverys.Add(new StockClass("Hyper-transceiver", "Corelian Inc", 3));
            IncomingDeliverys.Add(new StockClass("Nanosporoid", "Corelian Inc", 8));
            IncomingDeliverys.Add(new StockClass("Boarding-spike", "Joruba Consortium", 5));
        }
        #endregion


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
        #endregion

    }
}
