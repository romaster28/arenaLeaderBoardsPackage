using TMPro;
using UnityEngine;

namespace LeaderBoard.Examples.OnlyLeaderBoardExample.Scripts.Elements
{
    public class LeaderBoardItem : MonoBehaviour
    {
        [SerializeField] private TMP_Text _infoView;

        [SerializeField] private string _formatInfo = "{0}. {1} - {2}";

        [SerializeField] private Color _adaptiveColor;
        
        public void Initialize(int place, string userName, int score)
        {
            _infoView.text = string.Format(_formatInfo, place, userName, score);
        }

        public void SetAdaptiveColor()
        {
            _infoView.color = _adaptiveColor;
        }
    }
}