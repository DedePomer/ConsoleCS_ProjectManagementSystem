using ConsoleCS_ProjectManagementSystem.Model.Interfaces;

namespace ConsoleCS_ProjectManagementSystem.Model.DataType
{
    public class RoleElement : IElement
    {
        public int Id { get ; set ; }
        public string Name { get ; set ; }
        public Action<object?> Execute { get; set; }
        public DefaultRole Role { get; set; }
    }
}
