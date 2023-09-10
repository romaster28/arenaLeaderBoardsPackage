using System;

namespace LeaderBoard.Sources.Requests
{
    public class SendCodeForConfirmEmailRequest : BaseRequest<string, string>
    {
        protected override Method Method => Method.Post;

        protected override string AfterBaseUri => $"client/{GameAlias}/user-registration/send-code-again";

        public SendCodeForConfirmEmailRequest(string data) : base(data)
        {
            Helper.Body = new SendCodeBody()
            {
                email = data
            };
        }

        [Serializable]
        public class SendCodeBody
        {
            public string email;
        }
    }
}