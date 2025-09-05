namespace ConsoleCS_ProjectManagementSystem.Model.Interfaces
{
    public interface IUser
    {
        string Name { get; set; }
        string Password { get; set; }
        IRole role { get; set; }
    }
}
