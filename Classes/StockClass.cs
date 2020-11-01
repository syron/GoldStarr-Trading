using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GoldStarr_Trading.Classes
{
    class StockClass : INotifyPropertyChanged
    {
        #region Collections
        private List<MerchandiseClass> merchandise = new List<MerchandiseClass>();
        #endregion


        #region Properties

        public MerchandiseClass Merchandise
        {
            get => default;
            set
            {
            }
        }

        private string _itemName;
        public string ItemName
        {
            get => _itemName;
            set
            {
                if (_itemName != value)
                {
                    _itemName = value;
                    this.OnPropertyChanged();
                }
            }
        }

        private string _supplier;
        public string Supplier
        {
            get => _supplier;
            set
            {
                if (_supplier != value)
                {
                    _supplier = value;
                    this.OnPropertyChanged();
                }
            }
        }


        private int _qty;
        public int Qty
        {
            get => _qty;
            set
            {
                if (_qty != value)
                {
                    _qty = value;
                    this.OnPropertyChanged();
                }
            }
        }

        #endregion


        #region Constructors
        public StockClass()
        {

        }
        public StockClass(string itemName, string supplier, int qty)
        {
            ItemName = itemName;
            Supplier = supplier;
            Qty = qty;
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
