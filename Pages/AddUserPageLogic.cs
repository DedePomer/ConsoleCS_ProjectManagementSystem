using ConsoleCS_ProjectManagementSystem.Infrastructure.Enums;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Services;
using ConsoleCS_ProjectManagementSystem.Model.DataType;
using ConsoleCS_ProjectManagementSystem.Model.Interfaces;

namespace ConsoleCS_ProjectManagementSystem.Pages
{
    public partial class AddUserPage
    {
        public override void FillDictionary()
        {
            _inputElements.Add(LOGIN_VIEW_TEXT, "");
            _inputElements.Add(PASSWOR_VIEW_TEXT, "");

            List<DefaultRole> defaultRoles = _roleService
                .GetRoles()
                .ToList();

            foreach (DefaultRole role in defaultRoles)
            {
                _elements.Add(new RoleElement()
                {
                    Name = role.Name,
                    Role = role,
                }, RightsEnum.None);
            }
        }

        private void CreateNewUser()
        {
            IEnumerable<IElement> showElements = CreateShowList(_elements, _user);

            while (true)
            {
                int selectedItemIndex = GetSelectedItemIndex(showElements);

                DefaultUser newUser = new DefaultUser();
                newUser.Name = _inputElements[LOGIN_VIEW_TEXT];
                newUser.Password = _inputElements[PASSWOR_VIEW_TEXT];
                newUser.Role = (showElements.ToList()[selectedItemIndex] as RoleElement).Role;

                if (!_userService.UserAuthentication(newUser.Name, newUser.Password))
                {
                    _userService.CreateUser(newUser);
                    break;
                }
                else
                {
                    ShowException("Такой пользователь уже существует");
                }
            }
        }

        private int GetSelectedItemIndex(IEnumerable<IElement> showElements)
        {
            ShowDisplayElements(showElements, "Выберите роль нового пользователя\n");
            NavigationLoopService loopService = new NavigationLoopService(showElements, GetCountStrokeInTitle());
            int selectedItem = loopService.GetNumberSelectedElement(false);

            ShowElementsForInputs(_inputElements, "Введите логин и пароль нового пользователя\n");
            loopService = new NavigationLoopService(showElements, GetCountStrokeInTitle());

            return selectedItem;
        }
    }
}
