namespace ConsoleCS_ProjectManagementSystem.Infrastructure.Attributes
{
    public class StatusNameAtribute : Attribute
    {
        public string Name { get; }
        public StatusNameAtribute() { }
        public StatusNameAtribute(string name) => Name = name;
    }
}
