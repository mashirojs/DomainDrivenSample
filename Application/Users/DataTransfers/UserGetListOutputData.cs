using System.Collections.Generic;

namespace Application.Users.DataTransfers
{
    public class UserGetListOutputData
    {
        public UserGetListOutputData(IEnumerable<UserData> users)
        {
            Users = users;
        }
        public IEnumerable<UserData> Users { get; }
    }
}