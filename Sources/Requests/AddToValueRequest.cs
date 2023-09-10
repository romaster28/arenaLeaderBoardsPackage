using System;
using LeaderBoard.Sources.SendData;

namespace LeaderBoard.Sources.Requests
{
    public class AddToValueRequest : ServerRequest<AddValueData, string>
    {
        public AddToValueRequest(AddValueData data, string profileId) : base(data)
        {
            Helper.Body = new AddValueBody()
            {
                profileId = profileId,
                value = data.Value
            };
        }

        protected override Method Method => Method.Patch;
        protected override string AfterBaseUri => $"server/{GameAlias}/leaderboard/{LeaderBoardAlias}/score";

        [Serializable]
        public class AddValueBody
        {
            public string profileId;
            public int value;
        }
    }
}