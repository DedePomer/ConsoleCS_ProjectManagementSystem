using ConsoleCS_ProjectManagementSystem.Infrastructure.DataBase;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Services;
using ConsoleCS_ProjectManagementSystem.Model.DataType;
using Dapper;

namespace ConsoleCS_ProjectManagementSystem.Infrastructure.Repositories
{
    public class UserRepository
    {
        private readonly IDbConnectionFactory _connection;
        public UserRepository(IDbConnectionFactory connection)
        {
            _connection = connection;
        }

        public bool UserAuthentication(string login, string password)
        {
            using var connection = _connection.CreateConnection();

            bool isUserExist = connection.ExecuteScalar<bool>(new CommandDefinition("""
                
                SELECT EXISTS(
                SELECT 1
                FROM Users
                WHERE name = @Login AND password = @Password)
                
                """, new { Login = login, Password = HashService.GetHash(password) }));

            return isUserExist;
        }

        public DefaultRole GetUserRole(string login)
        {
            using var connection = _connection.CreateConnection();

            var role = connection.QuerySingleOrDefault<DefaultRole>(new CommandDefinition("""
                
                SELECT id, name, rights
                FROM Roles
                WHERE id = (SELECT roleid
                FROM Users
                WHERE name = @Login)
                
                """, new { Login = login }));

            return role ?? throw new ArgumentNullException(nameof(role));
        }

        public int GetUserId(string login)
        {
            using var connection = _connection.CreateConnection();

            int id = connection.ExecuteScalar<int>(new CommandDefinition("""
                
                SELECT id
                FROM Users
                WHERE name = @Name
                
                """, new { Name = login }));

            return id;
        }

        public void CreateUser(DefaultUser user)
        {
            using var connection = _connection.CreateConnection();

            connection.Execute(new CommandDefinition("""

                INSERT INTO Users (name,password,roleid)
                VALUES (@Name, @Pasword, @Role);

                """, new { Name = user.Name, Pasword = HashService.GetHash(user.Password), Role = user.Role.Id }));
        }
    }


}
