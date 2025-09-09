namespace ConsoleCS_ProjectManagementSystem.Infrastructure.Enums
{
    [Flags]
    public enum RightsEnum
    {
        None = 0,
        CreateUser = 1,
        CreateTask = 2,
        ViewDefaultUser = 4,
        ViewAllTask = 16,       
        ViewManager = 32,

        ChangeStatus = 8
    }
}
