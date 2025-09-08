using ConsoleCS_ProjectManagementSystem.Infrastructure.DataBase;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Interfaces;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Repositories;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Services;
using ConsoleCS_ProjectManagementSystem.Model.DataType;
using ConsoleCS_ProjectManagementSystem.Pages.Base;

namespace ConsoleCS_ProjectManagementSystem.Pages
{
    public partial class AddTaskPage : BasePage
    {

        private readonly DefaultUser _user;
        private readonly IDbConnectionFactory _connectionFactory;
        private readonly IPageNavigation _navigation;

        private readonly TaskService _taskService;
        private readonly UserService _userService;

        private Dictionary<string, string> _elements = new Dictionary<string, string>();

        public AddTaskPage(DefaultUser user, IDbConnectionFactory connectionFactory, IPageNavigation navigation)
        {
            _user = user;
            _connectionFactory = connectionFactory;
            _navigation = navigation;

            _taskService = new TaskService(new TaskRepository(_connectionFactory));
            _userService = new UserService(new UserRepository(_connectionFactory));

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
