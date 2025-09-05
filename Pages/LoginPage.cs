using ConsoleCS_ProjectManagementSystem.Model.DataType;
using ConsoleCS_ProjectManagementSystem.Pages.Base;

namespace ConsoleCS_ProjectManagementSystem.Pages
{
    public class LoginPage : BasePage
    {
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
