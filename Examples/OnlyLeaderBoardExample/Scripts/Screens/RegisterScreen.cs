using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LeaderBoard.Examples.OnlyLeaderBoardExample.Scripts.Screens
{
    public class RegisterScreen : BaseScreen
    {
        [SerializeField] private TMP_InputField _email;

        [SerializeField] private TMP_InputField _password;

        [SerializeField] private TMP_InputField _username;

        [SerializeField] private Button _back;

        [SerializeField] private Button _register;

        public TMP_InputField Email => _email;

        public TMP_InputField Password => _password;

        public TMP_InputField Username => _username;

        public Button Back => _back;

        public Button Register => _register;
    }
}