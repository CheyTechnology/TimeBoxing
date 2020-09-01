using System;
using System.Collections.Generic;
using System.Text;

namespace TimeBoxingCross.Core
{
    public enum ViewModelMessages { AddNewTask = 1 };

    public sealed class Mediator
    {

        #region Data

        static readonly Mediator instance = new Mediator();
        private volatile object locker = new object();

        MediatorDictionary<ViewModelMessages, Action<Object>> internalList = new MediatorDictionary<ViewModelMessages, Action<Object>>();

        #endregion

        #region Constructor

        static Mediator()
        {

        }

        private Mediator()
        {

        }

        #endregion

        #region Properties

        public static Mediator Instance
        {
            get { return instance; }
        }

        #endregion

        #region Methods

        public void Register(Action<Object> callback, ViewModelMessages message)
        {
            internalList.AddValue(message, callback);
        }

        public void NotifyColleagues(ViewModelMessages message, object args)
        {
            if(internalList.ContainsKey(message))
            {
                foreach (Action<Object> callback in internalList[message])
                {
                    callback(args);
                }
            }
        }

        #endregion
    }
}
