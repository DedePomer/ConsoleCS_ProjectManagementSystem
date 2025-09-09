namespace ConsoleCS_ProjectManagementSystem.Pages
{
    public partial class LoginPage
    {
        public override void FillDictionary()
        {
            _inputElements.Add(LOGIN_VIEW_TEXT, "");
            _inputElements.Add(PASSWOR_VIEW_TEXT, "");
        }

        private void InputChek()
        {
            do
            {
                ShowElementsForInputs(_inputElements);
                if ((_userDataService.UserAuthentication(_inputElements[LOGIN_VIEW_TEXT], _inputElements[PASSWOR_VIEW_TEXT])))
                    break;
                else
                    ShowException();
            } while (true);
        }
    }
}
