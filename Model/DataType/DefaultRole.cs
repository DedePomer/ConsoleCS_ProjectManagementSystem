using ConsoleCS_ProjectManagementSystem.Infrastructure.Enums;

namespace ConsoleCS_ProjectManagementSystem.Model.DataType
{
    public class DefaultRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RightsEnum Rights { get; set; }
    }
}
