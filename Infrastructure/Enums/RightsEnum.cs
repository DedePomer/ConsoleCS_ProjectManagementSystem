namespace ConsoleCS_ProjectManagementSystem.Infrastructure.Enums
{
    [Flags]
    public enum RightsEnum
    {
        None = 0,
        CreateUser = 1,
        CreateTask = 2,
        AssignTask = 4,
        ViewAllTask = 16,       

        ChangeStatus = 8
    }
}
