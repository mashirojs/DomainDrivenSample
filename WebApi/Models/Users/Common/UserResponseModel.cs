using Application.Users.DataTransfers;

namespace WebApi.Models.Users.Common
{
    public class UserResponseModel
    {
        public UserResponseModel(UserData user)
        {
            Id = user.Id;
            Name = user.Name;
        }
        public string Id { get; }
        public string Name { get; }
    }
}