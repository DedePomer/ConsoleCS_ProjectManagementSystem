using ConsoleCS_ProjectManagementSystem.Infrastructure.Repositories;
using ConsoleCS_ProjectManagementSystem.Model.DataType;

namespace ConsoleCS_ProjectManagementSystem.Infrastructure.Services
{
    public class UserService
    {
        private readonly UserRepository _repository;
        public UserService(UserRepository repository)
        {
            _repository = repository;
        }

        public bool UserAuthentication(string login, string password)
        {
            return _repository.UserAuthentication(login, password);
        }

        public DefaultUser GetUser(string login, string password)
        {
            DefaultUser user = new DefaultUser();

            user.Name = login;
            user.Password = string.Empty;
            user.Role = _repository.GetUserRole(login);

            return user;

        }

        public void CreateUser(DefaultUser user)
        {
            _repository.CreateUser(user);
        }
    }
}
