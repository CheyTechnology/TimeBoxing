using MvvmHelpers;
using Sharpnado.Presentation.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TimeBoxingCross.Core;
using TimeBoxingCross.HorizontalListView.Model;
using Xamarin.Forms;

namespace TimeBoxingCross.TabControlView.ViewModel
{
    public class TabControlViewModel : BaseViewModel
    {

        #region constructor

        public TabControlViewModel()
        {

        }

        #endregion

        #region overrides


        #endregion

        #region methods

        private void NewTask(object obj)
        {
            SingleTask task = new SingleTask();
            Mediator.Instance.NotifyColleagues(ViewModelMessages.AddNewTask, task);
        }

        #endregion


        #region properites

        public int SelectedIndex { get; set; }

        #endregion

        #region commands

        private DelegateCommand _newTaskCommand;

        public DelegateCommand NewTaskCommand
        {
            get 
            {
                if (_newTaskCommand == null)
                    _newTaskCommand = new DelegateCommand(NewTask);
                return _newTaskCommand;
            }
        }

       

        #endregion

    }
}
