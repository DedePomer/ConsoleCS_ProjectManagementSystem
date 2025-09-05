using ConsoleCS_ProjectManagementSystem.Model.Interfaces;

namespace ConsoleCS_ProjectManagementSystem.Model.DataType
{
    public class MenuElement : IElement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public delegate void Execute(object? obj = default);
    }
}
