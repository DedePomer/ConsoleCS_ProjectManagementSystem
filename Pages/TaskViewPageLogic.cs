using ConsoleCS_ProjectManagementSystem.Infrastructure.Enums;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Services;
using ConsoleCS_ProjectManagementSystem.Model.DataType;
using ConsoleCS_ProjectManagementSystem.Model.Interfaces;

namespace ConsoleCS_ProjectManagementSystem.Pages
{
    public partial class TaskViewPage
    {
        private int idElement = 0;

        public override void FillDictionary()
        {
            _elements = new Dictionary<IElement, RightsEnum>()
            {
                [new MenuElement()
                {
                    Id = idElement,
                    Name = "Добавить задачу",
                    Execute = OpenAddTask
                }] = RightsEnum.CreateTask,
            };

            idElement++;

            List<DefaultTask> tasks = _taskService
                .GetTasks()
                .Where(x => x.User.Id == _user.Id || _user.UserHasRights(RightsEnum.ViewAllTask))
                .ToList();

            foreach (var task in tasks)
            {
                _elements.Add(
                new TaskElement()
                {
                    Id = idElement++,
                    Execute = OpenDefault,
                    Task = task,
                }, RightsEnum.None);
                (_elements.Last().Key as TaskElement).SetTaskName(task);
            }
        }

        #region Commands
        private void OpenAddTask(object? obj)
        {
            _navigation.Open(new AddTaskPage(_user, _connectionFactory, _navigation));
        }

        private void OpenDefault(object? obj)
        {
            if (_user.UserHasRights(RightsEnum.ChangeStatus))
            {
                _navigation.Open(new TaskChangeStatusPage(_user, _connectionFactory, _navigation, obj));
            }
            if (_user.UserHasRights(RightsEnum.AssignTask))
            {
                _navigation.Open(new AssignTaskPage(_user, _connectionFactory, _navigation, obj));
            }
            _navigation.Back();
        }

        #endregion

        private (ConsoleKey pressedKey, IElement selectedItem) GetNumberSelectedElement()
        {
            ConsoleKey pressedKey = ConsoleKey.Enter;
            IElement selectedItem = default;

            IEnumerable<IElement> showElements = CreateShowList(_elements, _user);

            if (showElements.Count() != 0)
            {

                ShowDisplayElements(showElements);

                NavigationLoopService loopService = new NavigationLoopService
                    (showElements, GetCountStrokeInTitle());

                selectedItem = showElements.ToList()[loopService.GetNumberSelectedElement(true)];
                pressedKey = loopService.PressedKey;

            }
            return (pressedKey, selectedItem);
        }
    }
}
