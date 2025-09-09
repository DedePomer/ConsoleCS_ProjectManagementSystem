using ConsoleCS_ProjectManagementSystem.Infrastructure.Enums;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Services;
using ConsoleCS_ProjectManagementSystem.Model.DataType;
using ConsoleCS_ProjectManagementSystem.Model.Interfaces;

namespace ConsoleCS_ProjectManagementSystem.Pages
{
    public partial class AddTaskPage
    {
        private RightsEnum GetViewRight(DefaultUser user)
        {
            if (user.Role.Id == 1)
                return RightsEnum.ViewManager;
            else
                return RightsEnum.ViewDefaultUser;
        }

        public override void FillDictionary()
        {
            _inputElements.Add(TASK_NAME_VIEW_TEXT, "");
            _inputElements.Add(TASK_DESCRIPTION_VIEW_TEXT, "");

            List<DefaultUser> users = _userService
                .GetUsers()
                .ToList();

            foreach (DefaultUser user in users)
            {
                _elements.Add(new UserElement()
                {
                    Name = user.Name,
                    User = user,
                }, GetViewRight(user));               
            }
        }



        private int GetIdSelectedUser()
        {
            IEnumerable<IElement> showElements = CreateShowList(_elements, _user);


            ShowDisplayElements(showElements, "Выберите пользователя на которого нужно назначить задачу\n");
            NavigationLoopService loopService = new NavigationLoopService(showElements, GetCountStrokeInTitle());
            return (showElements.ToList())[loopService.GetNumberSelectedElement(false)].Id;
        }

        private void CreateNewTask()
        {
            while (true)
            {
                ShowElementsForInputs(_inputElements, "Заполните поля\n");

                DefaultTask newTask = new DefaultTask();
                newTask.Name = _inputElements[TASK_NAME_VIEW_TEXT];
                newTask.Description = _inputElements[TASK_DESCRIPTION_VIEW_TEXT];
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
