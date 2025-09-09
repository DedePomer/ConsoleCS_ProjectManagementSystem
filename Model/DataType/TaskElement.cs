using ConsoleCS_ProjectManagementSystem.Infrastructure.Enums;
using ConsoleCS_ProjectManagementSystem.Model.Interfaces;

namespace ConsoleCS_ProjectManagementSystem.Model.DataType
{
    public class TaskElement : IElement
    {
        private const string NAME_SPLITTER = " | ";


        public int Id { get; set; }
        public string Name { get; set; }
        public Action<object?> Execute { get; set; }
        public DefaultTask Task { get; set; }



        public string SetTaskName(DefaultTask task)
        {
            return Name = task.Name + NAME_SPLITTER + task.Description + NAME_SPLITTER + task.Status.GetDescription();
        }

    }
}
