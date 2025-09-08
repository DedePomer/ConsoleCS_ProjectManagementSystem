using ConsoleCS_ProjectManagementSystem.Infrastructure.DataBase;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Enums;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Interfaces;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Repositories;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Services;
using ConsoleCS_ProjectManagementSystem.Model.DataType;
using ConsoleCS_ProjectManagementSystem.Pages.Base;

namespace ConsoleCS_ProjectManagementSystem.Pages
{
    public partial class TaskChangeStatusPage : BasePage
    {
        private readonly DefaultUser _user;
        private readonly IDbConnectionFactory _connectionFactory;
        private readonly IPageNavigation _navigation;
        private readonly DefaultTask? _task;

        private readonly TaskService _taskService;

        private List<string> _elements = new List<string>();

        public TaskChangeStatusPage(DefaultUser user, IDbConnectionFactory connectionFactory, IPageNavigation navigation, DefaultTask? task)
        {
            _user = user;
            _connectionFactory = connectionFactory;
            _navigation = navigation;
            _task = task;

            _taskService = new TaskService(new TaskRepository(_connectionFactory));

            _navigation.Add(this);

            FillDictionary();
        }


        public override void Open()
        {
            if (_task == default)
            {
                ShowException("Не смогла передаться задача");
                _navigation.Back();
            }
            ChangeStatus();
            _navigation.Back();
        }
    }
}
