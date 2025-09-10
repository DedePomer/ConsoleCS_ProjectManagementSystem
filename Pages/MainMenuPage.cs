using ConsoleCS_ProjectManagementSystem.Infrastructure.Enums;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Interfaces;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Services;
using ConsoleCS_ProjectManagementSystem.Model.DataType;
using ConsoleCS_ProjectManagementSystem.Model.Interfaces;
using ConsoleCS_ProjectManagementSystem.Pages.Base;

namespace ConsoleCS_ProjectManagementSystem.Pages
{
    public partial class MainMenuPage : BasePage
    {
        private readonly DefaultUser _user;
        private readonly IPageNavigation _navigation;
        private readonly UserService _userService;
        private readonly TaskService _taskService;
        private readonly RoleService _roleService;

        private Dictionary<IElement, RightsEnum> _elements = new Dictionary<IElement, RightsEnum>();

        public MainMenuPage(DefaultUser user, IPageNavigation navigation,
            UserService userService, TaskService taskService, RoleService roleService)
        {
            _user = user;
            _navigation = navigation;
            _userService = userService;
            _taskService = taskService;
            _roleService = roleService;

            _navigation.Add(this);

            FillDictionary();
        }

        public override void Open()
        {
            var info = GetSelectedElement();
            if (info.pressedKey == ConsoleKey.LeftArrow)
            {
                _navigation.Back();
            }
            else
            {
                info.selectedItem.Execute?.Invoke(info.selectedItem);
            }
        }

    }
}
