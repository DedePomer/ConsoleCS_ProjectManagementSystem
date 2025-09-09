using ConsoleCS_ProjectManagementSystem.Infrastructure.Enums;

namespace ConsoleCS_ProjectManagementSystem.Model.DataType
{
    public class DefaultRole
    {
        public required int Id { get; init; }
        public required string Name { get; init; }
        public required RightsEnum Rights { get; init; }
    }
}
