using System;
using System.Collections.Generic;
using LeaderBoard.Examples.OnlyLeaderBoardExample.Scripts.Routers;

namespace LeaderBoard.Examples.OnlyLeaderBoardExample.Scripts
{
    public class RoutersContainer : IScreenRouter
    {
        private readonly IScreenRouter[] _routers;

        public IEnumerable<IScreenRouter> All => _routers;

        public LoginRouter LoginRouter { get; }
        
        public RegisterRouter RegisterRouter { get; }
        
        public LeaderBoardRouter LeaderBoardRouter { get; }

        public event Action OnStartLoading;
        
        public event Action OnEndLoading;
        
        public RoutersContainer(ScreensContainer screensContainer)
        {
            _routers = new IScreenRouter[]
            {
                LoginRouter = new LoginRouter(screensContainer.Login),
                RegisterRouter = new RegisterRouter(screensContainer.Register, screensContainer.ConfirmEmail),
                LeaderBoardRouter = new LeaderBoardRouter(screensContainer.LeaderBoard)
            };
        }

        public void Initialize()
        {
            foreach (IScreenRouter router in _routers)
            {
                router.Initialize();
                
                router.OnEndLoading += OnEndLoading;
                router.OnStartLoading += OnStartLoading;
            }
        }

        public void Dispose()
        {
            foreach (IScreenRouter router in _routers)
            {
                router.Dispose();
                
                router.OnEndLoading -= OnEndLoading;
                router.OnStartLoading -= OnStartLoading;
            }
        }
    }
}