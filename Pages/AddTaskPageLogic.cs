using ConsoleCS_ProjectManagementSystem.Infrastructure.Enums;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Services;
using ConsoleCS_ProjectManagementSystem.Model.DataType;

namespace ConsoleCS_ProjectManagementSystem.Pages
{
    public partial class AddTaskPage
    {
        public override void FillDictionary()
        {
            _elements.Add("Название задачи", "");
            _elements.Add("Описание", "");
        }

        private List<DefaultUser> GetDefaultUsers()
        {
            List<DefaultUser> users = _userService.GetUsers().ToList();

            return users.Where(x => x.Role.Id == 2).ToList();
        }

        private int GetIdSelectedUser()
        {
            List<DefaultUser> defaultUsers = GetDefaultUsers();

            ShowDisplayElements(defaultUsers.Select(x => x.Name).ToList(), "Выберите пользователя на которого нужно назначить задачу\n");
            NavigationLoopService loopService = new NavigationLoopService(defaultUsers.Select(x => x.Name).ToList(), GetCountStrokeInTitle());
            return defaultUsers[loopService.GetNumberSelectedElement(false)].Id;      
        }

        private void CreateNewTask()
        {
            while (true) 
            {               
                ShowElementsForInputs(_elements, "Заполните поля\n");

                DefaultTask newTask = new DefaultTask();
                newTask.Name = _elements["Название задачи"];
                newTask.Description = _elements["Описание"];
                newTask.Status = StatusEnum.None;
                newTask.User = new DefaultUser() 
                {
                    Id = GetIdSelectedUser(),
                };


                if (!_taskService.IsTaskExist(newTask))
                {
                    _taskService.CreateTask(newTask);
                    break;
                }
                else
                {
                    ShowException("Такая задача уже есть");
                }
            }
            

        }
    }
}
