using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TimeBoxingCross.HorizontalListView.Model;

namespace TimeBoxingCross.HorizontalListView.ViewModel
{
    public class HorizontalListViewContainerViewModel : BaseViewModel
    {

        #region constructor


        public HorizontalListViewContainerViewModel()
        {
            TaskCollection = new ObservableCollection<SingleTask>() { new SingleTask() { Name = "Tst" }, new SingleTask() { Name = "Tst2" }, new SingleTask() { Name = "Tst3" }, new SingleTask() { Name = "Tst4" }, new SingleTask() { Name = "Tst5" } };
        }

        #endregion 



        #region properties

        private ObservableCollection<SingleTask> _taskCollection;
        public ObservableCollection<SingleTask> TaskCollection
        {
            get { return _taskCollection; }
            set
            {
                if(_taskCollection != value)
                {
                    _taskCollection = value;
                    OnPropertyChanged(nameof(TaskCollection));
                }
            }
        }


        #endregion

        #region methods

        


        #endregion

        #region commands
        #endregion

    }
}
