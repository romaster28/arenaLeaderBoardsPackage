namespace LeaderBoard.Sources.SendData
{
    public class LeaderBoardData
    {
        public string AroundPlayerLimit { get; }
        
        public string IsAroundPlayer { get; }
        
        public string Limit { get; }
        
        public string Offset { get; }

        public LeaderBoardData(int aroundPlayerLimit, bool isAroundPlayer, int limit, int offset)
        {
            AroundPlayerLimit = aroundPlayerLimit.ToString();
            IsAroundPlayer = isAroundPlayer.ToString().ToLower();
            Limit = limit.ToString();
            Offset = offset.ToString();
        }
    }
}