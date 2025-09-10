using ConsoleCS_ProjectManagementSystem.Infrastructure.DataBase;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Enums;
using ConsoleCS_ProjectManagementSystem.Model.DataType;
using ConsoleCS_ProjectManagementSystem.Model.DataType.Base;
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

        public bool IsTaskExistByName(string name)
        {
            using var connection = _connection.CreateConnection();

            bool isTaskExist = connection.ExecuteScalar<bool>(new CommandDefinition("""
                
                SELECT EXISTS(
                SELECT 1
                FROM Tasks
                WHERE name = @Name)
                
                """, new { Name = name }));

            return isTaskExist;
        }

        public void CreateTask(BaseTask task)
        {
            using var connection = _connection.CreateConnection();

            connection.Execute(new CommandDefinition("""

                INSERT INTO Tasks (name,description,status,userId)
                VALUES (@Name, @Description, @Status, @UserId);

                """, new { Name = task.Name, Description = task.Description, Status = task.Status, UserId = task.UserId }));

        }

        public void ChangeStatusInTask(StatusEnum status, int id)
        {
            using var connection = _connection.CreateConnection();

            connection.Execute(new CommandDefinition("""

                UPDATE Tasks
                SET status = @Status
                WHERE id = @Id;

                """, new { Id = id, Status = status }));

        }

        public void ChangeUserIdInTask(int userId, int id)
        {
            using var connection = _connection.CreateConnection();

            connection.Execute(new CommandDefinition("""

                UPDATE Tasks
                SET userId = @UserId
                WHERE id = @Id;

                """, new { Id = id, UserId = userId }));

        }

        public IEnumerable<BaseTask> GetTasks()
        {
            using var connection = _connection.CreateConnection();

            IEnumerable<BaseTask> tasks = connection.Query<BaseTask>("""

                SELECT id, name, description, status, userId
                FROM Roles

                """) ?? throw new ArgumentNullException(nameof(tasks));

            return tasks;
        }
    }
}
