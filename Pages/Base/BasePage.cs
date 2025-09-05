namespace ConsoleCS_ProjectManagementSystem.Pages.Base
{
    public abstract class BasePage
    {
        private const bool CURSOR_VISIBLE = false;
        private const string STANDART_TITLE = """
            Управление:
            стрелки вниз, вверх - выбор элемента меню
            стрелка в лево - вернутся на прошлую страницу
            enter - взаимодействие с элементом меню

            """;

        public int GetCountStrokeInTitle(string title = STANDART_TITLE)
        {
            return title.Where(x => x == '\n').Count() + 1;
        }

        public virtual void DisplayPage(List<string> elements, string title = STANDART_TITLE)
        {
            if (Console.CursorVisible == true)
            {
                Console.CursorVisible = CURSOR_VISIBLE;
            }

            Console.Clear();

            Console.WriteLine(title);

            foreach (string element in elements)
            {
                Console.WriteLine($"{element}");
            }
        }
        public abstract void Open();
    }
}
