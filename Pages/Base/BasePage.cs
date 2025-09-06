namespace ConsoleCS_ProjectManagementSystem.Pages.Base
{
    public abstract class BasePage
    {
        public const ConsoleColor EXCEPTION_COLOR = ConsoleColor.Red;
        public const ConsoleColor DEFAULT_COLOR = ConsoleColor.White;
        public const string EXCEPTION_TEXT = "Ошибка";
        public const bool CURSOR_VISIBLE = false;
        public const string INPUT_SPLITTER = ": ";
        public const string STANDART_TITLE = """
            Управление:
            стрелки вниз, вверх - выбор элемента меню
            стрелка в лево - вернутся на прошлую страницу
            enter - взаимодействие с элементом меню

            """;

        public void UpdateConsole()
        {
            if (Console.CursorVisible == true)
            {
                Console.CursorVisible = CURSOR_VISIBLE;
            }

            Console.Clear();
        }

        public virtual void ShowDisplayElements(List<string> elements, string title = STANDART_TITLE)
        {
            UpdateConsole();

            Console.WriteLine(title);

            foreach (string element in elements)
            {
                Console.WriteLine($"{element}");
            }
        }

        public virtual void ShowElementsForInputs(Dictionary<string, string> elements, string title = STANDART_TITLE)
        {
            UpdateConsole();

            Console.WriteLine(title);

            foreach (var element in elements)
            {
                Console.Write(element.Key + INPUT_SPLITTER);
                elements[element.Key] = Console.ReadLine() ?? string.Empty;
            }
        }

        public virtual void ShowException(string? text = EXCEPTION_TEXT)
        {
            UpdateConsole();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;

            Task.Delay(5000);
        }

        public int GetCountStrokeInTitle(string title = STANDART_TITLE)
        {
            return title.Where(x => x == '\n').Count() + 1;
        }

        public abstract void Open();
    }
}
