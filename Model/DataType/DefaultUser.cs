using ConsoleCS_ProjectManagementSystem.Infrastructure.Enums;
using ConsoleCS_ProjectManagementSystem.Model.DataType.Base;

namespace ConsoleCS_ProjectManagementSystem.Model.DataType
{
    public class DefaultUser
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public DefaultRole? Role { get; set; }


        public DefaultUser() { }
        public DefaultUser(BaseUser baseUser) 
        {
            Id = baseUser.Id;
            Name = baseUser.Name;
        }
        public bool HasRight(RightsEnum right)
        {
            return (Role?.Rights & right) == right;
        }
    }
}

