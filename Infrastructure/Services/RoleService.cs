using ConsoleCS_ProjectManagementSystem.Infrastructure.Repositories;
using ConsoleCS_ProjectManagementSystem.Model.DataType;

namespace ConsoleCS_ProjectManagementSystem.Infrastructure.Services
{
    public class RoleService
    {
        private readonly RoleRepository _repository;
        public RoleService(RoleRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<DefaultRole> GetRoles()
        {
            return _repository.GetRoles();
        }
    }
}
