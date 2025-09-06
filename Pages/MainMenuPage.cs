using ConsoleCS_ProjectManagementSystem.Infrastructure.DataBase;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Enums;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Interfaces;
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

            _navigation.Add(this);

            FillDictionary();
        }

        public override void Open()
        {
            var info = GetPressedInfo();
            if (info.pressedKey == ConsoleKey.LeftArrow)
            {
                _navigation.Back();
            }
            else
            {
                _elements.Where(x => x.Key.Id == info.selectedItem)
                    .FirstOrDefault()
                    .Key
                    .Execute
                    ?.Invoke(default);
            }
        }

    }
}
