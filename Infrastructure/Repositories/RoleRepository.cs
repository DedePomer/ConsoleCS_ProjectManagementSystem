using ConsoleCS_ProjectManagementSystem.Infrastructure.DataBase;
using ConsoleCS_ProjectManagementSystem.Model.DataType.Base;
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

        public IEnumerable<BaseRole> GetRoles()
        {
            using var connection = _connection.CreateConnection();

            IEnumerable<BaseRole> roles = connection.Query<BaseRole>("""

                SELECT id, name, rights
                FROM Roles

                """) ?? throw new ArgumentNullException(nameof(roles));

            return roles;
        }

        public BaseRole GetRoleByRoleId(int roleId)
        {
            using var connection = _connection.CreateConnection();

            BaseRole role = connection.QuerySingleOrDefault<BaseRole>(new CommandDefinition("""
                
                SELECT id, name, rights
                FROM Roles
                WHERE id = (SELECT roleid
                FROM Users
                WHERE roleid = @RoleId)
                
                """, new { RoleId = roleId })) ?? throw new ArgumentNullException(nameof(role));

            return role;
        }

        public BaseRole GetRoleByUserName(string name)
        {
            using var connection = _connection.CreateConnection();

            var role = connection.QuerySingleOrDefault<BaseRole>(new CommandDefinition("""
                
                SELECT id, name, rights
                FROM Roles
                WHERE id = (SELECT roleid
                FROM Users
                WHERE name = @Name)
                
                """, new { Name = name }));

            return role ?? throw new ArgumentNullException(nameof(role));
        }
    }
}
