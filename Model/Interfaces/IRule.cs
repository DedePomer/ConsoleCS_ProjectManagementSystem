namespace ConsoleCS_ProjectManagementSystem.Model.Interfaces
{
    public interface IRule
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsChange{ get; set; }
        public bool IsRead{ get; set; }
    }
}
