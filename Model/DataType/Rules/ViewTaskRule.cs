using ConsoleCS_ProjectManagementSystem.Infrastructure.Enums;
using ConsoleCS_ProjectManagementSystem.Model.DataType.Rules.Default;

namespace ConsoleCS_ProjectManagementSystem.Model.DataType.Rules
{
    public class ViewTaskRuleRead : DefaultRule
    {
        public override string Name { get; set; } = "ViewTaskRead";
        public override string Description { get; set; } = "Просмотр задач";
        public override FilePermissionsEnum Permissions { get; set; } = FilePermissionsEnum.Read;
    }

    public class ViewTaskRuleWrite : DefaultRule
    {
        public override string Name { get; set; } = "ViewTaskWrite";
        public override string Description { get; set; } = "Просмотр задач";
        public override FilePermissionsEnum Permissions { get; set; } = FilePermissionsEnum.ReadAndWrite;
    }
}
