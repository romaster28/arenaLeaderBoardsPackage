using System;
using UnityEngine;

namespace LeaderBoard.Examples.OnlyLeaderBoardExample.Scripts.Screens
{
    public class BaseScreen : MonoBehaviour
    {
        public event Action OnOpened;

        public event Action OnClosed;
        
        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            OnOpened?.Invoke();
        }

        private void OnDisable()
        {
            OnClosed?.Invoke();
        }
    }
}