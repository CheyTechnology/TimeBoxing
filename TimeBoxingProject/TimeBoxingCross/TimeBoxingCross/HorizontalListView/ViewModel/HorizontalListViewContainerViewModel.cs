using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using TimeBoxingCross.HorizontalListView.Model;
using TimeBoxingDataLayer;

namespace TimeBoxingCross.HorizontalListView.ViewModel
{
    public class HorizontalListViewContainerViewModel : BaseViewModel
    {

        #region constructor


        public HorizontalListViewContainerViewModel()
        {
            //HandleStaticInstances();
            //GetTaskCollection();

            TaskCollection = new ObservableCollection<SingleTask>() { new SingleTask() { Name = "Tst" }, new SingleTask() { Name = "Tst2" }, new SingleTask() { Name = "Tst3" }, new SingleTask() { Name = "Tst4" }, new SingleTask() { Name = "Tst5" } };
        }

        #endregion 



        #region properties

        private IList<SingleTask> _taskCollection;
        public IList<SingleTask> TaskCollection
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

        private string _filePath;
        public string FilePath
        {
            get { return _filePath; }
            set
            {
                if(_filePath != value)
                {
                    _filePath = value;
                    OnPropertyChanged(nameof(FilePath));
                }
            }
        }

        private HandleData _handleDatainstance;
        public HandleData HandleDataInstance
        {
            get { return _handleDatainstance; }
            set
            {
                if(_handleDatainstance != value)
                {
                    _handleDatainstance = value;
                    OnPropertyChanged(nameof(HandleDataInstance));
                }
            }
        }


        #endregion

        #region methods

        public void GetTaskCollection()
        {
            try
            {
                IList<SingleTask> t = null;
                HandleDataInstance.GetData<IList<SingleTask>>(out t);

                if (t != null)
                    TaskCollection = t;
            }
            catch (Exception ex)
            {
                throw ex;
            }          
        }

        public void HandleStaticInstances()
        {
            FilePath = App.FilePath;
            HandleDataInstance = new HandleData(FilePath);

        }


        #endregion

        #region commands
        #endregion

    }
}
