using ConsoleCS_ProjectManagementSystem.Infrastructure.Enums;
using ConsoleCS_ProjectManagementSystem.Model.DataType.Rules.Default;
using ConsoleCS_ProjectManagementSystem.Model.Interfaces;

namespace ConsoleCS_ProjectManagementSystem.Model.DataType.Rules
{
    public class AddUserRuleRead: DefaultRule
    {
        public override string Name { get; set; } = "AddUserRead";
        public override string Description { get; set; } = "Добавление пользователя";
        public override FilePermissionsEnum Permissions { get; set; } = FilePermissionsEnum.Read;    
    }

    public class AddUserRuleWrite : DefaultRule
    {
        public override string Name { get; set; } = "AddUserWrite";
        public override string Description { get; set; } = "Добавление пользователя";
        public override FilePermissionsEnum Permissions { get; set; } = FilePermissionsEnum.ReadAndWrite;
    }
}
