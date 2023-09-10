Before start, you need to login or register user

To login, use ``ArenaLeaderBoard.Login()``
To register, use ``ArenaLeaderBoard.Register()``. After register, you necessary confirm email adress by using ``ArenaLeaderBoard.ConfirmEmail()``

Example registration:
```csharp
var registerData = new UserRegistrationData("example@mail.ru", "password", "userName");

ArenaLeaderBoard.Register(registerData).OnComplete += delegate(ResponseInfo<string> info)
{
    if (info.Ok)
    {
        var confirmEmailData = new ConfirmEmailData(335335, "example@mail.ru");

        ArenaLeaderBoard.ConfirmEmail(confirmEmailData).OnComplete += delegate(ResponseInfo<string> info)
        {
	    if (info.Ok)
	        // Success register    
        };
    }  
    else
    {
        // Error
        Debug.LogError(info.Error);
    }
};

```

Example login:
```csharp
var userLoginData = new UserLoginData("userName", "password");

ArenaLeaderBoard.Login(userLoginData).OnComplete += delegate(ResponseInfo<LoginResponse> info)
{
    if (info.Ok)
        // Success login
    else
        // Error
        Debug.LogError(info.Error);              
};
```
When you logged in, you can call requests to get leaderboard or add value for the logged user

To get leaderboard, use ``ArenaLeaderBoard.GetLeaderBoard`` and for add value for the logged user, use ``ArenaLeaderBoard.AddValueToUser``

Example get leaderboard:
```csharp
ArenaLeaderBoard.GetLeaderBoard(_defaultData).OnComplete += delegate(ResponseInfo<LeaderBoardResponse> infoLeader)
{
    if (!infoLeader.Ok)
    {                  
        Debug.LogError(infoLeader.Error);

        return;                                        
    }                 
        
    // Success

    foreach (var item in infoLeader.Data.leaderboards)
    {
		
    }

    foreach (var item in infoLeader.Data.aroundLeaderboards)
    {
		
    }
};                  
```
Example add value to the logged user:
```csharp
ArenaLeaderBoard.AddValueToUser(new AddValueData(20)).OnComplete += delegate(ResponseInfo<string> info)
{                
	if (info.Ok)
	{
		// Success
	}                  
};
```
