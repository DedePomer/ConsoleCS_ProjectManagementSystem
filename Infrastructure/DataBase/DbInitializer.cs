using ConsoleCS_ProjectManagementSystem.Infrastructure.Services;
using Dapper;

namespace ConsoleCS_ProjectManagementSystem.Infrastructure.DataBase
{
    public class DbInitializer
    {
        private readonly IDbConnectionFactory _connectionFactory;
        public DbInitializer(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void Initialize()
        {
            using var connection = _connectionFactory.CreateConnection();

            //создание таблиц

            connection.Execute("""
                
                CREATE TABLE If NOT EXISTS Roles
                (
                    id INTEGER PRIMARY KEY,
                    name text,
                    rights int
                );                
                
                """);

            connection.Execute("""
                
                CREATE TABLE if not EXISTS Users
                (
                	id INTEGER PRIMARY KEY,
                  	name text,
                  	password blob,
                	roleId int,
                  	FOREIGN KEY(roleId) REFERENCES Roles(id)
                );              
                
                """);

            connection.Execute("""

                CREATE TABLE if not EXISTS Tasks
                (
                   	id INTEGER PRIMARY KEY,
                    name text,
                    description text,
                  	status int,
                   	userId int,
                    FOREIGN KEY(userId) REFERENCES Users(id)
                );

                """);

            //заполнение таблиц

            var rolesCount = connection.ExecuteScalar<int>("""
                
                SELECT COUNT(*) FROM Roles           
                
                """);
            if (rolesCount == 0)
            {
                connection.Execute("""
                 
                 INSERT INTO Roles (id, name, rights)
                 VALUES 
                 (1,'Manager',23),
                 (2,'User',8)              
                 
                """);
            }

            var userCount = connection.ExecuteScalar<int>("""
                
                SELECT COUNT(*) FROM Users           
                
                """);
            if (userCount == 0)
            {
                const string adminPassword = "admin";

                connection.Execute(new CommandDefinition("""
                
                INSERT INTO Users (id, name, password, roleid)
                VALUES  
                (1,'admin', @Password, 1)            
                
                """, new { Password = HashService.GetHash(adminPassword) }));
            }

        }
    }
}
