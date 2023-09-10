using System;

namespace LeaderBoard.Sources
{
    public interface IResponseHandler<T>
    {
        event Action<ResponseInfo<T>> OnComplete;
    }
    
    public class ResponseHandler<T> : IResponseHandler<T>
    {
        public event Action<ResponseInfo<T>> OnComplete;

        public void SendComplete(ResponseInfo<T> info)
        {
            OnComplete?.Invoke(info);
        }
    }

    public class ResponseInfo<T>
    {
        public bool Ok => string.IsNullOrEmpty(Error);
        
        public string Error { get; }
        
        public T Data { get; }

        public ResponseInfo(string error, T data)
        {
            Error = error;
            Data = data;
        }
    }
}