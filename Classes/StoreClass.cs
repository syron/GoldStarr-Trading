using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldStarr_Trading.Classes
{
    class StoreClass
    {
        public List<CustomerClass> Customers { get; set; }

        public StoreClass()
        {
            Customers = new List<CustomerClass>();
        }

        public void AddCustomer(CustomerClass customer)
        {
            Customers.Add(customer);
        }
    }
}
