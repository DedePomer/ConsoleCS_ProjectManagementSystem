using ConsoleCS_ProjectManagementSystem.Infrastructure.DataBase;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Enums;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Interfaces;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Repositories;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Services;
using ConsoleCS_ProjectManagementSystem.Model.DataType;
using ConsoleCS_ProjectManagementSystem.Model.Interfaces;
using ConsoleCS_ProjectManagementSystem.Pages.Base;

namespace ConsoleCS_ProjectManagementSystem.Pages
{
    public partial class AssignTaskPage : BasePage
    {
        private readonly DefaultUser _user;
        private readonly IPageNavigation _navigation;
        private readonly UserService _userService;
        private readonly TaskService _taskService;
        private readonly RoleService _roleService;
        private readonly TaskElement? _task;

        private Dictionary<IElement, RightsEnum> _elements = new Dictionary<IElement, RightsEnum>();

        public AssignTaskPage(DefaultUser user, IPageNavigation navigation,
            UserService userService, TaskService taskService, RoleService roleService, object? task)
        {
            _user = user;
            _navigation = navigation;
            _userService = userService;
            _taskService = taskService;
            _roleService = roleService;
            _task = task as TaskElement;

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
