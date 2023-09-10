using System;
using LeaderBoard.Sources.Response;

namespace LeaderBoard.Sources.Requests
{
    public class GetNextAttemptConfirmEmail : BaseRequest<string, NextAttemptResponse>
    {
        public GetNextAttemptConfirmEmail(string data) : base(data)
        {
            Helper.Body = new NextAttemptBody()
            {
                email = data
            };
        }

        protected override Method Method => Method.Get;
        protected override string AfterBaseUri => $"client/{GameAlias}/user-registration/next-attempt-send-code";

        [Serializable]
        public class NextAttemptBody
        {
            public string email;
        }
    }
}