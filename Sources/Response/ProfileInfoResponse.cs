using System;

namespace LeaderBoard.Sources.Response
{
    [Serializable]
    public class ProfileInfoResponse
    {
        public string id;
        public Playfab playfab;
        public string username;
        public string email;
    }

    [Serializable]
    public class Playfab
    {
        public string playfabId;
        public string token;
        public int tokenExpired;
    }
}