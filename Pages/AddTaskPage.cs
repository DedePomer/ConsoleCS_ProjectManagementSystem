using ConsoleCS_ProjectManagementSystem.Infrastructure.Enums;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Interfaces;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Services;
using ConsoleCS_ProjectManagementSystem.Model.DataType;
using ConsoleCS_ProjectManagementSystem.Model.Interfaces;
using ConsoleCS_ProjectManagementSystem.Pages.Base;

namespace ConsoleCS_ProjectManagementSystem.Pages
{
    public partial class AddTaskPage : BasePage
    {
        private const string TASK_NAME_VIEW_TEXT = "Название задачи";
        private const string TASK_DESCRIPTION_VIEW_TEXT = "Описание";

        private readonly DefaultUser _user;
        private readonly IPageNavigation _navigation;
        private readonly UserService _userService;
        private readonly TaskService _taskService;
        private readonly RoleService _roleService;

        private Dictionary<string, string> _inputElements = new Dictionary<string, string>();
        private Dictionary<IElement, RightsEnum> _elements = new Dictionary<IElement, RightsEnum>();

        public AddTaskPage(DefaultUser user, IPageNavigation navigation,
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
            CreateNewTask();
            _navigation.Back();
        }

    }
}
