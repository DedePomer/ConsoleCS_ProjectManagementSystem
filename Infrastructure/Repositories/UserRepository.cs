using ConsoleCS_ProjectManagementSystem.Infrastructure.DataBase;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Helpers;
using ConsoleCS_ProjectManagementSystem.Model.DataType.Base;
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
                
                """, new { Login = login, Password = HashHelper.GetHash(password) }));

            return isUserExist;
        }

        public int GetUserIdByUserName(string login)
        {
            using var connection = _connection.CreateConnection();

            int id = connection.ExecuteScalar<int>(new CommandDefinition("""
                
                SELECT id
                FROM Users
                WHERE name = @Name
                
                """, new { Name = login }));

            return id;
        }

        public IEnumerable<BaseUser> GetUsers()
        {
            using var connection = _connection.CreateConnection();

            IEnumerable<BaseUser> users = connection.Query<BaseUser>("""

                SELECT id, name, password, roleId
                FROM Users

                """) ?? throw new ArgumentNullException(nameof(users));

            return users;
        }

        public void CreateUser(BaseUser user)
        {
            using var connection = _connection.CreateConnection();

            connection.Execute(new CommandDefinition("""

                INSERT INTO Users (name,password,roleid)
                VALUES (@Name, @Pasword, @Role);

                """, new { Name = user.Name, Pasword = user.Password, Role = user.RoleId }));
        }

        public BaseUser GetUserByUserId(int userId)
        {
            using var connection = _connection.CreateConnection();

            BaseUser user = connection.QuerySingleOrDefault<BaseUser>(new CommandDefinition("""
                
                SELECT id, name, password, roleId
                FROM Users
                WHERE id = @UserId
                
                """, new { UserId = userId })) ?? throw new ArgumentNullException(nameof(user));

            return user;
        }
    }


}
