namespace ConsoleCS_ProjectManagementSystem.Model.DataType.Base
{
    public class BaseUser
    {
        public required int Id { get; init; }
        public required string Name { get; init; }
        public required byte[] Password { get; init; }
        public required int RoleId { get; init; }
    }
}
