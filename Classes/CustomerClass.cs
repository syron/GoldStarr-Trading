using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GoldStarr_Trading.Classes
{
    public class CustomerClass : INotifyPropertyChanged
    {
        #region Properties
        private string _customerName;
        public string CustomerName
        {
            get => _customerName;
            set
            {
                if (_customerName != value)
                {
                    _customerName = value;
                    this.OnPropertyChanged();
                }
            }
        }


        private string _customerAddress;
        public string CustomerAddress
        {
            get => _customerAddress;
            set
            {
                if (_customerAddress != value)
                {
                    _customerAddress = value;
                    this.OnPropertyChanged();
                }
            }
        }

        private string _customerZipCode;
        public string CustomerZipCode
        {
            get => _customerZipCode;
            set
            {
                if (_customerZipCode != value)
                {
                    _customerZipCode = value;
                    this.OnPropertyChanged();
                }
            }
        }


        private string _customerCity;
        public string CustomerCity
        {
            get => _customerCity;
            set
            {
                if (_customerCity != value)
                {
                    _customerCity = value;
                    this.OnPropertyChanged();
                }
            }
        }

        private string _customerPhone;
        public string CustomerPhone
        {
            get => _customerPhone;
            set
            {
                if (_customerPhone != value)
                {
                    _customerPhone = value;
                    this.OnPropertyChanged();
                }
            }
        }
        #endregion


        #region Constructors
        public CustomerClass(string name, string address, string zipCode, string city, string phone)
        {
            CustomerName = name;
            CustomerAddress = address;
            CustomerZipCode = zipCode;
            CustomerCity = city;
            CustomerPhone = phone;
            
        }
        #endregion


        #region Methods
        public void GetCustomerInfo()

        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return CustomerName;
        }

        #region PropertyChangedEventHandler
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion

        #endregion

    }
}



