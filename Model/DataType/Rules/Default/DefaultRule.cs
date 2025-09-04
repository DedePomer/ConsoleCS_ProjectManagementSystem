using ConsoleCS_ProjectManagementSystem.Infrastructure.Enums;
using ConsoleCS_ProjectManagementSystem.Model.Interfaces;

namespace ConsoleCS_ProjectManagementSystem.Model.DataType.Rules.Default
{
    public abstract class DefaultRule
    {
        public abstract string Name { get; set; }
        public abstract string Description { get; set; }
        public abstract FilePermissionsEnum Permissions { get; set; }
    }
}
