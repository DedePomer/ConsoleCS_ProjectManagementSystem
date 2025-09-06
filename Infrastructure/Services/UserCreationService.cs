using ConsoleCS_ProjectManagementSystem.Infrastructure.Repositories;
using ConsoleCS_ProjectManagementSystem.Model.DataType;
using Serilog;

namespace ConsoleCS_ProjectManagementSystem.Infrastructure.Services
{
    public class UserCreationService
    {
        private readonly UserCreationRepository _repository;
        public UserCreationService(UserCreationRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<DefaultRole> GetRoles()
        {
            return _repository.GetRoles();
        }

        public bool UserExist(string login)
        {
            return _repository.UserExist(login);
        }

        public void CreateUser(DefaultUser user)
        {
            _repository.CreateUser(user);
        }
    }
}
