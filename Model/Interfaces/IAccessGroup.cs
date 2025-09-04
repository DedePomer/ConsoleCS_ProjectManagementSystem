using ConsoleCS_ProjectManagementSystem.Model.DataType.Rules.Default;

namespace ConsoleCS_ProjectManagementSystem.Model.Interfaces
{
    public interface IAccessGroup
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<DefaultRule> Rules { get; set; }
    }
}
