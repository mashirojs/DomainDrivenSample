using Domain.Models.Users;

namespace Domain.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// 同名のユーザーが存在するかチェックします。
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Exists(User user)
        {
            var duplicatedUser = _userRepository.Find(user.Name);
            return duplicatedUser != null;
        }
    }
}