using System.Collections.Generic;

namespace GoldStarr_Trading.Classes
{
    internal class CustomerOrderClass
    {
        #region Collections

        public CustomerClass Customer { get; set; }

        public List<StockClass> Merchandise { get; set; }

        #endregion Collections

        #region Constructors

        public CustomerOrderClass(CustomerClass customerClass, List<StockClass> merchandise)
        {
            this.Customer = customerClass;
            this.Merchandise = merchandise;
        }

        #endregion Constructors
    }
}