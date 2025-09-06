using ConsoleCS_ProjectManagementSystem.Pages.Base;

namespace ConsoleCS_ProjectManagementSystem.Infrastructure.Interfaces
{
    public interface IPageNavigation
    {
        public void Back();
        public void Open(BasePage page);
    }
}
