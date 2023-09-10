using System;
using LeaderBoard.Examples.OnlyLeaderBoardExample.Scripts.Screens;
using LeaderBoard.Sources;
using LeaderBoard.Sources.Response;
using LeaderBoard.Sources.SendData;
using UnityEngine;

namespace LeaderBoard.Examples.OnlyLeaderBoardExample.Scripts.Routers
{
    public class LoginRouter : IScreenRouter
    {
        private readonly LoginScreen _loginScreen;

        public event Action OnStartLoading;
        
        public event Action OnEndLoading;
        
        public event Action OnSuccessLogin;

        public event Action OnRegisterClicked; 

        public LoginRouter(LoginScreen loginScreen)
        {
            _loginScreen = loginScreen;
        }

        private void OnLoginClicked()
        {
            var userLoginData = new UserLoginData(_loginScreen.EmailOrUserName.text, _loginScreen.Password.text);

            OnStartLoading?.Invoke();
            
            ArenaLeaderBoard.Login(userLoginData).OnComplete += delegate(ResponseInfo<LoginResponse> info)
            {
                if (info.Ok)
                    OnSuccessLogin?.Invoke();
                else
                    Debug.LogError(info.Error);

                OnEndLoading?.Invoke();  
            };
        }

        public void Initialize()
        {
            _loginScreen.Login.onClick.AddListener(OnLoginClicked);
            _loginScreen.Register.onClick.AddListener(delegate { OnRegisterClicked?.Invoke(); });
        }

        public void Dispose()
        {
            _loginScreen.Login.onClick.RemoveAllListeners();
            _loginScreen.Register.onClick.RemoveAllListeners();
        }
    }
}