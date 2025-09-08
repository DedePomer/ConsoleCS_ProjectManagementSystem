namespace ConsoleCS_ProjectManagementSystem.Model.Interfaces
{
    public interface IElement
    {
        int Id { get; set; }
        string Name { get; set; }
        Action<object?> Execute { get; set; }
    }
}
