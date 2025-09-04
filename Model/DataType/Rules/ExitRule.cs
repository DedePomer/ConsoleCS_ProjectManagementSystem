using ConsoleCS_ProjectManagementSystem.Infrastructure.Enums;
using ConsoleCS_ProjectManagementSystem.Model.DataType.Rules.Default;

namespace ConsoleCS_ProjectManagementSystem.Model.DataType.Rules
{
    public class ExitRuleRead : DefaultRule
    {
        public override string Name { get; set; } = "ExitRead";
        public override string Description { get; set; } = "Закрытие приложения";
        public override FilePermissionsEnum Permissions { get; set; } = FilePermissionsEnum.Read;
    }

    public class ExitRuleWrite : DefaultRule
    {
        public override string Name { get; set; } = "ExitWrite";
        public override string Description { get; set; } = "Закрытие приложения";
        public override FilePermissionsEnum Permissions { get; set; } = FilePermissionsEnum.ReadAndWrite;
    }
}
