using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GoldStarr_Trading.Classes
{
    internal class StockClass : INotifyPropertyChanged
    {
        // Properties with onProperyChanged called after changes.
        #region Properties
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

        #endregion Properties

        #region Constructors

        public StockClass(string itemName, string supplier, int qty)
        {
            ItemName = itemName;
            Supplier = supplier;
            Qty = qty;
        }

        #endregion Constructors

        // Implementation of INotifyPropertyChanged
        #region PropertyChangedEventHandler

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        #endregion PropertyChangedEventHandler
    }
}