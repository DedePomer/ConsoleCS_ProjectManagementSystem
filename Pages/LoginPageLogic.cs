namespace ConsoleCS_ProjectManagementSystem.Pages
{
    public partial class LoginPage
    {
        public override void FillDictionary()
        {
            _elements.Add(LOGIN_VIEW_TEXT, "");
            _elements.Add(PASSWOR_VIEW_TEXT, "");
        }

        private void InputChek()
        {
            do
            {
                ShowElementsForInputs(_elements);
                if ((_userDataService.UserAuthentication(_elements[LOGIN_VIEW_TEXT], _elements[PASSWOR_VIEW_TEXT])))
                    break;
                else
                    ShowException();
            } while (true);
        }
    }
}
