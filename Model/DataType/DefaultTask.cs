using ConsoleCS_ProjectManagementSystem.Infrastructure.Enums;
using ConsoleCS_ProjectManagementSystem.Model.DataType.Base;

namespace ConsoleCS_ProjectManagementSystem.Model.DataType
{
    public class DefaultTask
    {
        public  int? Id { get; set; }
        public  string? Name { get; set; }
        public  string? Description { get; set; }
        public  StatusEnum? Status { get; set; }
        public  DefaultUser? User { get; set; }


        public DefaultTask() { }
        public DefaultTask(BaseTask baseTask) 
        {
            Id = baseTask.Id;
            Name = baseTask.Name;
            Description = baseTask.Description;
            Status = baseTask.Status;
        }
    }
}
