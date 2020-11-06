﻿using System;
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

        public List<StockClass> Merchandise { get; set; }
        #endregion


        #region Constructors
        public CustomerOrderClass(CustomerClass customerClass, List<StockClass> merchandise)
        {
            this.Customer = customerClass;
            this.Merchandise = merchandise;
        }

        #endregion


        #region Methods

        #region PropertyChangedEventHandler
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion

        #endregion

    }
}
