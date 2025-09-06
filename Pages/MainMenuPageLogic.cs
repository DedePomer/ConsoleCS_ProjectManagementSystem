using ConsoleCS_ProjectManagementSystem.Infrastructure.Enums;
using ConsoleCS_ProjectManagementSystem.Model.DataType;

namespace ConsoleCS_ProjectManagementSystem.Pages
{
    public partial class MainMenuPage
    {
        private void FillDictionary()
        {
            _elements = new Dictionary<MenuElement, RightsEnum>()
            {
                [ new MenuElement(){
                    Id = 1,
                    Name = "Добавить пользователя",
                    Execute = (object? obj) => { }
                }] = RightsEnum.CreateUser,
                [new MenuElement()
                {
                    Id = 2,
                    Name = "Посмотреть задачи",
                    Execute = (object? obj) => { }
                }] = RightsEnum.None,
                [new MenuElement()
                {
                    Id = 3,
                    Name = "Выход",
                    Execute = (object? obj) => { }
                }] = RightsEnum.None,
            };
        }


    }
}
