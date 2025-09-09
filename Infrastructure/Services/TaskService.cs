using ConsoleCS_ProjectManagementSystem.Infrastructure.Repositories;
using ConsoleCS_ProjectManagementSystem.Model.DataType;

namespace ConsoleCS_ProjectManagementSystem.Infrastructure.Services
{
    public class TaskService
    {
        private readonly TaskRepository _repository;
        public TaskService(TaskRepository repository)
        {
            _repository = repository;
        }

        public bool IsTaskExist(DefaultTask task)
        {
            return _repository.IsTaskExist(task);
        }

        public void CreateTask(DefaultTask task)
        {
            _repository.CreateTask(task);
        }

        public IEnumerable<DefaultTask> GetTasks()
        {
            return _repository.GetTasks();
        }


        public void ChangeStatusInTask(DefaultTask task)
        { 
            _repository.ChangeStatusInTask(task);
        }

        public void ChangeUserIdInTask(DefaultTask task)
        {
            _repository.ChangeUserIdInTask(task);
        }
    }
}
