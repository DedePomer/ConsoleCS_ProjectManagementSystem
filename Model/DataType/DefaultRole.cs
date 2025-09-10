using ConsoleCS_ProjectManagementSystem.Infrastructure.Enums;
using ConsoleCS_ProjectManagementSystem.Model.DataType.Base;

namespace ConsoleCS_ProjectManagementSystem.Model.DataType
{
    public class DefaultRole
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public RightsEnum? Rights { get; set; }

        public DefaultRole() { }
        public DefaultRole(BaseRole baseRole)
        {
            Id = baseRole.Id;
            Name = baseRole.Name;
            Rights = baseRole.Rights;
        }
    }
}
