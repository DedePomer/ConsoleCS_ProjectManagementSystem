namespace ConsoleCS_ProjectManagementSystem.Model.Interfaces
{
    interface IAccessGroup
    {
        public string Name { get; set; }
        public List<IRule> Rules { get; set; }
    }
}
