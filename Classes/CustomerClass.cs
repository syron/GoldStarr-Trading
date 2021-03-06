﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GoldStarr_Trading.Classes
{
    public class CustomerClass : INotifyPropertyChanged
    {
        // Properties with onProperyChanged called after changes.

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

        #endregion Properties

        #region Constructors

        public CustomerClass(string name, string address, string zipCode, string city, string phone)
        {
            CustomerName = name;
            CustomerAddress = address;
            CustomerZipCode = zipCode;
            CustomerCity = city;
            CustomerPhone = phone;
        }

        #endregion Constructors

        #region Methods

        public override string ToString()   //Used in main
        {
            return CustomerName;
        }

        #region PropertyChangedEventHandler

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        #endregion PropertyChangedEventHandler

        #endregion Methods
    }
}