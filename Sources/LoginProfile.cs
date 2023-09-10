using LeaderBoard.Sources.Response;
using System;

namespace LeaderBoard.Sources
{
    public class LoginProfile : IReadOnlyLoginProfile
    {
        private readonly LoginResponse _loginResponse;
        
        public string ProfileId { get; }

        public string AccessToken => _loginResponse.accessToken.token;

        public bool IsSignIn => _loginResponse != null;

        public LoginProfile(LoginResponse response)
        {
            _loginResponse = response;
        }
        
        public LoginProfile(LoginResponse response, string profileId)
        {
            _loginResponse = response;
            ProfileId = profileId;
        }

        public LoginProfile()
        {
            
        }

        public void CheckSigned()
        {
            if (!IsSignIn)
                throw new InvalidOperationException("User is not logon. Did you call \"ArenaLeaderBoard.Login\"?");
        }
    }
}