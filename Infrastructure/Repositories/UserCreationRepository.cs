using System.Security.Cryptography;
using System.Text;
using ConsoleCS_ProjectManagementSystem.Infrastructure.DataBase;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Services;
using ConsoleCS_ProjectManagementSystem.Model.DataType;
using Dapper;

namespace ConsoleCS_ProjectManagementSystem.Infrastructure.Repositories
{
    public class UserCreationRepository
    {
        private readonly IDbConnectionFactory _connection;
        public UserCreationRepository(IDbConnectionFactory connection)
        {
            _connection = connection;
        }

        public List<DefaultRole> GetRoles()
        {
            using var connection = _connection.CreateConnection();

            List<DefaultRole> roles = connection.QuerySingleOrDefault<List<DefaultRole>>("""

                SELECT name, rights
                FROM Roles

                """) ?? throw new ArgumentNullException(nameof(roles));

            return roles;
        }

        public void CreateUser(DefaultUser user)
        {
            using var connection = _connection.CreateConnection();

            connection.Execute( new CommandDefinition("""

                INSERT INTO Users (name,password,roleid)
                VALUES (@Name, 'john.doe@example.com', 'securepassword');

                """, new { Name = user.Name, Pasword = HashService.GetHash(user.Password), Role = user.Role}));
        }

        public bool UserExist(string login)
        {
            using var connection = _connection.CreateConnection();

            return connection.ExecuteScalar<bool>(new CommandDefinition("""
                
                SELECT EXISTS(
                SELECT 1
                FROM Users
                WHERE name = @Login)
                
                """, new { Login = login}));
        }
    }
}
