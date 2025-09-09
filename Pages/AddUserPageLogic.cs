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
            _elements.Add(LOGIN_VIEW_TEXT, "");
            _elements.Add(PASSWOR_VIEW_TEXT, "");

            List<DefaultRole> defaultRoles = _roleCreationService
                .GetRoles()
                .ToList();

            foreach (DefaultRole role in defaultRoles)
            {
                _roles.Add(new RoleElement()
                {
                    Name = role.Name,
                    Role = role,
                }, RightsEnum.None);
            }
        }

        private void CreateNewUser()
        {
            IEnumerable<IElement> showElements = _roles
                .Where(x => _user.UserHasRights(x.Value))
                .Select(x => x.Key)
                .ToList();

            while (true)
            {
                int selectedItemIndex = GetSelectedItemIndex(showElements);

                DefaultUser newUser = new DefaultUser();
                newUser.Name = _elements[LOGIN_VIEW_TEXT];
                newUser.Password = _elements[PASSWOR_VIEW_TEXT];
                newUser.Role = (showElements.ToList()[selectedItemIndex] as RoleElement).Role;

                if (!_userCreationService.UserAuthentication(newUser.Name, newUser.Password))
                {
                    _userCreationService.CreateUser(newUser);
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

            ShowElementsForInputs(_elements, "Введите логин и пароль нового пользователя\n");
            loopService = new NavigationLoopService(showElements, GetCountStrokeInTitle());

            return selectedItem;
        }
    }
}
