using System;
using LeaderBoard.Examples.OnlyLeaderBoardExample.Scripts.Screens;
using LeaderBoard.Sources;
using LeaderBoard.Sources.Response;
using LeaderBoard.Sources.SendData;
using UnityEngine;

namespace LeaderBoard.Examples.OnlyLeaderBoardExample.Scripts.Routers
{
    public class RegisterRouter : IScreenRouter
    {
        private readonly RegisterScreen _registerScreen;

        private readonly ConfirmEmailScreen _confirmEmailScreen;

        public event Action OnStartLoading;

        public event Action OnEndLoading;

        public event Action OnBackClicked;

        public event Action OnSuccessRegister;

        public RegisterRouter(RegisterScreen registerScreen, ConfirmEmailScreen confirmEmailScreen)
        {
            _registerScreen = registerScreen;
            _confirmEmailScreen = confirmEmailScreen;
        }

        private void OpenConfirm()
        {
            _confirmEmailScreen.UpdateEmail(_registerScreen.Email.text);
            
            _registerScreen.Close();

            _confirmEmailScreen.Open();
        }

        private void ConfirmEmail()
        {
            OnStartLoading?.Invoke();

            var confirmEmailData = new ConfirmEmailData(int.Parse(_confirmEmailScreen.Code.text),
                _registerScreen.Email.text);

            ArenaLeaderBoard.ConfirmEmail(confirmEmailData).OnComplete += delegate(ResponseInfo<string> info)
            {
                OnEndLoading?.Invoke();

                if (!info.Ok)
                {
                    Debug.LogError(info.Error);
                    
                    return;
                }

                var userLoginData = new UserLoginData(_registerScreen.Email.text, _registerScreen.Password.text);

                ArenaLeaderBoard.Login(userLoginData).OnComplete += delegate(ResponseInfo<LoginResponse> responseInfo)
                {
                    if (responseInfo.Ok)
                        OnSuccessRegister?.Invoke();
                };
            };
        }

        private void SendConfirmCodeAgain()
        {
            OnStartLoading?.Invoke();

            ArenaLeaderBoard.ReSendEmailCode(_registerScreen.Email.text).OnComplete +=
                delegate { OnEndLoading?.Invoke(); };
        }

        private void OnRegisterClicked()
        {
            var registerData = new UserRegistrationData(_registerScreen.Email.text, _registerScreen.Password.text,
                _registerScreen.Username.text);

            OnStartLoading?.Invoke();

            ArenaLeaderBoard.Register(registerData).OnComplete += delegate(ResponseInfo<string> info)
            {
                OnEndLoading?.Invoke();

                if (info.Ok)
                    OpenConfirm();
                else
                    Debug.LogError(info.Error);
                
                if (info.Error.StartsWith("email_not_confirmed"))
                    OpenConfirm();
            };
        }

        public void Initialize()
        {
            _registerScreen.Back.onClick.AddListener(delegate { OnBackClicked?.Invoke(); });

            _registerScreen.Register.onClick.AddListener(OnRegisterClicked);

            _confirmEmailScreen.Back.onClick.AddListener(_registerScreen.Open);
            _confirmEmailScreen.Back.onClick.AddListener(_confirmEmailScreen.Close);

            _confirmEmailScreen.SendAgain.onClick.AddListener(SendConfirmCodeAgain);

            _confirmEmailScreen.Confirm.onClick.AddListener(ConfirmEmail);
        }

        public void Dispose()
        {
            _registerScreen.Back.onClick.RemoveAllListeners();

            _registerScreen.Register.onClick.RemoveAllListeners();

            _confirmEmailScreen.Back.onClick.RemoveAllListeners();

            _confirmEmailScreen.SendAgain.onClick.RemoveAllListeners();

            _confirmEmailScreen.Confirm.onClick.RemoveAllListeners();
        }
    }
}