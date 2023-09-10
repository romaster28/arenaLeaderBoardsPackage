using System;

namespace LeaderBoard.Sources.Response
{
    [Serializable]
    public class ErrorResponse
    {
        public string id;
        public string code;
        public string type;
        public string message;

        public override string ToString()
        {
            return $"{code}: {message}";
        }
    }
}