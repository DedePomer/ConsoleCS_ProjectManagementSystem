using ConsoleCS_ProjectManagementSystem.Infrastructure.Helpers;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Repositories;
using ConsoleCS_ProjectManagementSystem.Model.DataType;
using ConsoleCS_ProjectManagementSystem.Model.DataType.Base;

namespace ConsoleCS_ProjectManagementSystem.Infrastructure.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly RoleService _roleService;
        public UserService(UserRepository userRepository, RoleService roleService)
        {
            _userRepository = userRepository;
            _roleService = roleService;
        }

        public bool UserAuthentication(string login, string password)
        {
            return _userRepository.UserAuthentication(login, password);
        }

        public DefaultUser GetDefaultUser(string login, string password)
        {
            DefaultUser user = new DefaultUser();

            user.Id = _userRepository.GetUserIdByUserName(login);
            user.Name = login;
            user.Password = string.Empty;
            user.Role = _roleService.GetRoleByUserName(login);

            return user;

        }

        public IEnumerable<DefaultUser> GetUsers()
        {
            List<BaseUser> baseUsers = _userRepository
               .GetUsers()
               .ToList();
            List<DefaultUser> users = new();

            foreach (BaseUser baseUser in baseUsers)
            {
                users.Add(new DefaultUser(baseUser));
                users.Last().Role = _roleService.GetRoleByRoleId(baseUser.Id);
            }

            return users;
        }

        public void CreateUser(DefaultUser user)
        {
            string text = "admin";

            BaseUser baseUser = new BaseUser()
            {
                Id = 1,
                Name = user.Name ?? text,
                Password = HashHelper.GetHash(user.Password ?? text),
                RoleId = user.Role?.Id ?? 1,
            };

            _userRepository.CreateUser(baseUser);
        }

        public DefaultUser GetUserByUserId(int userId)
        {
            BaseUser baseUser = _userRepository
                .GetUserByUserId(userId);

            DefaultUser defaultUser = new DefaultUser(baseUser);
            defaultUser.Role = _roleService
                .GetRoleByRoleId(defaultUser.Id ?? 1);

            return defaultUser;
        }
    }
}
