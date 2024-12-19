using System;
using Reza.OrderedAction.Scripts;
using UnityEngine;

namespace Reza.OrderedAction._Test_
{
    public class DummyActionRegisterer : MonoBehaviour
    {
        [SerializeField] private Scripts.OrderedAction m_OrderedAction = new Scripts.OrderedAction();

        private void OnEnable()
        {
            m_OrderedAction.Register(FuncA, 5, "A");
            m_OrderedAction.Register(FuncB, 1, "B");
            m_OrderedAction.Register(FuncC, 10, "C");
        }

        private void OnDisable()
        {
            m_OrderedAction.Unregister(FuncA);
            m_OrderedAction.Unregister(FuncB);
            m_OrderedAction.Unregister(FuncC);
        }

        private void Start()
        {
            m_OrderedAction.Invoke();
        }

        private void FuncA()
        {
            print("Func A is called!");
        }

        private void FuncB()
        {
            //print("Func B is called!");
            throw new Exception("Dummy exception!");
        }

        private void FuncC()
        {
            print("Func C is called!");
        }

    }
}