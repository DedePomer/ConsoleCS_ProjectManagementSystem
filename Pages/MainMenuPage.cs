using ConsoleCS_ProjectManagementSystem.Infrastructure.DataBase;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Enums;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Services;
using ConsoleCS_ProjectManagementSystem.Model.DataType;
using ConsoleCS_ProjectManagementSystem.Pages.Base;

namespace ConsoleCS_ProjectManagementSystem.Pages
{
    public partial class MainMenuPage : BasePage
    {
        private readonly DefaultUser _user;
        private readonly IDbConnectionFactory _connectionFactory;

        private Dictionary<MenuElement, RightsEnum> _elements;

        public MainMenuPage(DefaultUser user, IDbConnectionFactory connectionFactory)
        {
            _user = user;
            _connectionFactory = connectionFactory;

            FillDictionary();
        }

        public override void Open()
        {
            string title = $"Добро пожаловать {_user.Name}!\n";

            PermisionService permisionService = new PermisionService(_user.Role.Rights);

            List<string> namesElements = _elements
                .Where(x => permisionService.UserHasPermision(x.Value))
                .Select(x => x.Key.Name)
                .ToList();

            ShowDisplayElements(namesElements, title);

            NavigationLoopService loopService = new NavigationLoopService
                (namesElements, GetCountStrokeInTitle());

            loopService.GetNumberSelectedElement();
            //ExecuteSelectedElement(_elements[]);
        }

    }
}
