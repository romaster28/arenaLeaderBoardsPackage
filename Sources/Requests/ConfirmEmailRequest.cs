using System;
using LeaderBoard.Sources.SendData;

namespace LeaderBoard.Sources.Requests
{
    public class ConfirmEmailRequest : BaseRequest<ConfirmEmailData, string>
    {
        protected override Method Method => Method.Post;

        protected override string AfterBaseUri => $"client/{GameAlias}/user-registration/confirmation-email";
        
        public ConfirmEmailRequest(ConfirmEmailData data) : base(data)
        {
            Helper.Body = new ConfirmBody()
            {
                code = data.Code.ToString(),
                email = data.Email
            };
        }

        [Serializable]
        public class ConfirmBody
        {
            public string code;
            public string email;
        }
    }
}