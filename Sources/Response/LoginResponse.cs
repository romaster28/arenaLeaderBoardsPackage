using System;

namespace LeaderBoard.Sources.Response
{
    [Serializable]
    public class LoginResponse
    {
        public TokenResponse accessToken;
        public TokenResponse refreshToken;
    }

    [Serializable]
    public class TokenResponse
    {
        public string token;
        public int expiresIn;
    }
}