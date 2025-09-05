using System.Runtime.CompilerServices;
using ConsoleCS_ProjectManagementSystem.Model.DataType;
using ConsoleCS_ProjectManagementSystem.Pages.Base;

namespace ConsoleCS_ProjectManagementSystem.Pages
{
    public class LoginPage : BasePage
    {

        public override void ShowElementsForInputs(Dictionary<string, string> elements, string title = STANDART_TITLE)
        {
            Console.WriteLine(title);

            foreach (var element in elements)
            {
                if (element.Key == "Пароль")
                {
                    Console.Write(element.Key + ": ");
                    elements[element.Key] = Console.ReadLine() ?? "";
                }
                else 
                {
                    Console.Write(element.Key + ": ");
                    elements[element.Key] = Console.ReadLine() ?? "";
                }               
            }
        }
        public override void Open(DefaultUser user)
        {
            Dictionary<string, string> inputElements = new Dictionary<string, string>()
            {
                ["Логин"] = "",
                ["Пароль"] = ""
            };
            ShowElementsForInputs(inputElements);
        }

        
    }
}
