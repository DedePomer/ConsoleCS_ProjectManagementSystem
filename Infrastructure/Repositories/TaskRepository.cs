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
                VALUES (@Name, @Description, @Status, @UserId);

                """, new { Name = task.Name, Description = task.Description, Status = task.Status, UserId = task.User.Id }));

        }

        public void ChangeStatusInTask(DefaultTask task)
        {
            using var connection = _connection.CreateConnection();

            connection.Execute(new CommandDefinition("""

                UPDATE Tasks
                SET status = @Status
                WHERE id = @Id;

                """, new { Id = task.Id, Status = task.Status }));

        }

        public IEnumerable<DefaultTask> GetTasks()
        {
            using var connection = _connection.CreateConnection();

            IEnumerable<DefaultTask> tasks = connection.Query<DefaultTask, DefaultUser, DefaultTask>("""

                SELECT 
                t.id as id,
                t.name as name,
                t.description as description,
                t.status as status,
                u.id as id,
                u.name as name
                FROM Tasks t
                INNER JOIN Users u ON t.userId = u.id

                """, (task, user) =>
                {
                    task.User = user;
                    return task;
                }
                , splitOn: "id") ?? throw new ArgumentNullException(nameof(tasks));

            return tasks;
        }
    }
}
