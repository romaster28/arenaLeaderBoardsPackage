using System;
using LeaderBoard.Sources.SendData;

namespace LeaderBoard.Sources.Requests
{
    public sealed class RegisterRequest : BaseRequest<UserRegistrationData, string>
    {
        protected override Method Method => Method.Post;

        protected override string AfterBaseUri => $"client/{GameAlias}/user-registration";

        public RegisterRequest(UserRegistrationData data) : base(data)
        {
            Helper.Body = new RegisterBody()
            {
                email = data.Email,
                password = data.Password,
                username = data.UserName
            };
        }

        [Serializable]
        public class RegisterBody
        {
            public string email;
            public string password;
            public string username;
        }
    }
}