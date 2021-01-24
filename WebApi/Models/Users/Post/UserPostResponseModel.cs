namespace WebApi.Models.Users.Post
{
    public class UserPostResponseModel
    {
        public UserPostResponseModel(string id)
        {
            Id = id;
        }
        public string Id { get; }
    }
}