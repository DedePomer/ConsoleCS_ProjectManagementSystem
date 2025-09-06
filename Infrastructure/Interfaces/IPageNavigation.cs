using ConsoleCS_ProjectManagementSystem.Pages.Base;

namespace ConsoleCS_ProjectManagementSystem.Infrastructure.Interfaces
{
    public interface IPageNavigation
    {
        public void Add(BasePage page);
        public void Back();
        public void Open(BasePage nextPage);
    }
}
