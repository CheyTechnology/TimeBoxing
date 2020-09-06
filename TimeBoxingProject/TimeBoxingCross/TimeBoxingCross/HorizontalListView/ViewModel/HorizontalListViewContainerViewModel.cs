using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using TimeBoxingCross.Core;
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

            Mediator.Instance.Register(
                (Object o) =>
                {
                    AddTask(o as SingleTask);
                }, ViewModelMessages.AddNewTask);

            TaskCollection = new ObservableCollection<SingleTask>() { new SingleTask() { Name = "Project Appdesign"}, new SingleTask() { Name = "Workout" }, new SingleTask() { Name = "Something else" }, new SingleTask() { Name = "Dinner" }, new SingleTask() { Name = "Videoediting" } };
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

        private string _day;
        public string Day
        {
            get { return _day; }
            set
            {
                if (_day != value)
                {
                    _day = value;
                    OnPropertyChanged(nameof(Day));
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


        public void AddTask(SingleTask task)
        {
            if (task != null)
            {
                if (TaskCollection == null)
                    TaskCollection = new ObservableCollection<SingleTask>();
                task.SortOrder = TaskCollection.Count;
                task.Name = "New Task " + task.SortOrder;
                TaskCollection.Add(task);
            }
        }

        public void RemoveTask(object task)
        {
            if(task != null && task is SingleTask singleTask)
            {
                if(TaskCollection != null && TaskCollection.Contains(singleTask))
                {
                    TaskCollection.Remove(singleTask);
                }
            }
        }

        private void MarkTaskFav(object parameter)
        {
            if(parameter != null && parameter is SingleTask singleTask)
            {
                singleTask.IsFav = !singleTask.IsFav;
            }
        }

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

        private DelegateCommand _removeTaskCommand;

        public DelegateCommand RemoveTaskCommand
        {
            get
            {
                if (_removeTaskCommand == null)
                    _removeTaskCommand = new DelegateCommand( (parameter) => { RemoveTask(parameter); });
                return _removeTaskCommand;
            }
        }

        private DelegateCommand _markTaskFavCommand;

        public DelegateCommand MarkTaskFavCommand
        {
            get
            {
                if (_markTaskFavCommand == null)
                    _markTaskFavCommand = new DelegateCommand((parameter) => { MarkTaskFav(parameter); });
                return _markTaskFavCommand;
            }
        }


        #endregion

    }
}
