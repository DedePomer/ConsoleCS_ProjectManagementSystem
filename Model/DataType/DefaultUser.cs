using ConsoleCS_ProjectManagementSystem.Infrastructure.Enums;
using System.Security;

namespace ConsoleCS_ProjectManagementSystem.Model.DataType
{
    public class DefaultUser
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public DefaultRole Role { get; set; }

        public bool UserHasRights(RightsEnum right)
        {
            return (Role.Rights & right) == right;
        }
    }
}

