using System;

namespace Reza.OrderedAction.Scripts
{
    public class ActionContainer
    {
        private Delegate m_MyAction;

        public ActionContainer(Delegate action)
        {
            m_MyAction = action;
        }

        public void Invoke(params object[] args)
        {
            m_MyAction?.DynamicInvoke(args);
        }

        public bool Compare(ActionContainer ac)
        {
            return ac.m_MyAction == m_MyAction;
        }
    }
}