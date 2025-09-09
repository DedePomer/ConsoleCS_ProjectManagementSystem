using ConsoleCS_ProjectManagementSystem.Infrastructure.Enums;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Services;
using ConsoleCS_ProjectManagementSystem.Model.DataType;
using ConsoleCS_ProjectManagementSystem.Model.Interfaces;

namespace ConsoleCS_ProjectManagementSystem.Pages
{
    public partial class AssignTaskPage
    {
        public override void FillDictionary()
        {
            List<DefaultUser> users = _userService
                 .GetUsers()
                 .Where(x => x.Role.Name == "User")
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

        private int GetIndexSelectedUser()
        {
            List<IElement> showElements = CreateShowList(_elements, _user);

            ShowDisplayElements(showElements, "Выберите пользователя на которого нужно назначить задачу\n");
            NavigationLoopService loopService = new NavigationLoopService(showElements, GetCountStrokeInTitle());
            if (showElements.Count > 0)
            {
                return (showElements[loopService.GetNumberSelectedElement(false)] as UserElement).User.Id;
            }
            return 0;
        }

        private void CreateNewTask()
        {
            while (true)
            {
                int selectedUserIndex = GetIndexSelectedUser();


                if (selectedUserIndex != 0)
                {
                    _task.Task.User.Id = selectedUserIndex;

                    if (_taskService.IsTaskExist(_task.Task))
                    {
                        _taskService.ChangeUserIdInTask(_task.Task);
                        break;
                    }
                    else
                    {
                        ShowException("Задача исчезла");
                    }
                }
                else
                {
                    ShowException("Создайте обычных пользователей");
                    break;
                }

            }


        }
    }
}
