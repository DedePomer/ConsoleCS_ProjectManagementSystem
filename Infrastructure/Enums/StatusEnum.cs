using System.ComponentModel;

namespace ConsoleCS_ProjectManagementSystem.Infrastructure.Enums
{
    public enum StatusEnum
    {
        [Description("None")]
        None = 0,
        [Description("Done")]
        Done = 1,
        [Description("To do")]
        ToDo = 2,
        [Description("In Progress")]
        InProgress = 3
    }
}
