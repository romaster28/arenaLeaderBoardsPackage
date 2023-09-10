using System;
using System.Collections.Generic;
using LeaderBoard.Examples.OnlyLeaderBoardExample.Scripts.Elements;
using LeaderBoard.Examples.OnlyLeaderBoardExample.Scripts.Screens;
using LeaderBoard.Sources;
using LeaderBoard.Sources.Response;
using LeaderBoard.Sources.SendData;
using UnityEngine;
using LeaderBoardItem = LeaderBoard.Sources.Response.LeaderBoardItem;

namespace LeaderBoard.Examples.OnlyLeaderBoardExample.Scripts.Routers
{
    public class LeaderBoardRouter : IScreenRouter
    {
        private readonly LeaderBoardScreen _leaderBoardScreen;
        
        public event Action OnStartLoading;

        public event Action OnEndLoading;

        public event Action OnLogOut;

        private readonly LeaderBoardData _defaultData = new LeaderBoardData(10, true, 50, 0);
        
        public LeaderBoardRouter(LeaderBoardScreen leaderBoardScreen)
        {
            _leaderBoardScreen = leaderBoardScreen;
        }

        private void OpenStart()
        {
            OnStartLoading?.Invoke();

            _leaderBoardScreen.Limit.text = _defaultData.Limit;
            _leaderBoardScreen.Offset.text = _defaultData.Offset;
            _leaderBoardScreen.AroundLimit.text = _defaultData.AroundPlayerLimit;
            
            ArenaLeaderBoard.GetUserInfo().OnComplete += delegate(ResponseInfo<ProfileInfoResponse> info)
            {
                _leaderBoardScreen.UserName.text = info.Data.username;
                
                ArenaLeaderBoard.GetLeaderBoard(_defaultData).OnComplete +=
                    delegate(ResponseInfo<LeaderBoardResponse> infoLeader)
                    {
                        OnEndLoading?.Invoke();

                        if (!infoLeader.Ok)
                        {
                            Debug.LogError(infoLeader.Error);

                            return;
                        }
                        
                        UpdateLeaderBoard(infoLeader.Data);
                    };
            };
        }

        private void AddValueFromInput()
        {
            int value = int.Parse(_leaderBoardScreen.ValueField.text);
            
            OnStartLoading?.Invoke();
            
            ArenaLeaderBoard.AddValueToUser(new AddValueData(value)).OnComplete += delegate(ResponseInfo<string> info)
            {
                OnEndLoading?.Invoke();
                
                if (!info.Ok)
                {
                    Debug.LogError(info.Error);

                    return;
                }
                
                UpdateLeaderBoardFromUserInput();
            };
        }

        private void UpdateLeaderBoardFromUserInput()
        {
            OnStartLoading?.Invoke();

            var data = new LeaderBoardData(int.Parse(_leaderBoardScreen.AroundLimit.text), true,
                int.Parse(_leaderBoardScreen.Limit.text), int.Parse(_leaderBoardScreen.Offset.text));
            
            ArenaLeaderBoard.GetLeaderBoard(data).OnComplete += delegate(ResponseInfo<LeaderBoardResponse> info)
            {
                OnEndLoading?.Invoke();
                
                if (!info.Ok)
                {
                    Debug.LogError(info.Error);

                    return;
                }
                
                UpdateLeaderBoard(info.Data);
            };
        }
        
        private void UpdateLeaderBoard(LeaderBoardResponse response)
        {
            UpdateItems(_leaderBoardScreen.AllItemsCreator, response.leaderboards);
            
            UpdateItems(_leaderBoardScreen.AroundItemsCreator, response.aroundLeaderboards);
        }

        private void UpdateItems(ItemsCreator<Examples.OnlyLeaderBoardExample.Scripts.Elements.LeaderBoardItem> creator, IEnumerable<LeaderBoardItem> items)
        {
            creator.DestroyAll();

            if (items == null)
                return;
            
            foreach (LeaderBoardItem item in items)
            {
                var created = creator.Create();
                
                created.Initialize(item.position, item.username, item.score);
                
                if (item.profileId == ArenaLeaderBoard.LoginProfile.ProfileId)
                    created.SetAdaptiveColor();
            }
        }

        private void LogOut()
        {
            ArenaLeaderBoard.LogOut();
            
            OnLogOut?.Invoke();
        }
        
        public void Initialize()
        {
            _leaderBoardScreen.Logout.onClick.AddListener(LogOut);

            _leaderBoardScreen.OnOpened += OpenStart;
            
            _leaderBoardScreen.Update.onClick.AddListener(UpdateLeaderBoardFromUserInput);
            
            _leaderBoardScreen.AddValue.onClick.AddListener(AddValueFromInput);
        }

        public void Dispose()
        {
            _leaderBoardScreen.Logout.onClick.RemoveAllListeners();
            
            _leaderBoardScreen.Update.onClick.RemoveAllListeners();
            
            _leaderBoardScreen.AddValue.onClick.RemoveAllListeners();
        }
    }
}