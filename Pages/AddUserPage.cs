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

        private UserService _userCreationService;
        private RoleService _roleCreationService;

        private Dictionary<string, string> _elements = new Dictionary<string, string>();

        public AddUserPage(DefaultUser user, IDbConnectionFactory connectionFactory, IPageNavigation navigation) 
        {
            _user = user;
            _connectionFactory = connectionFactory;
            _navigation = navigation;

            _userCreationService = new UserService(new UserRepository(_connectionFactory));
            _roleCreationService = new RoleService(new RoleRepository(_connectionFactory));

            _navigation.Add(this);

            FillDictionary();
        }
        public override void Open()
        {
            CreateNewUser();
            _navigation.Back();
        }
    }
}
