using System.ComponentModel;
using System.Reflection;

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

    public static class EnumExtension
    {
        public static string GetDescription(this StatusEnum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

    }
}
