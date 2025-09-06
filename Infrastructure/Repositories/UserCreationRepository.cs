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

        public IEnumerable<DefaultRole> GetRoles()
        {
            using var connection = _connection.CreateConnection();

            IEnumerable<DefaultRole> roles = connection.Query<DefaultRole>("""

                SELECT id, name, rights
                FROM Roles

                """) ?? throw new ArgumentNullException(nameof(roles));

            return roles;
        }

        public void CreateUser(DefaultUser user)
        {
            using var connection = _connection.CreateConnection();

            connection.Execute( new CommandDefinition("""

                INSERT INTO Users (name,password,roleid)
                VALUES (@Name, @Pasword, @Role);

                """, new { Name = user.Name, Pasword = HashService.GetHash(user.Password), Role = user.Role.Id}));
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
