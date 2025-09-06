using ConsoleCS_ProjectManagementSystem.Infrastructure.Enums;

namespace ConsoleCS_ProjectManagementSystem.Infrastructure.Services
{
    public class PermisionService
    {
        private readonly RightsEnum _permision;
        public PermisionService(RightsEnum permision)
        {
            _permision = permision;
        }

        public bool UserHasPermision(RightsEnum permision)
        {
            return (_permision & permision) == permision;
        }
    }
}
