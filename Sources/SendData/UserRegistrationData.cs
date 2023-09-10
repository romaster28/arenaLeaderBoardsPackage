namespace LeaderBoard.Sources.SendData
{
    public class UserRegistrationData
    {
        public string Email { get; }
        
        public string Password { get; }
        
        public string UserName { get; }

        public UserRegistrationData(string email, string password, string userName)
        {
            Email = email;
            Password = password;
            UserName = userName;
        }
    }
}