namespace ConsoleCS_ProjectManagementSystem.Pages.Base
{
    public abstract class BasePage
    {
        private string _userTitle = string.Empty;

        public const int EXCEPTION_DELAY = 2500;
        public const ConsoleColor EXCEPTION_COLOR = ConsoleColor.Red;
        public const ConsoleColor DEFAULT_COLOR = ConsoleColor.White;
        public const string EXCEPTION_TEXT = "Ошибка";
        public const string INPUT_SPLITTER = ": ";
        public const string STANDART_TITLE = """
            Управление:
            стрелки вниз, вверх - выбор элемента меню
            стрелка в лево - вернутся на прошлую страницу
            enter - взаимодействие с элементом меню

            """;


        public virtual void ShowDisplayElements(List<string> elements, string title = STANDART_TITLE)
        {
            Console.Clear();

            _userTitle = title;

            Console.WriteLine(title);

            foreach (string element in elements)
            {
                Console.WriteLine($"{element}");
            }
        }

        public virtual void ShowElementsForInputs(Dictionary<string, string> elements, string title = STANDART_TITLE)
        {
            Console.Clear();

            _userTitle = title;

            Console.WriteLine(title);

            foreach (var element in elements)
            {
                Console.Write(element.Key + INPUT_SPLITTER);
                elements[element.Key] = Console.ReadLine() ?? string.Empty;
            }
        }

        public virtual void ShowException(string? text = EXCEPTION_TEXT)
        {
            Console.Clear();

            Console.ForegroundColor = EXCEPTION_COLOR;
            Console.WriteLine(text);
            Console.ForegroundColor = DEFAULT_COLOR;

            Thread.Sleep(EXCEPTION_DELAY);

            Console.Clear();
        }

        public int GetCountStrokeInTitle()
        {
            return _userTitle.Where(x => x == '\n').Count() + 1;
        }

        public abstract void Open();
        public abstract void FillDictionary();
    }
}
