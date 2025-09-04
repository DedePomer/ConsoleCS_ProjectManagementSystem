using ConsoleCS_ProjectManagementSystem.Model.Interfaces;

namespace ConsoleCS_ProjectManagementSystem.Model.DataType.AccessGroups
{
    public class DefaultAccessGroup : IAccessGroup
    {
        public string Name { get; set; } = "DefaultUser";
        public string Description { get; set; } = "Обычный пользователь";
        public List<IRule> Rules { get; set; }      
    }
}
