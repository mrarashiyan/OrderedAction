using System;
using System.Collections.Generic;
using UnityEngine;

namespace Reza.OrderedAction.Scripts
{
    [System.Serializable]
    public class OrderedAction
    {
        [SerializeField] private List<SingleAction> m_Queue;

        public OrderedAction()
        {
            m_Queue = new List<SingleAction>();
        }

        /// <summary>
        /// Register a new Action
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        private string Register(SingleAction action)
        {
            m_Queue.Add(action);
            ReorderQueue();
            return action.GetId();
        }

        /// <summary>
        /// Register a new action
        /// </summary>
        /// <param name="action">Action that you want to call</param>
        /// <param name="order">a number that shows order of call in registered action array</param>
        /// <param name="title">a title that you want to use in debugging</param>
        /// <returns></returns>
        public string Register(Action action, int order = 0, string title = "")
        {
            return Register(new SingleAction().Register(action, order, title));
        }

        public string Register<T1>(Action<T1> action, int order = 0, string title = "")
        {
            return Register(new SingleAction().Register(action, order, title));
        }

        public string Register<T1, T2>(Action<T1, T2> action, int order = 0, string title = "")
        {
            return Register(new SingleAction().Register(action, order, title));
        }

        public string Register<T1, T2, T3>(Action<T1, T2, T3> action, int order = 0, string title = "")
        {
            return Register(new SingleAction().Register(action, order, title));
        }


        public string Register<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action, int order = 0, string title = "")
        {
            return Register(new SingleAction().Register(action, order, title));
        }

        public string Register<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> action, int order = 0, string title = "")
        {
            return Register(new SingleAction().Register(action, order, title));
        }

        /// <summary>
        /// Remove an Action from the Call list
        /// </summary>
        /// <param name="action">Action that you want to remove</param>
        /// <returns></returns>
        public void Unregister(Action action)
        {
            var ac = new ActionContainer(action);
            Unregister(ac);
        }

        public void Unregister<T1>(Action<T1> action)
        {
            var ac = new ActionContainer(action);
            Unregister(ac);
        }

        public void Unregister<T1, T2>(Action<T1, T2> action)
        {
            var ac = new ActionContainer(action);
            Unregister(ac);
        }

        public void Unregister<T1, T2, T3>(Action<T1, T2, T3> action)
        {
            var ac = new ActionContainer(action);
            Unregister(ac);
        }

        public void Unregister<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action)
        {
            var ac = new ActionContainer(action);
            Unregister(ac);
        }

        public void Unregister<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> action)
        {
            var ac = new ActionContainer(action);
            Unregister(ac);
        }

        public void Unregister(string id)
        {
            m_Queue.RemoveAll(x => x.GetId() == id);
            ReorderQueue();
        }

        public void Unregister(int order)
        {
            m_Queue.RemoveAll(x => x.order == order);
            ReorderQueue();
        }

        public void Unregister(List<string> idList)
        {
            m_Queue.RemoveAll(x => idList.Contains(x.GetId()));
            ReorderQueue();
        }

        public void Unregister(ActionContainer actionContainer)
        {
            m_Queue.RemoveAll(x => x.GetActionContainer().Compare(actionContainer));
            ReorderQueue();
        }

        /// <summary>
        /// Invoke the registered actions with given values
        /// </summary>
        /// <param name="values"></param>
        public void Invoke(params object[] values)
        {
            foreach (var singleAction in m_Queue)
            {
                try
                {
                    singleAction.Invoke(values);
                }
                catch (Exception e)
                {
                    Debug.LogError(
                        $"[OrderedAction] Invoke Error in Registered Action:" +
                        $" Order={singleAction.order} Title={singleAction.title} | Id={singleAction.GetId()} | Message={e.Message} Stack={e.StackTrace}");
                }
            }
        }


        /// <summary>
        /// Reorder the registered actions based on Order Number
        /// </summary>
        private void ReorderQueue()
        {
            m_Queue.Sort((x, y) => x.order.CompareTo(y.order));
        }
    }
}