using ConsoleCS_ProjectManagementSystem.Infrastructure.Enums;
using ConsoleCS_ProjectManagementSystem.Model.DataType.Rules.Default;
using ConsoleCS_ProjectManagementSystem.Model.Interfaces;

namespace ConsoleCS_ProjectManagementSystem.Model.DataType.Rules
{
    public class ExitRuleRead : DefaultRule
    {
        public string Name { get; set; } = "ExitRead";
        public string Description { get; set; } = "Закрытие приложения";
        public FilePermissionsEnum Permissions { get; set; } = FilePermissionsEnum.Read;
    }

    public class ExitRuleWrite : DefaultRule
    {
        public string Name { get; set; } = "ExitWrite";
        public string Description { get; set; } = "Закрытие приложения";
        public FilePermissionsEnum Permissions { get; set; } = FilePermissionsEnum.ReadAndWrite;
    }
}
