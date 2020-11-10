using System;
namespace GoldStarr_Trading.Classes
{
    /// <summary>
    /// Class to create a queued (IDK how to spell it, could be right, could be kewewewd as well) order. Stores well in 
    /// </summary>
    public class QueuedOrder : CustomerOrderClass
    {
        private int qID;
        public int QueueID { get { return this.qID; } set { qID = value; base.OnPropertyChanged(); } }
        public QueuedOrder(CustomerClass customerClass, StockClass merchandise, DateTime orderDate, int qID) : base(customerClass, merchandise, orderDate)
        {
            base.Customer = customerClass;
            base.Merchandise = merchandise;
            base.OrderDate = orderDate.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");
            this.qID = qID;
        }

    }
}
