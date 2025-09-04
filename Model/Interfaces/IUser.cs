namespace ConsoleCS_ProjectManagementSystem.Model.Interfaces
{
    public interface IUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public IAccessGroup Group { get; set; }
    }
}
