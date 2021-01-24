namespace Application.Users.DataTransfers
{
    public class UserRegisterOutputData
    {
        public UserRegisterOutputData(string id)
        {
            Id = id;
        }
        public string Id { get; }
    }
}