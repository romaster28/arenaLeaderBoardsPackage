using LeaderBoard.Sources.Response;
using LeaderBoard.Sources.RestClient.Packages.Proyecto26.RestClient.Helpers;
using UnityEngine;
using RClient = LeaderBoard.Sources.RestClient.Packages.Proyecto26.RestClient.RClient;
using RequestHelper = LeaderBoard.Sources.RestClient.Packages.Proyecto26.RestClient.Helpers.RequestHelper;

namespace LeaderBoard.Sources.Requests
{
    public abstract class BaseRequest<TData, TResponse> where TData : class where TResponse : class
    {
        private string Uri => "https://api.arenavs.com/api/v2/gamedev/" + AfterBaseUri;

        protected abstract Method Method { get; }

        protected abstract string AfterBaseUri { get; }

        protected RequestHelper Helper { get; } = new RequestHelper();

        protected const string LeaderBoardAlias = "test-task";

        protected const string GameAlias = "AM";

        protected BaseRequest(TData data)
        {
            Helper.Uri = Uri;
        }

        public IResponseHandler<TResponse> Send()
        {
            var handler = new ResponseHandler<TResponse>();

            switch (Method)
            {
                case Method.Get:
                    RClient.Get(Helper, OnCallBack);
                    break;
                case Method.Post:
                    RClient.Post(Helper, OnCallBack);
                    break;
                case Method.Patch:
                    RClient.Patch(Helper, OnCallBack);
                    break;
            }

            void OnCallBack(RequestException exception, ResponseHelper helper)
            {
                string rawResponse = helper.Text;

                string error = exception == null
                    ? string.Empty
                    : JsonUtility.FromJson<ErrorResponse>(rawResponse).ToString();

                handler.SendComplete(new ResponseInfo<TResponse>(error, ValidateRawResponse(rawResponse)));
            }

            return handler;
        }

        private TResponse ValidateRawResponse(string rawResponse)
        {
            if (typeof(TResponse) == typeof(string))
                return rawResponse as TResponse;

            return JsonUtility.FromJson<TResponse>(rawResponse);
        }
    }
}