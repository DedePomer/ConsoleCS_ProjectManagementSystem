using ConsoleCS_ProjectManagementSystem.Infrastructure.DataBase;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Interfaces;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Repositories;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Services;
using ConsoleCS_ProjectManagementSystem.Model.DataType;
using ConsoleCS_ProjectManagementSystem.Pages.Base;

namespace ConsoleCS_ProjectManagementSystem.Pages
{
    public partial class LoginPage : BasePage
    {
        private const string LOGIN_VIEW_TEXT = "Логин";
        private const string PASSWOR_VIEW_TEXT = "Пароль";

        private DefaultUser _user;
        private readonly IDbConnectionFactory _connectionFactory;
        private readonly IPageNavigation _navigation;

        private readonly UserService _userDataService;

        private Dictionary<string, string> _inputElements = new Dictionary<string, string>();


        public LoginPage(DefaultUser user, IDbConnectionFactory connectionFactory, IPageNavigation navigation)
        {
            _user = user;
            _connectionFactory = connectionFactory;
            _navigation = navigation;
            _userDataService = new UserService(new UserRepository(_connectionFactory));

            _navigation.Add(this);

            FillDictionary();
        }

        public override void Open()
        {
            InputChek();

            _user = _userDataService.GetUser(_inputElements[LOGIN_VIEW_TEXT], _inputElements[PASSWOR_VIEW_TEXT]);

            _navigation.Open(new MainMenuPage(_user, _connectionFactory, _navigation));
        }

        #region override ShowElementsForInputs
        private void HidePassword(ref string password) /*можно добавить поддержку нажатий стрело вправо и влево*/
        {
            password = string.Empty;
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);
                if (char.IsLetterOrDigit(key.KeyChar))
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Substring(0, password.Length - 1);
                    Console.Write("\b \b");
                }
            } while (key.Key != ConsoleKey.Enter);
        }

        private string GetPassword()
        {
            string password = string.Empty;
            HidePassword(ref password);
            return password;
        }

        public override void ShowElementsForInputs(Dictionary<string, string> elements, string title = STANDART_TITLE)
        {
            Console.CursorVisible = true;
            ShowTitle(title);

            foreach (var element in elements)
            {
                if (element.Key == "Пароль")
                {
                    Console.Write(element.Key + ": ");
                    elements[element.Key] = GetPassword();
                }
                else
                {
                    Console.Write(element.Key + ": ");
                    elements[element.Key] = Console.ReadLine() ?? string.Empty;
                }
            }

            Console.CursorVisible = false;
        }
        #endregion
    }
}
