namespace LeaderBoard.Sources.SendData
{
    public class ConfirmEmailData
    {
        public int Code { get; }
        
        public string Email { get; }

        public ConfirmEmailData(int code, string email)
        {
            Code = code;
            Email = email;
        }
    }
}