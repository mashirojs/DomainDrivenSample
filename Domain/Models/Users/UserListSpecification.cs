using Domain.Shared;

namespace Domain.Models.Users
{
    public class UserListSpecification : IListSpecification<User>
    {
        public UserListSpecification(string search)
        {
            _search = search;
        }

        private string _search;

        public bool Satisfy(User item)
        {
            return item.Name.Value.Contains(_search);
        }
    }
}