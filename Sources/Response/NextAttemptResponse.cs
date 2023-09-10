using System;

namespace LeaderBoard.Sources.Response
{
    [Serializable]
    public class NextAttemptResponse
    {
        public int nextAttemptTime;
        
        public DateTime NextAttemptTime => DateTime.FromFileTimeUtc(nextAttemptTime);
    }
}