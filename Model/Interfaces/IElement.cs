namespace ConsoleCS_ProjectManagementSystem.Model.Interfaces
{
    public interface IElement
    {
        public int Id { get; set; }
        public IRule Rule { get; set; }
    }
}
