using UnityEngine;

namespace LeaderBoard.Examples.OnlyLeaderBoardExample.Scripts
{
    public class UiMenuRouter : MonoBehaviour
    {
        [SerializeField] private ScreensContainer _screensContainer;

        private RoutersContainer _routersContainer;

        private void Awake()
        {
            _routersContainer = new RoutersContainer(_screensContainer);
            
            _screensContainer.CloseAll();
        }

        private void OnEnable()
        {
            _routersContainer.OnEndLoading += _screensContainer.Loading.Close;
            _routersContainer.OnStartLoading += _screensContainer.Loading.Open;

            _routersContainer.Initialize();

            _routersContainer.LoginRouter.OnSuccessLogin += _screensContainer.Login.Close;
            _routersContainer.LoginRouter.OnSuccessLogin += _screensContainer.LeaderBoard.Open;
            
            _routersContainer.LoginRouter.OnRegisterClicked += _screensContainer.Login.Close;
            _routersContainer.LoginRouter.OnRegisterClicked += _screensContainer.Register.Open;

            _routersContainer.RegisterRouter.OnBackClicked += _screensContainer.Login.Open;
            _routersContainer.RegisterRouter.OnBackClicked += _screensContainer.Register.Close;
            
            _routersContainer.RegisterRouter.OnSuccessRegister += _screensContainer.Register.Close;
            _routersContainer.RegisterRouter.OnSuccessRegister += _screensContainer.LeaderBoard.Open;

            _routersContainer.LeaderBoardRouter.OnLogOut += _screensContainer.LeaderBoard.Close;
            _routersContainer.LeaderBoardRouter.OnLogOut += _screensContainer.Login.Open;
        }

        private void Start()
        {
            _screensContainer.Login.Open();
        }

        private void OnDisable()
        {
            _routersContainer.Dispose();
            
            _routersContainer.OnEndLoading -= _screensContainer.Loading.Close;
            _routersContainer.OnStartLoading -= _screensContainer.Loading.Open;
            
            _routersContainer.LoginRouter.OnSuccessLogin -= _screensContainer.Login.Close;
            _routersContainer.LoginRouter.OnSuccessLogin -= _screensContainer.LeaderBoard.Open;
            
            _routersContainer.LoginRouter.OnRegisterClicked -= _screensContainer.Login.Close;
            _routersContainer.LoginRouter.OnRegisterClicked -= _screensContainer.Register.Open;

            _routersContainer.RegisterRouter.OnBackClicked -= _screensContainer.Login.Open;
            _routersContainer.RegisterRouter.OnBackClicked -= _screensContainer.Register.Close;
            
            _routersContainer.RegisterRouter.OnSuccessRegister -= _screensContainer.Register.Close;
            _routersContainer.RegisterRouter.OnSuccessRegister -= _screensContainer.LeaderBoard.Open;

            _routersContainer.LeaderBoardRouter.OnLogOut -= _screensContainer.LeaderBoard.Close;
            _routersContainer.LeaderBoardRouter.OnLogOut -= _screensContainer.Login.Open;
        }
    }
}