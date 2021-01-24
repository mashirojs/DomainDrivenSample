using WebApi.Models.Users.Common;

namespace WebApi.Models.Users.Get
{
    public class UserGetResponseModel
    {
        public UserGetResponseModel(UserResponseModel user)
        {
            User = user;
        }

        public UserResponseModel User { get; }
    }
}