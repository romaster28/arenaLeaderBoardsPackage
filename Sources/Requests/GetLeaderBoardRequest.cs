using System;
using System.Collections.Generic;
using LeaderBoard.Sources.Response;
using LeaderBoard.Sources.SendData;

namespace LeaderBoard.Sources.Requests
{
    public class GetLeaderBoardRequest : ServerRequest<LeaderBoardData, LeaderBoardResponse>
    {
        public GetLeaderBoardRequest(LeaderBoardData data, string profileId) : base(data)
        {
            Helper.Params = new Dictionary<string, string>()
            {
                {"aroundPlayerLimit", data.AroundPlayerLimit},
                {"isAroundPlayer", data.IsAroundPlayer},
                {"limit", data.Limit},
                {"offset", data.Offset},
                {"profileId", profileId},
            };
        }

        protected override Method Method => Method.Get;
        protected override string AfterBaseUri => $"server/{GameAlias}/leaderboard/{LeaderBoardAlias}";
    }
}