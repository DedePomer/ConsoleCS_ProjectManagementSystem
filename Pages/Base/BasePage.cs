using System.Xml.Linq;
using ConsoleCS_ProjectManagementSystem.Infrastructure.Enums;
using ConsoleCS_ProjectManagementSystem.Model.DataType;
using ConsoleCS_ProjectManagementSystem.Model.Interfaces;

namespace ConsoleCS_ProjectManagementSystem.Pages.Base
{
    public abstract class BasePage
    {
        private string _userTitle = string.Empty;

        protected const int EXCEPTION_DELAY = 2500;
        protected const ConsoleColor EXCEPTION_COLOR = ConsoleColor.Red;
        protected const ConsoleColor DEFAULT_COLOR = ConsoleColor.White;
        protected const string EXCEPTION_TEXT = "Ошибка";
        protected const string INPUT_SPLITTER = ": ";
        protected const string STANDART_TITLE = """
            Управление:
            стрелки вниз, вверх - выбор элемента меню
            стрелка в лево - вернутся на прошлую страницу
            enter - взаимодействие с элементом меню

            """;


        protected virtual void ShowDisplayElements(IEnumerable<IElement> elements, string title = STANDART_TITLE)
        {
            ShowTitle(title);

            foreach (var element in elements)
            {
                Console.WriteLine($"{element.Name}");
            }
        }

        protected virtual void ShowElementsForInputs(Dictionary<string, string> elements, string title = STANDART_TITLE)
        {
            Console.CursorVisible = true;

            ShowTitle(title);

            foreach (var element in elements)
            {
                Console.Write(element.Key + INPUT_SPLITTER);
                elements[element.Key] = Console.ReadLine() ?? string.Empty;
            }

            Console.CursorVisible = false;
        }

        protected virtual void ShowException(string? text = EXCEPTION_TEXT)
        {
            Console.Clear();

            Console.ForegroundColor = EXCEPTION_COLOR;
            Console.WriteLine(text);
            Console.ForegroundColor = DEFAULT_COLOR;

            ConsoleKey key;
            while ((key = Console.ReadKey(true).Key) != ConsoleKey.Enter) { }
            Console.Clear();
        }

        protected int GetCountStrokeInTitle()
        {
            return _userTitle.Where(x => x == '\n').Count() + 1;
        }

        protected void ShowTitle(string title = STANDART_TITLE)
        {
            Console.Clear();

            _userTitle = title;

            Console.WriteLine(title);
        }




        protected List<IElement> CreateShowList(Dictionary<IElement, RightsEnum> elements, DefaultUser user)
        {
            return elements
                .Where(x => user.HasRight(x.Value))
                .Select(x => x.Key)
                .ToList();
        }
        public abstract void Open();
        public abstract void FillDictionary();
    }
}
