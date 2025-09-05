using ConsoleCS_ProjectManagementSystem.Infrastructure.Enums;

namespace ConsoleCS_ProjectManagementSystem.Model.Interfaces
{
    public interface IRole
    {
        string Name { get; set; }
        RolesEnum Rights { get; set; }
    }
}
