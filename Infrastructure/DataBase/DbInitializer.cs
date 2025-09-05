using System.Security.Cryptography;
using System.Text;
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


            connection.Execute("""
                
                CREATE TABLE If NOT EXISTS Roles
                (
                    id int PRIMARY KEY,
                    name text,
                    rights int
                );                
                
                """);

            connection.Execute("""
                
                CREATE TABLE if not EXISTS Users
                (
                	id int PRIMARY KEY,
                  	name text,
                  	password blob,
                	roleId int,
                  	FOREIGN KEY(roleId) REFERENCES Roles(id)
                );              
                
                """);

            var rolesCount = connection.ExecuteScalar<int>("""
                
                SELECT COUNT(*) FROM Roles           
                
                """);
            if (rolesCount == 0)
            {
                connection.Execute("""
                 
                 INSERT INTO Roles (id, name, rights)
                 VALUES 
                 (1,'Manager',15),
                 (2,'User',8)              
                 
                """);
            }

            var userCount = connection.ExecuteScalar<int>("""
                
                SELECT COUNT(*) FROM Users           
                
                """);
            if (userCount == 0)
            {
                const string adminPassword = "admin";
                byte[] passwordBytes = Encoding.UTF8.GetBytes(adminPassword);

                connection.Execute(new CommandDefinition("""
                
                INSERT INTO Users (id, name, password, roleid)
                VALUES  
                (1,'admin', @Password, 1)            
                
                """, new { Password = SHA256.HashData(passwordBytes) }));
            }

        }
    }
}
