using ConsoleCS_ProjectManagementSystem.Infrastructure.Enums;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Repositories;
using ConsoleCS_ProjectManagementSystem.Model.DataType;
using ConsoleCS_ProjectManagementSystem.Model.DataType.Base;

namespace ConsoleCS_ProjectManagementSystem.Infrastructure.Services
{
    public class TaskService
    {
        private readonly TaskRepository _repository;
        private readonly UserService _userService;
        public TaskService(TaskRepository repository, UserService userService)
        {
            _repository = repository;
            _userService = userService;
        }

        public bool IsTaskExistByName(DefaultTask task)
        {
            string name = task.Name ?? string.Empty;
            return _repository.IsTaskExistByName(name);
        }

        public void CreateTask(DefaultTask task)
        {
            BaseTask baseTask = new BaseTask()
            {
                Id = 1,
                Name = task.Name ?? string.Empty,
                Description = task.Description ?? string.Empty,
                Status = task.Status ?? StatusEnum.None,
                UserId = task.User?.Id ?? 1
            };

            _repository.CreateTask(baseTask);
        }

        public IEnumerable<DefaultTask> GetTasks()
        {
            List<BaseTask> baseTasks = _repository
               .GetTasks()
               .ToList();
            List<DefaultTask> tasks = new();

            foreach (BaseTask baseTask in baseTasks)
            {
                tasks.Add(new DefaultTask(baseTask));

                int userId = baseTask.UserId;
                tasks.Last().User = _userService.GetUserByUserId(userId);
            }

            return tasks;
        }


        public void ChangeStatusInTask(DefaultTask task)
        {
            StatusEnum status = task.Status ?? StatusEnum.None;
            int id = task.Id ?? 1;
            _repository.ChangeStatusInTask(status, id);
        }

        public void ChangeUserIdInTask(DefaultTask task)
        {
            int userId = task.User?.Id ?? 1;
            int id = task.Id ?? 1;
            _repository.ChangeUserIdInTask(userId, id);
        }
    }
}
