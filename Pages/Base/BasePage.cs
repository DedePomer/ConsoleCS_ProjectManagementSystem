namespace ConsoleCS_ProjectManagementSystem.Pages.Base
{
    public abstract class BasePage
    {
        private const string STANDART_TITLE = """
            Управление:
            стрелки вниз, вверх - выбор элемента меню
            стрелка в лево - вернутся на прошлую страницу
            enter - взаимодействие с элементом меню

            """;

        private int CountStrokeInTitle(string text)
        {
            return text.Where(x => x == '\n').Count() + 1;
        }

        public virtual int DisplayPage(List<string> elements, string title = STANDART_TITLE)
        {
            Console.WriteLine(title);

            foreach (string element in elements)
            {
                Console.WriteLine($"{element}");
            }

            return CountStrokeInTitle(title);
        }
        public abstract void Open();
    }
}
