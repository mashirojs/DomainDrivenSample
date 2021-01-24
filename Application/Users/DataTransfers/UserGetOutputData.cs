namespace Application.Users.DataTransfers
{
    public class UserGetOutputData
    {
        public UserGetOutputData(UserData user)
        {
            User = user;
        }
        public UserData User { get; }
    }
}