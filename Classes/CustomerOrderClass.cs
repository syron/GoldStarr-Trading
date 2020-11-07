using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GoldStarr_Trading.Classes
{
    internal class CustomerOrderClass
    {
        #region Collections and Properties

        public CustomerClass Customer { get; set; }

        public List<StockClass> Merchandise { get; set; }

        private string OrderDate { get; set; }

        #endregion Collections

        #region Constructors

        public CustomerOrderClass(CustomerClass customerClass, List<StockClass> merchandise, DateTime orderDate)
        {
            this.Customer = customerClass;
            this.Merchandise = merchandise;
            this.OrderDate = orderDate.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");
        }

        #endregion Constructors
    }
}