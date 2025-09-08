using System.ComponentModel;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Attributes;

namespace ConsoleCS_ProjectManagementSystem.Infrastructure.Enums
{
    public enum StatusEnum
    {
        [StatusNameAtribute("None")]
        None = 0,
        [StatusNameAtribute("Done")]
        Done = 1,
        [StatusNameAtribute("To do")]
        ToDo = 2,
        [StatusNameAtribute("In Progress")]
        InProgress = 3
    }
}
