using ConsoleCS_ProjectManagementSystem.Infrastructure.Builders;
using ConsoleCS_ProjectManagementSystem.Model.DataType;
using ConsoleCS_ProjectManagementSystem.Pages.Base;

namespace ConsoleCS_ProjectManagementSystem.Pages
{
    public class MainMenuPage : BasePage
    {
        public override void Open()
        {
            MainMenuPageBuilder builder = new MainMenuPageBuilder();
            List<MenuElement> elements = builder
                .AddElement(1, "Создать нового пользователя", (object? obj) => { Environment.Exit(0); })
                .AddElement(2, "Посмотреть задачи", (object? obj) => { Environment.Exit(0); })
                .AddElement(3, "Выход", (object? obj) => { Environment.Exit(0); })
                .Build();

            DisplayPage(elements.Select(x => x.Name).ToList());


        }

    }
}
