using ConsoleCS_ProjectManagementSystem.Infrastructure.Enums;
using ConsoleCS_ProjectManagementSystem.Model.DataType.Rules.Default;
using ConsoleCS_ProjectManagementSystem.Model.Interfaces;

namespace ConsoleCS_ProjectManagementSystem.Model.DataType.Rules
{
    public class ViewTaskRuleRead : DefaultRule
    {
        public string Name { get; set; } = "ViewTaskRead";
        public string Description { get; set; } = "Просмотр задач";
        public FilePermissionsEnum Permissions { get; set; } = FilePermissionsEnum.Read;
    }

    public class ViewTaskRuleWrite : DefaultRule
    {
        public string Name { get; set; } = "ViewTaskWrite";
        public string Description { get; set; } = "Просмотр задач";
        public FilePermissionsEnum Permissions { get; set; } = FilePermissionsEnum.ReadAndWrite;
    }
}
