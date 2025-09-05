namespace ConsoleCS_ProjectManagementSystem.Model.DataType
{
    public class DefaultUser
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public DefaultRole role { get; set; }
    }
}

