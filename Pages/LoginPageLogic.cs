namespace ConsoleCS_ProjectManagementSystem.Pages
{
    public partial class LoginPage
    {
        public override void FillDictionary()
        {
            _elements.Add("Логин", "");
            _elements.Add("Пароль", "");
        }

        private void InputChek()
        {
            do
            {
                ShowElementsForInputs(_elements);
                if ((_userDataService.UserAuthentication(_elements["Логин"], _elements["Пароль"])))
                    break;
                else
                    ShowException();
            } while (true);
        }
    }
}
