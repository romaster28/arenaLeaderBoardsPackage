using System;
using LeaderBoard.Examples.OnlyLeaderBoardExample.Scripts.Screens;
using UnityEngine;

namespace LeaderBoard.Examples.OnlyLeaderBoardExample.Scripts
{
    [Serializable]
    public class ScreensContainer
    {
        [SerializeField] private LoginScreen _login;

        [SerializeField] private RegisterScreen _register;

        [SerializeField] private ConfirmEmailScreen _confirmEmail;

        [SerializeField] private LeaderBoardScreen _leaderBoard;

        [SerializeField] private LoadingScreen _loading;

        public LoginScreen Login => _login;

        public RegisterScreen Register => _register;

        public ConfirmEmailScreen ConfirmEmail => _confirmEmail;

        public LeaderBoardScreen LeaderBoard => _leaderBoard;

        public LoadingScreen Loading => _loading;

        public void CloseAll()
        {
            _login.Close();
            
            _register.Close();
            
            _confirmEmail.Close();
            
            _leaderBoard.Close();
            
            _loading.Close();
        }
    }
}