using ConsoleCS_ProjectManagementSystem.Infrastructure.Enums;
using ConsoleCS_ProjectManagementSystem.Model.Interfaces;

namespace ConsoleCS_ProjectManagementSystem.Model.DataType
{
    public class TaskElement : IElement
    {
        private string _name;


        public int Id { get; set; }
        public string Name 
        {
            get
            {
                string splitter = "|"; 
                if (_name == default)
                {
                    return Task.Name + splitter + Task.Description + splitter + Task.Status;
                }
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public Action<object?> Execute { get; set; }
        public DefaultTask Task { get; set; }
    }
}
