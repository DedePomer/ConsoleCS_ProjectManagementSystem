using ConsoleCS_ProjectManagementSystem.Infrastructure.Interfaces;
using ConsoleCS_ProjectManagementSystem.Pages.Base;

namespace ConsoleCS_ProjectManagementSystem.Infrastructure.Services
{
    public class PageNavigationService : IPageNavigation
    {
        private LinkedList<BasePage> _pageList = new LinkedList<BasePage>();

        public void Add(BasePage page)
        {
            _pageList.AddLast(page);
        }

        public void Back()
        {
            _pageList.RemoveLast();
            _pageList.Last().Open();                  
        }

        public void Open(BasePage nextPage)
        {           
            nextPage.Open();
        }
    }
}
