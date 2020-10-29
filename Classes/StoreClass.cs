using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldStarr_Trading.Classes
{
    class StoreClass
    {
        public List<CustomerOrder> CustomerOrder
        {
            get => default;
            set
            {
            }
        }

        public StockClass Stock
        {
            get => default;
            set
            {
            }
        }

        public void AddToStock()
        {
            throw new System.NotImplementedException();
        }

        public void RemoveFromStock()
        {
            throw new System.NotImplementedException();
        }
    }
}
