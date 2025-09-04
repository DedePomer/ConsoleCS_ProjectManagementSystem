using System.Data;

namespace ConsoleCS_ProjectManagementSystem.Infrastructure.DataBase
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
