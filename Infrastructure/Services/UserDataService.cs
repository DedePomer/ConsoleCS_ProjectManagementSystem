using System.Security.Cryptography;
using System.Text;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Repositories;
using ConsoleCS_ProjectManagementSystem.Model.DataType;

namespace ConsoleCS_ProjectManagementSystem.Infrastructure.Services
{
    public class UserDataService
    {
        private readonly UserDataRepository _userDataRepository;
        public UserDataService(UserDataRepository userDataRepository)
        {
            _userDataRepository = userDataRepository;
        }

        public bool UserExist(string login, string password)
        {
            return _userDataRepository.UserExist(login, password);
        }

        public DefaultUser GetUser(string login, string password)
        {
            DefaultUser user = new DefaultUser();

            user.Name = login;
            user.Password = string.Empty;
            user.role = _userDataRepository.GetUserRole(login);

            return user;

        }
    }
}
