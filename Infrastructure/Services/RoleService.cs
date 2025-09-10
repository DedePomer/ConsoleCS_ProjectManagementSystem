using ConsoleCS_ProjectManagementSystem.Infrastructure.Repositories;
using ConsoleCS_ProjectManagementSystem.Model.DataType;
using ConsoleCS_ProjectManagementSystem.Model.DataType.Base;

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
            List<BaseRole> baseRoles = _repository
                .GetRoles()
                .ToList();
            List<DefaultRole> roles = new();

            foreach (BaseRole baseRole in baseRoles)
            {
                roles.Add(new DefaultRole(baseRole));
            }

            return roles;
        }

        public DefaultRole GetRoleByRoleId(int roleId)
        {
            return new DefaultRole(_repository.GetRoleByRoleId(roleId));
        }

        public DefaultRole GetRoleByUserName(string name)
        {
            return new DefaultRole(_repository.GetRoleByUserName(name));
        }
    }
}
