using System.Security.Cryptography;
using System.Text;
using ConsoleCS_ProjectManagementSystem.Infrastructure.DataBase;
using ConsoleCS_ProjectManagementSystem.Model.DataType;
using Dapper;

namespace ConsoleCS_ProjectManagementSystem.Infrastructure.Repositories
{
    public class UserDataRepository
    {
        private readonly IDbConnectionFactory _connection;
        public UserDataRepository(IDbConnectionFactory connection)
        {
            _connection = connection;
        }

        public bool UserExist(string login, string password)
        {
            using var connection = _connection.CreateConnection();

            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            bool isUserExist = connection.ExecuteScalar<bool>(new CommandDefinition("""
                
                SELECT EXISTS(
                SELECT 1
                FROM Users
                WHERE name = @Login AND password = @Password)
                
                """, new { Login = login, Password = SHA256.HashData(passwordBytes) }));

            return isUserExist;
        }

        public DefaultRole GetUserRole(string login)
        {
            using var connection = _connection.CreateConnection();

            var role = connection.QuerySingleOrDefault<DefaultRole>(new CommandDefinition("""
                
                SELECT name, rights
                FROM Roles
                WHERE id = (SELECT roleid
                FROM Users
                WHERE name = @Login)
                
                """, new { Login = login}));

            return role ?? throw new ArgumentNullException(nameof(role));
        }
    }


}
