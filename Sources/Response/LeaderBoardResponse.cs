using System;

namespace LeaderBoard.Sources.Response
{
    [Serializable]
    public class LeaderBoardResponse
    {
        public LeaderBoardItem[] leaderboards;
        public LeaderBoardItem[] aroundLeaderboards;
    }
    
    [Serializable]
    public class LeaderBoardItem
    {
        public string profileId;
        public string username;
        public int position;
        public int score;
        public int createdAt;
    }
}