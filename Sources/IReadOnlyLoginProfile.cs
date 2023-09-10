namespace LeaderBoard.Sources
{
    public interface IReadOnlyLoginProfile
    {
        bool IsSignIn { get; }
        
        string ProfileId { get; }
    }
}