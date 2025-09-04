using ConsoleCS_ProjectManagementSystem.Model.DataType.Rules.Default;
using ConsoleCS_ProjectManagementSystem.Model.Interfaces;

namespace ConsoleCS_ProjectManagementSystem.Model.DataType.AccessGroups
{
    public class DefaultAccessGroup : IAccessGroup
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<DefaultRule> Rules { get; set; }
    }
}
