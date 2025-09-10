using ConsoleCS_ProjectManagementSystem.Infrastructure.Enums;

namespace ConsoleCS_ProjectManagementSystem.Model.DataType.Base
{
    public class BaseTask
    {
        public required int Id { get; init; }
        public required string Name { get; init; }
        public required string Description { get; init; }
        public required StatusEnum Status { get; init; }
        public required int UserId { get; init; }
    }
}
