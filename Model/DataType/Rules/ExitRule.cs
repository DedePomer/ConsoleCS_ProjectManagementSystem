using ConsoleCS_ProjectManagementSystem.Infrastructure.Enums;
using ConsoleCS_ProjectManagementSystem.Model.Interfaces;

namespace ConsoleCS_ProjectManagementSystem.Model.DataType.Rules
{
    public class ExitRuleRead : IRule
    {
        public string Name { get; set; } = "Exit";
        public string Description { get; set; } = "Закрытие приложения";
        public FilePermissionsEnum Permissions { get; set; } = FilePermissionsEnum.Read;
    }

    public class ExitRuleWrite : IRule
    {
        public string Name { get; set; } = "Exit";
        public string Description { get; set; } = "Закрытие приложения";
        public FilePermissionsEnum Permissions { get; set; } = FilePermissionsEnum.ReadAndWrite;
    }
}
