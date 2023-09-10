using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LeaderBoard.Examples.OnlyLeaderBoardExample.Scripts.Screens
{
    public class ConfirmEmailScreen : BaseScreen
    {
        [SerializeField] private TMP_Text _emailView;

        [SerializeField] private TMP_InputField _code;
        
        [SerializeField] private string _formatEmail = "Code({0}):";

        [SerializeField] private Button _back;

        [SerializeField] private Button _confirm;

        [SerializeField] private Button _sendAgain;

        public TMP_InputField Code => _code;

        public Button Back => _back;

        public Button Confirm => _confirm;

        public Button SendAgain => _sendAgain;

        public void UpdateEmail(string email)
        {
            _emailView.text = string.Format(_formatEmail, email);
        }
    }
}