using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace TimeBoxingCross.HorizontalListView.Model
{
    public class SingleTask : INotifyPropertyChanged
    {

        #region constructor
        public SingleTask()
        {
        }

        #endregion

        #region properties

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private int _sortOrder;
        public int SortOrder
        {
            get { return _sortOrder; }
            set
            {
                if (_sortOrder != value)
                {
                    _sortOrder = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private bool _isFav;
        public bool IsFav
        {
            get { return _isFav; }
            set
            {
                if (_isFav != value)
                {
                    _isFav = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _countDown;
        public string CountDown
        {
            get { return _countDown; }
            set
            {
                if (_countDown != value)
                {
                    _countDown = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #endregion

        #region notifypropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
