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
    public partial class TaskViewPage : BasePage
    {
        private readonly DefaultUser _user;
        private readonly IDbConnectionFactory _connectionFactory;
        private readonly IPageNavigation _navigation;

        private readonly TaskService _taskService;

        private Dictionary<IElement, RightsEnum> _elements = new Dictionary<IElement, RightsEnum>();

        public TaskViewPage(DefaultUser user, IDbConnectionFactory connectionFactory, IPageNavigation navigation)
        {
            _user = user;
            _connectionFactory = connectionFactory;
            _navigation = navigation;

            _taskService = new TaskService(new TaskRepository(_connectionFactory));

            _navigation.Add(this);
        }

        public override void Open()
        {
            FillDictionary();
            var info = GetNumberSelectedElement();
            if (info.pressedKey == ConsoleKey.LeftArrow)
            {
                _navigation.Back();
            }
            else
            {
                IElement selectedElement = _elements.Where(x => x.Key.Id == info.selectedItem)
                    .FirstOrDefault()
                    .Key;
                selectedElement.Execute?.Invoke(selectedElement);
            }
        }
    }
}
