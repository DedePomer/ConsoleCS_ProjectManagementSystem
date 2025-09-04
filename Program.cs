using System.Text.Json;
using ConsoleCS_ProjectManagementSystem.Model.DataType.AccessGroups;
using ConsoleCS_ProjectManagementSystem.Model.DataType.Rules;
using ConsoleCS_ProjectManagementSystem.Model.DataType.Rules.Default;
using ConsoleCS_ProjectManagementSystem.Model.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleCS_ProjectManagementSystem
{
    internal class Program
    {
        private static ServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            string file = @"AccessGroups.json";
            string relativePath = Path.Combine("Configs", file);
            string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string filePath = Path.Combine(projectDirectory, relativePath);
            DefaultAccessGroup manager = new DefaultAccessGroup()
            {
                  Name = "Manager",
                  Description = "Менеджер",
                  Rules = new List<DefaultRule>()
                  { 
                    new ExitRuleRead(),
                    new ViewTaskRuleRead(),
                    new AddUserRuleRead()
                  }                 
            };
            DefaultAccessGroup user = new DefaultAccessGroup()
            {
                Name = "DefaultUser",
                Description = "Обычный пользователь",
                Rules = new List<DefaultRule>()
                {
                  new ExitRuleRead(),
                  new ViewTaskRuleRead()
                }
            };
            List<DefaultAccessGroup> group = new List<DefaultAccessGroup>();
            group.Add(manager);
            group.Add(user);
            string json = JsonSerializer.Serialize(group, new JsonSerializerOptions { WriteIndented = true });
            string baza;
            using (StreamReader stream = new StreamReader(filePath))
            {
                baza = stream.ReadToEnd();
            }
            group = JsonSerializer.Deserialize<List<DefaultAccessGroup>>(baza);

            //IServiceCollection services = new ServiceCollection();
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
