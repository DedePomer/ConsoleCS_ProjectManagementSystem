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
            string valueText = value.ToString();
            FieldInfo? fieldInfo = value
                .GetType()
                .GetField(valueText);

            if (fieldInfo == null)           
                return value.ToString();
            
            DescriptionAttribute[]? attributes = fieldInfo
                .GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

    }
}
