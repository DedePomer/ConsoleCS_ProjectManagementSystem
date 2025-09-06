using ConsoleCS_ProjectManagementSystem.Infrastructure.DataBase;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Enums;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Interfaces;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Services;
using ConsoleCS_ProjectManagementSystem.Model.DataType;
using ConsoleCS_ProjectManagementSystem.Pages.Base;

namespace ConsoleCS_ProjectManagementSystem.Pages
{
    public partial class MainMenuPage : BasePage
    {
        private readonly DefaultUser _user;
        private readonly IDbConnectionFactory _connectionFactory;
        private readonly IPageNavigation _navigation;

        private Dictionary<MenuElement, RightsEnum> _elements = new Dictionary<MenuElement, RightsEnum>();

        public MainMenuPage(DefaultUser user, IDbConnectionFactory connectionFactory, IPageNavigation navigation)
        {
            _user = user;
            _connectionFactory = connectionFactory;
            _navigation = navigation;

            FillDictionary();
        }

        public override void Open()
        {
            string title = $"Добро пожаловать {_user.Name}!\n";

            UserPermisionService permisionService = new UserPermisionService(_user.Role.Rights);

            List<string> namesElements = _elements
                .Where(x => _user.UserHasRights(x.Value))
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
