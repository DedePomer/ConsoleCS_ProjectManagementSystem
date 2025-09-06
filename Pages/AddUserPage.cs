using ConsoleCS_ProjectManagementSystem.Infrastructure.DataBase;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Interfaces;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Repositories;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Services;
using ConsoleCS_ProjectManagementSystem.Model.DataType;
using ConsoleCS_ProjectManagementSystem.Pages.Base;

namespace ConsoleCS_ProjectManagementSystem.Pages
{
    public partial class AddUserPage : BasePage
    {
        private readonly DefaultUser _user;
        private readonly IDbConnectionFactory _connectionFactory;
        private readonly IPageNavigation _navigation;

        private UserCreationService _userCreationService;

        private Dictionary<string, string> _elements = new Dictionary<string, string>();

        public AddUserPage(DefaultUser user, IDbConnectionFactory connectionFactory, IPageNavigation navigation) 
        {
            _user = user;
            _connectionFactory = connectionFactory;
            _navigation = navigation;
            _userCreationService = new UserCreationService(new UserCreationRepository(_connectionFactory));

            _navigation.Add(this);

            FillDictionary();
        }
        public override void Open()
        {
            List<DefaultRole> roles = _userCreationService
                .GetRoles()
                .ToList();
            var RolesNames = roles
                .Select(x => x.Name)
                .ToList();

            ShowDisplayElements(RolesNames, "Выберите роль нового пользователя\n");
            NavigationLoopService loopService = new NavigationLoopService(RolesNames, GetCountStrokeInTitle());
            int roleId = loopService.GetNumberSelectedElement();

            ShowElementsForInputs(_elements, "Введите логин и пароль нового пользователя\n");
            loopService = new NavigationLoopService(RolesNames, GetCountStrokeInTitle());

            DefaultUser newUser = new DefaultUser();
            newUser.Name = _elements["Логин"];
            newUser.Password = _elements["Пароль"];
            newUser.Role = roles[roleId];

            if (!_userCreationService.UserExist(newUser.Name))
            {
                _userCreationService.CreateUser(newUser);
                _navigation.Back();
            }
            else 
            {
                ShowException("Такой пользователь существует");
            }
        }
    }
}
