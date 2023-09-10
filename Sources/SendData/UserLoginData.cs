namespace LeaderBoard.Sources.SendData
{
    public class UserLoginData
    {
        public string Login { get; }
        
        public string Password { get; }

        public UserLoginData(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}