using ConsoleCS_ProjectManagementSystem.Pages.Base;

namespace ConsoleCS_ProjectManagementSystem.Infrastructure.Interfaces
{
    public interface IPageNavigation
    {
        /// <summary>
        /// Добавляет page в список открытых пользователем окон
        /// </summary>
        /// <param name="page"></param>
        public void Add(BasePage page);

        /// <summary>
        /// Открывает предыдущий класс (Page).
        /// </summary>
        public void Back();

        /// <summary>
        /// Метод открывает класс реализующий BasePage
        /// </summary>
        /// <param name="nextPage"></param>
        public void Open(BasePage nextPage);

        /// <summary>
        /// Метод открывает класс реализующий BasePage. Нельзя использовать в первом окне программы.
        /// </summary>
        /// <param name="nextPage"></param>
        /// <param name="deleteLast"></param>
        public void Open(BasePage nextPage, bool deleteLast);
    }
}
