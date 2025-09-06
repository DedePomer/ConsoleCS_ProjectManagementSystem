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
            

            
            //ExecuteSelectedElement(_elements[]);
        }

    }
}
