using ConsoleCS_ProjectManagementSystem.Infrastructure.Enums;

namespace ConsoleCS_ProjectManagementSystem.Model.Interfaces
{
    public interface IRule
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public FilePermissionsEnum Permissions { get; set; }  
    }
}
