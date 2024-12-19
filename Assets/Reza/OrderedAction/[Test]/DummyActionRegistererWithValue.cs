using System;
using UnityEngine;

namespace Reza.OrderedAction.Scripts._Test_
{
    public class DummyActionRegistererWithValue : MonoBehaviour
    {
        [SerializeField] private OrderedAction m_MyDummyAction = new OrderedAction();

        private void OnEnable()
        {
            m_MyDummyAction.Register<string>(SayWelcome, 10, "Welcome Text Writer");
            m_MyDummyAction.Register<string>(PlayerPrefSaver, 0, "PlayerPref Saver");
            m_MyDummyAction.Register<string>(ValueChecker, -5, "Validity Checker");
        }

        private void OnDisable()
        {
            m_MyDummyAction.Unregister<string>(SayWelcome);
            m_MyDummyAction.Unregister<string>(PlayerPrefSaver);
            m_MyDummyAction.Unregister<string>(ValueChecker);
        }

        private void Start()
        {
            m_MyDummyAction.Invoke("Negin");
        }

        private void ValueChecker(string value)
        {
            if (value != "Reza")
                throw new Exception("Name is not valid!");
            else
            {
                Debug.Log($"ValueChecker : value = {value}");
            }
        }

        private void PlayerPrefSaver(string value)
        {
            Debug.Log($"PlayerPrefSaver : value = {value}");
        }

        private void SayWelcome(string value)
        {
            Debug.Log($"SayWelcome : value = {value}");
        }
        
    }
}