namespace LeaderBoard.Sources.Requests
{
    public class ResetLeaderBoardRequest : BaseRequest<string, string>
    {
        public ResetLeaderBoardRequest(string data) : base(data)
        {
        }

        protected override Method Method => Method.Patch;
        protected override string AfterBaseUri => $"server/{GameAlias}/leaderboard/{LeaderBoardAlias}/reset";
    }
}