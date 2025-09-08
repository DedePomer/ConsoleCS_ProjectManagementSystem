using ConsoleCS_ProjectManagementSystem.Infrastructure.DataBase;
using ConsoleCS_ProjectManagementSystem.Model.DataType;
using Dapper;

namespace ConsoleCS_ProjectManagementSystem.Infrastructure.Repositories
{
    public class TaskRepository
    {
        private readonly IDbConnectionFactory _connection;
        public TaskRepository(IDbConnectionFactory connection)
        {
            _connection = connection;
        }

        public bool IsTaskExist(DefaultTask task)
        {
            using var connection = _connection.CreateConnection();

            bool isTaskExist = connection.ExecuteScalar<bool>(new CommandDefinition("""
                
                SELECT EXISTS(
                SELECT 1
                FROM Tasks
                WHERE name = @Name)
                
                """, new { Name = task.Name }));

            return isTaskExist;
        }

        public void CreateTask(DefaultTask task)
        {
            using var connection = _connection.CreateConnection();

            connection.Execute(new CommandDefinition("""

                INSERT INTO Tasks (name,description,status,userId)
                VALUES (@Name, @Pasword, @Role);

                """, new { Name = task.Name, Description = task.Description, Status = task.Status, task.User.Id }));

        }
    }
}
