using LeaderBoard.Sources.Requests;
using LeaderBoard.Sources.Response;
using LeaderBoard.Sources.SendData;

namespace LeaderBoard.Sources
{
    public static class ArenaLeaderBoard
    {
        private static LoginProfile _loginProfile = new LoginProfile();

        /// <summary>
        /// Returns info about the logged in user
        /// </summary>
        public static IReadOnlyLoginProfile LoginProfile => _loginProfile;

        /// <summary>
        /// Sending request to register new user
        /// </summary>
        /// <param name="data">Required parameters</param>
        /// <returns></returns>
        public static IResponseHandler<string> Register(UserRegistrationData data)
        {
            return new RegisterRequest(data).Send();
        }

        /// <summary>
        /// Confirmation registration email
        /// </summary>
        /// <param name="data">Needs email and code</param>
        /// <returns></returns>
        public static IResponseHandler<string> ConfirmEmail(ConfirmEmailData data)
        {
            return new ConfirmEmailRequest(data).Send();
        }

        /// <summary>
        /// Sending new register code to email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static IResponseHandler<string> ReSendEmailCode(string email)
        {
            return new SendCodeForConfirmEmailRequest(email).Send();
        }

        /// <summary>
        /// Returns time, when you can send new register code to email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static IResponseHandler<NextAttemptResponse> GetNextTimeAttemptConfirmEmail(string email)
        {
            return new GetNextAttemptConfirmEmail(email).Send();
        }

        /// <summary>
        /// Sending request to login user
        /// </summary>
        /// <param name="data">Required parameters</param>
        /// <returns></returns>
        public static IResponseHandler<LoginResponse> Login(UserLoginData data)
        {
            var responseHandler = new LoginUserRequest(data).Send();
            
            var realResponseHandler = new ResponseHandler<LoginResponse>();

            responseHandler.OnComplete += delegate(ResponseInfo<LoginResponse> infoLogin)
            {
                _loginProfile = new LoginProfile(infoLogin.Data);
                
                GetUserInfo().OnComplete += delegate(ResponseInfo<ProfileInfoResponse> info)
                {
                    _loginProfile = new LoginProfile(infoLogin.Data, info.Data.id);
                    
                    realResponseHandler.SendComplete(new ResponseInfo<LoginResponse>(infoLogin.Error, infoLogin.Data));
                };
            };
            
            return realResponseHandler;
        }

        /// <summary>
        /// Returns info about the logged user
        /// </summary>
        /// <returns></returns>
        public static IResponseHandler<ProfileInfoResponse> GetUserInfo()
        {
            _loginProfile.CheckSigned();
            
            return new InfoProfileRequest(_loginProfile.AccessToken).Send();
        }

        /// <summary>
        /// Adding value score for the logged user
        /// </summary>
        /// <param name="data">Required value</param>
        /// <returns></returns>
        public static IResponseHandler<string> AddValueToUser(AddValueData data)
        {
            _loginProfile.CheckSigned();
            
            return new AddToValueRequest(data, _loginProfile.ProfileId).Send();
        }

        /// <summary>
        /// Returns leaderboards: if IsAroundPlayer is true, then returns also around logged the user leaderboard 
        /// </summary>
        /// <param name="data">Required parameters/param>
        /// <returns></returns>
        public static IResponseHandler<LeaderBoardResponse> GetLeaderBoard(LeaderBoardData data)
        {
            _loginProfile.CheckSigned();
            
            return new GetLeaderBoardRequest(data, _loginProfile.ProfileId).Send();
        }

        /// <summary>
        /// Reset all leaderboard
        /// </summary>
        /// <returns></returns>
        public static IResponseHandler<string> ResetLeaderBoard()
        {
            _loginProfile.CheckSigned();
            
            return new ResetLeaderBoardRequest(string.Empty).Send();
        }

        /// <summary>
        /// Logout the logged user
        /// </summary>
        public static void LogOut()
        {
            _loginProfile = new LoginProfile();
        }
    }
}