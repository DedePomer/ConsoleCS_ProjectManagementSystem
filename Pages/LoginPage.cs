using ConsoleCS_ProjectManagementSystem.Infrastructure.DataBase;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Repositories;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Services;
using ConsoleCS_ProjectManagementSystem.Model.DataType;
using ConsoleCS_ProjectManagementSystem.Pages.Base;

namespace ConsoleCS_ProjectManagementSystem.Pages
{
    public class LoginPage : BasePage
    {
        private readonly DefaultUser _user;
        private readonly IDbConnectionFactory _connectionFactory;



        public LoginPage(DefaultUser user, IDbConnectionFactory connectionFactory)
        {
            _user = user;
            _connectionFactory = connectionFactory;
        }

        public override void Open()
        {
            UserDataService userDataService = new UserDataService(new UserDataRepository(_connectionFactory));

            Dictionary<string, string> LogInData = new Dictionary<string, string>()
            {
                ["Логин"] = "",
                ["Пароль"] = ""
            };
            do{
                ShowElementsForInputs(LogInData);
            } while (userDataService.UserExist(LogInData["Логин"], LogInData["Пароль"]));
            
            userDataService.GetUser(LogInData["Логин"], LogInData["Пароль"]);
        }

        #region override ShowElementsForInputs
        private void HidePassword(string password) /*можно добавить поддержку нажатий стрело вправо и влево*/
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
            HidePassword(password);
            return password;
        }

        public override void ShowElementsForInputs(Dictionary<string, string> elements, string title = STANDART_TITLE)
        {
            Console.WriteLine(title);

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
        }
        #endregion






    }
}
