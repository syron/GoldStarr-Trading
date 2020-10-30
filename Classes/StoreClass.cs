using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GoldStarr_Trading.Classes
{
    public class StoreClass
    {
        public List<CustomerClass> Customer { get; set; }

        StockClass stockClass = new StockClass();
        public StoreClass()
        {
            
        }
        

        public void AddToStock(MerchandiseClass merchandise, int stockToAdd)
        {
            foreach (var merch in stockClass.merchandise)
            {
                if (merch.Name == merchandise.Name)
                {
                    merch.Stock += stockToAdd;
                }
                else
                {
                    throw new System.NotImplementedException();
                }
            }
        }

        public void RemoveFromStock(MerchandiseClass merchandise, int stockToRemove)
        {
            foreach (var merch in stockClass.merchandise)
            {
                if (merch.Name == merchandise.Name)
                {
                    merch.Stock -= stockToRemove;
                }
                else
                {
                    throw new System.NotImplementedException();
                }
            }
        }
    }
}
