using ConsoleCS_ProjectManagementSystem.Infrastructure.Enums;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Services;
using ConsoleCS_ProjectManagementSystem.Model.DataType;
using ConsoleCS_ProjectManagementSystem.Model.Interfaces;

namespace ConsoleCS_ProjectManagementSystem.Pages
{
    public partial class AddTaskPage
    {
        public override void FillDictionary()
        {
            _inputElements.Add(TASK_NAME_VIEW_TEXT, "");
            _inputElements.Add(TASK_DESCRIPTION_VIEW_TEXT, "");

            List<DefaultUser> users = _userService
                .GetUsers()
                .Where(x => x.Id == 1)
                .ToList();

            foreach (DefaultUser user in users)
            {
                _elements.Add(new UserElement()
                {
                    Name = user.Name,
                    User = user,
                }, RightsEnum.None);
            }
        }



        private int GetIdSelectedUser()
        {
            List<IElement> showElements = CreateShowList(_elements, _user);


            ShowDisplayElements(showElements, "Выберите пользователя на которого нужно назначить задачу\n");
            NavigationLoopService loopService = new NavigationLoopService(showElements, GetCountStrokeInTitle());
            return (showElements[loopService.GetNumberSelectedElement(false)] as UserElement).User.Id;
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
