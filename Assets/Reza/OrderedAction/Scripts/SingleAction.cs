using System;

namespace Reza.OrderedAction.Scripts
{
    [System.Serializable]
    public class SingleAction
    {
        public int order;
        public string title;
        private string id;

        protected ActionContainer ActionContainer = null;

        public SingleAction()
        {
            id = Guid.NewGuid().ToString();
        }

        private SingleAction RegisterAnyAction(Delegate action, int order = 0, string title = "")
        {
            this.order = order;
            this.title = title;

            ActionContainer = new ActionContainer(action);

            return this;
        }

        public SingleAction Register(Action action, int order = 0, string title = "")
        {
            return RegisterAnyAction(action, order, title);
        }

        public SingleAction Register<T1>(Action<T1> action, int order = 0, string title = "")
        {
            return RegisterAnyAction(action, order, title);
        }

        public SingleAction Register<T1, T2>(Action<T1, T2> action, int order = 0, string title = "")
        {
            return RegisterAnyAction(action, order, title);
        }

        public SingleAction Register<T1, T2, T3>(Action<T1, T2, T3> action, int order = 0, string title = "")
        {
            return RegisterAnyAction(action, order, title);
        }

        public SingleAction Register<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action, int order = 0, string title = "")
        {
            return RegisterAnyAction(action, order, title);
        }

        public SingleAction Register<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> action, int order = 0, string title = "")
        {
            return RegisterAnyAction(action, order, title);
        }

        public string GetId()
        {
            return id;
        }

        public ActionContainer GetActionContainer()
        {
            return ActionContainer;
        }

        public void Invoke(params object[] values)
        {
            ActionContainer.Invoke(values);
        }
    }
}