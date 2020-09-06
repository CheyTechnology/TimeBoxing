using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace TimeBoxingCross
{
    public class MainPageViewModel : BaseViewModel
    {

        #region constructor
        public MainPageViewModel()
        {
            InstanceTimer();
        }

        #endregion


        #region Methods

        public void InstanceTimer()
        {
            DateToday = DateTime.Today.ToShortDateString();
            DateTomorrow = DateTime.Today.AddDays(1).ToShortDateString();
            Timer = new Timer();
            Timer.Elapsed += TimerElapsed;
            Timer.AutoReset = true;
            Timer.Interval = 5000 * 60;
            Timer.Start();
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            DateToday = DateTime.Today.ToShortDateString();
            DateTomorrow = DateTime.Today.AddDays(1).ToShortDateString();
        }

        #endregion


        #region properties

        private string _dateToday;
        public string DateToday
        {
            get { return _dateToday; }
            set
            {
                if (_dateToday != value)
                {
                    _dateToday = value;
                    OnPropertyChanged(nameof(DateToday));
                }
            }
        }

        private string _dateTomorrow;
        public string DateTomorrow
        {
            get { return _dateTomorrow; }
            set
            {
                if (_dateTomorrow != value)
                {
                    _dateTomorrow = value;
                    OnPropertyChanged(nameof(DateTomorrow));
                }
            }
        }

        private Timer _timer;
        public Timer Timer
        {
            get { return _timer; }
            set
            {
                if(_timer != value)
                {
                    _timer = value;
                    OnPropertyChanged(nameof(Timer));
                }
            }
        }


        #endregion

    }
}
