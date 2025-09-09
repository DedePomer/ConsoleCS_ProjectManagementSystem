using ConsoleCS_ProjectManagementSystem.Model.Interfaces;

namespace ConsoleCS_ProjectManagementSystem.Model.DataType
{
    public class UserElement : IElement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Action<object?> Execute { get; set; }
        public DefaultUser User { get; set; }
    }
}
