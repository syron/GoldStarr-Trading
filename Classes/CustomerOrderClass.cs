using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GoldStarr_Trading.Classes
{
    class CustomerOrderClass : INotifyPropertyChanged
    {
        #region Collections
        public CustomerClass Customer { get; set; }

        public List<MerchandiseClass> Merchandise { get; set; }
        #endregion


        #region Constructors
        public CustomerOrderClass(CustomerClass customerClass, List<MerchandiseClass> merchandise)
        {
            this.Customer = customerClass;
            this.Merchandise = merchandise;
        }

        #endregion


        #region Methods
        public string GetOrder()
        {
            string customerName = Customer.CustomerName;
            string billingAddress = $"{ Customer.CustomerAddress}\n{Customer.CustomerZipCode}\n{Customer.CustomerCity}";
            string contactCustomer = Customer.CustomerPhone;

            return $"{customerName}\n{billingAddress}\n{contactCustomer}";
        }

        public void AddToOrder()
        {

        }

        #region PropertyChangedEventHandler
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion

        #endregion

    }
}
