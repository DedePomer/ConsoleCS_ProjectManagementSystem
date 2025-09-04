using Microsoft.Extensions.DependencyInjection;

namespace ConsoleCS_ProjectManagementSystem
{
    internal class Program
    {
        private static ServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            //AddServices(services);
            //_serviceProvider = services.BuildServiceProvider();
            //ProgramStartup();
        }


        //private static void ProgramStartup()
        //{
        //    _serviceProvider.GetService<MainPage>();
        //}

        //private static void AddServices(IServiceCollection services)
        //{
        //    services.AddTransient<MainPage>();
        //    services.AddSingleton<INavigationBetweenPages, NavigationBetweenPagesService>();
        //}
    }
}
