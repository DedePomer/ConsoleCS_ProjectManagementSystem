using ConsoleCS_ProjectManagementSystem.Infrastructure.Services;
using ConsoleCS_ProjectManagementSystem.Model.DataType;

namespace ConsoleCS_ProjectManagementSystem.Pages
{
    public partial class AddUserPage
    {
        public override void FillDictionary()
        {
            _elements.Add("Логин","");
            _elements.Add("Пароль", "");
        }

        private void CreateNewUser()
        {
            List<DefaultRole> roles = _userCreationService
                .GetRoles()
                .ToList();
            var rolesNames = roles
                .Select(x => x.Name)
                .ToList();

            while (true)
            {
                int roleId = GetSelectedItem(rolesNames);

                DefaultUser newUser = new DefaultUser();
                newUser.Name = _elements["Логин"];
                newUser.Password = _elements["Пароль"];
                newUser.Role = roles[roleId];

                if (!_userCreationService.UserExist(newUser.Name))
                {
                    _userCreationService.CreateUser(newUser);
                    break;
                }
                else
                {
                    ShowException("Такой пользователь существует");
                }
            }
        }

        private int GetSelectedItem(List<string> rolesNames)
        {
            ShowDisplayElements(rolesNames, "Выберите роль нового пользователя\n");
            NavigationLoopService loopService = new NavigationLoopService(rolesNames, GetCountStrokeInTitle());
            int selectedItem = loopService.GetNumberSelectedElement(false);

            ShowElementsForInputs(_elements, "Введите логин и пароль нового пользователя\n");
            loopService = new NavigationLoopService(rolesNames, GetCountStrokeInTitle());

            return selectedItem;
        }
    }
}
