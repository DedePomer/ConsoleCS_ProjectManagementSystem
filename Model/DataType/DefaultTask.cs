using ConsoleCS_ProjectManagementSystem.Infrastructure.Enums;

namespace ConsoleCS_ProjectManagementSystem.Model.DataType
{
    public class DefaultTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public StatusEnum Status { get; set; }
        public DefaultUser User { get; set; }
    }
}
