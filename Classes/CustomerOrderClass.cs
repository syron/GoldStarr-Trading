using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldStarr_Trading.Classes
{
    class CustomerOrderClass
    {
        public CustomerClass Customer { get; set; }

        public List<MerchandiseClass> Merchandise { get; set; }

        public CustomerOrderClass(CustomerClass customerClass, List<MerchandiseClass> merchandise)
        {
            this.Customer = customerClass;
            this.Merchandise = merchandise;
        }

        public string GetOrder()
        {
            string customerName = Customer.Name;
            string billingAddress = $"{ Customer.Address}\n{Customer.ZipCode}\n{Customer.City}";
            string contactCustomer = Customer.Phone;

            return $"{customerName}\n{billingAddress}\n{contactCustomer}";
        }

        public void AddToOrder()
        {

        }

    }
}
