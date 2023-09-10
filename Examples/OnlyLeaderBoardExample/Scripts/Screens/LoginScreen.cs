using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LeaderBoard.Examples.OnlyLeaderBoardExample.Scripts.Screens
{
    public class LoginScreen : BaseScreen
    {
        [SerializeField] private TMP_InputField _emailOrUserName;

        [SerializeField] private TMP_InputField _password;

        [SerializeField] private Button _login;

        [SerializeField] private Button _register;

        public TMP_InputField EmailOrUserName => _emailOrUserName;

        public TMP_InputField Password => _password;

        public Button Login => _login;

        public Button Register => _register;
    }
}