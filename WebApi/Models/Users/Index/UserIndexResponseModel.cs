using System.Collections.Generic;
using WebApi.Models.Users.Common;

namespace WebApi.Models.Users.Index
{
    public class UserIndexResponseModel
    {
        public UserIndexResponseModel(IEnumerable<UserResponseModel> users)
        {
            Users = users;
        }

        public IEnumerable<UserResponseModel> Users { get; }
    }
}