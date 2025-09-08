using ConsoleCS_ProjectManagementSystem.Infrastructure.DataBase;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Services;
using ConsoleCS_ProjectManagementSystem.Model.DataType;
using Dapper;

namespace ConsoleCS_ProjectManagementSystem.Infrastructure.Repositories
{
    public class RoleRepository
    {
        private readonly IDbConnectionFactory _connection;
        public RoleRepository(IDbConnectionFactory connection)
        {
            _connection = connection;
        }

        public IEnumerable<DefaultRole> GetRoles()
        {
            using var connection = _connection.CreateConnection();

            IEnumerable<DefaultRole> roles = connection.Query<DefaultRole>("""

                SELECT id, name, rights
                FROM Roles

                """) ?? throw new ArgumentNullException(nameof(roles));

            return roles;
        }
    }
}
