using ConsoleCS_ProjectManagementSystem.Infrastructure.Enums;
using ConsoleCS_ProjectManagementSystem.Model.Interfaces;

namespace ConsoleCS_ProjectManagementSystem.Model.DataType.Rules
{
    public class AddUserRuleRead: IRule
    {
        public string Name { get; set; } = "AddUserRead";
        public string Description { get; set; } = "Добавление пользователя";
        public FilePermissionsEnum Permissions { get; set; } = FilePermissionsEnum.Read;
    }

    public class AddUserRuleWrite : IRule
    {
        public string Name { get; set; } = "AddUserWrite";
        public string Description { get; set; } = "Добавление пользователя";
        public FilePermissionsEnum Permissions { get; set; } = FilePermissionsEnum.ReadAndWrite;
    }
}
