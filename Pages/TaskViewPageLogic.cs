using ConsoleCS_ProjectManagementSystem.Infrastructure.Enums;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Services;
using ConsoleCS_ProjectManagementSystem.Model.DataType;
using ConsoleCS_ProjectManagementSystem.Model.Interfaces;

namespace ConsoleCS_ProjectManagementSystem.Pages
{
    public partial class TaskViewPage
    {
        public override void FillDictionary()
        {
            _elements = new Dictionary<IElement, RightsEnum>()
            {
                [new MenuElement()
                {
                    Id = 0,
                    Name = "Добавить задачу",
                    Execute = OpenAddTask
                }] = RightsEnum.CreateTask,              
            };
        }

        #region Commands
        private void OpenAddTask(object? obj)
        {
            _navigation.Open(new AddTaskPage(_user, _connectionFactory, _navigation));
        }

        #endregion

        private (ConsoleKey pressedKey, int selectedItem) GetNumberSelectedElement()
        {
            ConsoleKey pressedKey;
            int selectedItem;

            List<string> namesElements = _elements
               .Where(x => _user.UserHasRights(x.Value))
               .Select(x => x.Key.Name)
               .ToList();

            ShowDisplayElements(namesElements);

            NavigationLoopService loopService = new NavigationLoopService
                (namesElements, GetCountStrokeInTitle());

            selectedItem = loopService.GetNumberSelectedElement(true);
            pressedKey = loopService.PressedKey;


            return (pressedKey, selectedItem);
        }
    }
}
