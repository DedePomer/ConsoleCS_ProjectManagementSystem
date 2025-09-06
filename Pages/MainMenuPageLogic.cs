using ConsoleCS_ProjectManagementSystem.Infrastructure.Enums;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Services;
using ConsoleCS_ProjectManagementSystem.Model.DataType;

namespace ConsoleCS_ProjectManagementSystem.Pages
{
    public partial class MainMenuPage
    {
        public override void FillDictionary()
        {
            _elements = new Dictionary<MenuElement, RightsEnum>()
            {
                [ new MenuElement(){
                    Id = 0,
                    Name = "Добавить пользователя",
                    Execute = OpenAddUser
                }] = RightsEnum.CreateUser,
                [new MenuElement()
                {
                    Id = 1,
                    Name = "Посмотреть задачи",
                    Execute = OpenTaskViewer
                }] = RightsEnum.None,
                [new MenuElement()
                {
                    Id = 2,
                    Name = "Выход",
                    Execute = OpenExit
                }] = RightsEnum.None,
            };
        }

        #region Commands
        private void OpenExit(object? obj)
        {
            Environment.Exit(0);
        }

        private void OpenTaskViewer(object? obj)
        {
            Environment.Exit(0);
        }

        private void OpenAddUser(object? obj)
        {
            Environment.Exit(0);
        }
        #endregion


        private (ConsoleKey pressedKey, int selectedItem) GetPressedInfo()
        {
            string title = $"Добро пожаловать {_user.Name}!\n";

            ConsoleKey pressedKey;
            int numberOfSelectedElement;

            List<string> namesElements = _elements
                .Where(x => _user.UserHasRights(x.Value))
                .Select(x => x.Key.Name)
                .ToList();

            ShowDisplayElements(namesElements, title);

            NavigationLoopService loopService = new NavigationLoopService
                (namesElements, GetCountStrokeInTitle());

            numberOfSelectedElement = loopService.GetNumberSelectedElement();
            pressedKey = loopService.PressedKey;

            return (pressedKey, numberOfSelectedElement);
        }
    }
}
