using ConsoleCS_ProjectManagementSystem.Model.Interfaces;

namespace ConsoleCS_ProjectManagementSystem.Pages.Base
{
    public abstract class BasePage
    {
        private const string STANDART_TITLE = """
            Управление:\n
            стрелки вниз, вверх - выбор элемента меню\n
            стрелка в лево - вернутся на прошлую страницу\n
            enter - взаимодействие с элементом меню\n
            """;

        private int StrokeCount(string text)
        {
            return text.Where(x => x == '\n').Count();
        }

        public virtual int DisplayPage(List<IElement> elements, string title = STANDART_TITLE)
        {

            return StrokeCount(title);
        }
        public abstract void Open();
    }
}
