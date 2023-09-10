using LeaderBoard.Sources.Response;

namespace LeaderBoard.Sources.Requests
{
    public class InfoProfileRequest : BaseRequest<string, ProfileInfoResponse>
    {
        public InfoProfileRequest(string data) : base(data)
        {
            Helper.Headers.Add("access-token", data);
        }

        protected override Method Method => Method.Get;
        protected override string AfterBaseUri => "client/my-profile";
    }
}