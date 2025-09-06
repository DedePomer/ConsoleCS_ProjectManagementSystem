using ConsoleCS_ProjectManagementSystem.Infrastructure.Enums;

namespace ConsoleCS_ProjectManagementSystem.Infrastructure.Services
{
    public class UserPermisionService
    {
        private readonly RightsEnum _permision;
        public UserPermisionService(RightsEnum permision)
        {
            _permision = permision;
        }

        public bool UserHasPermision(RightsEnum permision)
        {
            return (_permision & permision) == permision;
        }
    }
}
