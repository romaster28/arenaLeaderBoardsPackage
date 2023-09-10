using System;
using LeaderBoard.Sources.Response;
using LeaderBoard.Sources.SendData;

namespace LeaderBoard.Sources.Requests
{
    public class LoginUserRequest : BaseRequest<UserLoginData, LoginResponse>
    {
        public LoginUserRequest(UserLoginData data) : base(data)
        {
            Helper.Body = new LoginUserBody()
            {
                login = data.Login,
                password = data.Password
            };
        }

        protected override Method Method => Method.Post;
        protected override string AfterBaseUri => "client/auth/sign-in";

        [Serializable]
        public class LoginUserBody
        {
            public string login;
            public string password;
        }
    }
}