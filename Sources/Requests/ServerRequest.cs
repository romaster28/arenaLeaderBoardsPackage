namespace LeaderBoard.Sources.Requests
{
    public abstract class ServerRequest<TData, TResponse> : BaseRequest<TData, TResponse> where TData : class where TResponse : class
    {
        protected ServerRequest(TData data) : base(data)
        {
            Helper.Headers.Add("x-auth-server", "gamedev.7b5a2bb8-dfa7-4a2d-ab12-2fc644b08503");
        }
    }
}