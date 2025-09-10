using ConsoleCS_ProjectManagementSystem.Infrastructure.DataBase;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Interfaces;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Repositories;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Services;
using ConsoleCS_ProjectManagementSystem.Model.DataType;
using ConsoleCS_ProjectManagementSystem.Pages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace ConsoleCS_ProjectManagementSystem
{
    public class Program
    {

        public static void Main(string[] args)
        {
            Console.CursorVisible = false;


            var builder = Host.CreateApplicationBuilder(args);

            var logPath = builder.Configuration["LogPath"];
            ArgumentNullException.ThrowIfNullOrEmpty(logPath, nameof(logPath));
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(logPath)
                .CreateLogger();

            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog();
            builder.Configuration.AddJsonFile("appsettings.json");

            AddServices(builder.Services);
            AddDatabase(builder.Services, builder.Configuration);

            var app = builder.Build();

            var dbInitializer = app.Services.GetRequiredService<DbInitializer>();
            dbInitializer.Initialize();
            var loginPage = app.Services.GetRequiredService<LoginPage>();
            loginPage.Open();

            app.Run();
        }


        private static void AddServices(IServiceCollection services)
        {
            services.AddSingleton<LoginPage>();
            services.AddTransient<DbInitializer>();
            services.AddSingleton<DefaultUser>();
            services.AddSingleton<IPageNavigation, PageNavigationService>();
            services.AddSingleton<RoleService>(); /*надобы использовать интерфейсы для сервисов и репозиториев*/
            services.AddSingleton<TaskService>();
            services.AddSingleton<UserService>();
            services.AddSingleton<RoleRepository>();
            services.AddSingleton<TaskRepository>();
            services.AddSingleton<UserRepository>();
        }

        private static void AddDatabase(IServiceCollection services, IConfiguration configuration)
        {
            var databasePath = configuration["DatabasePath"];
            ArgumentNullException.ThrowIfNullOrEmpty(databasePath, nameof(databasePath));
            services.AddSingleton<IDbConnectionFactory>(new SqliteConnectionFactory(databasePath));
        }
    }
}
