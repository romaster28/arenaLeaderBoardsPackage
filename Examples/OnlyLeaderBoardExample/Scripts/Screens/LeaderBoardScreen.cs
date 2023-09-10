using LeaderBoard.Examples.OnlyLeaderBoardExample.Scripts.Elements;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LeaderBoard.Examples.OnlyLeaderBoardExample.Scripts.Screens
{
    public class LeaderBoardScreen : BaseScreen
    {
        [SerializeField] private Button _logout;

        [SerializeField] private TMP_Text _userName;

        [SerializeField] private TMP_InputField _valueField;

        [SerializeField] private Button _addValue;

        [SerializeField] private TMP_InputField _limit;

        [SerializeField] private TMP_InputField _aroundLimit;

        [SerializeField] private TMP_InputField _offset;

        [SerializeField] private Button _update;

        [SerializeField] private ItemsCreator<LeaderBoardItem> _allItemsCreator;

        [SerializeField] private ItemsCreator<LeaderBoardItem> _aroundItemsCreator;
        
        public Button Logout => _logout;

        public TMP_Text UserName => _userName;

        public TMP_InputField ValueField => _valueField;

        public Button AddValue => _addValue;

        public TMP_InputField Limit => _limit;

        public TMP_InputField AroundLimit => _aroundLimit;

        public TMP_InputField Offset => _offset;

        public Button Update => _update;

        public ItemsCreator<LeaderBoardItem> AllItemsCreator => _allItemsCreator;

        public ItemsCreator<LeaderBoardItem> AroundItemsCreator => _aroundItemsCreator;
    }
}