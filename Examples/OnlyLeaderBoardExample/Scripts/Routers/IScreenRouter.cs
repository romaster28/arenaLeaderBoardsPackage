using System;

namespace LeaderBoard.Examples.OnlyLeaderBoardExample.Scripts.Routers
{
    public interface IScreenRouter : IDisposable
    {
        event Action OnStartLoading;

        event Action OnEndLoading;
        
        void Initialize();
    }
}