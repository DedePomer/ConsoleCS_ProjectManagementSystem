using ConsoleCS_ProjectManagementSystem.Infrastructure.Enums;
using ConsoleCS_ProjectManagementSystem.Model.Interfaces;

namespace ConsoleCS_ProjectManagementSystem.Model.DataType.Rules.Default
{
    public class DefaultRule : IRule
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public FilePermissionsEnum Permissions { get; set; }
    }
}
