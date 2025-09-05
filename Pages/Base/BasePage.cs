using System.Collections.Generic;
using System.ComponentModel;
using ConsoleCS_ProjectManagementSystem.Model.DataType;

namespace ConsoleCS_ProjectManagementSystem.Pages.Base
{
    public abstract class BasePage
    {
        public const bool CURSOR_VISIBLE = false;
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

        public virtual void ShowElementsForInputs(Dictionary<string,string> elements, string title = STANDART_TITLE)
        {
            UpdateConsole();

            Console.WriteLine(title);

            foreach (var element in elements)
            {
                Console.Write(element.Key+ ": ");
                elements[element.Key] = Console.ReadLine() ?? "";
            }
        }

        public int GetCountStrokeInTitle(string title = STANDART_TITLE)
        {
            return title.Where(x => x == '\n').Count() + 1;
        }
        public abstract void Open(DefaultUser user);
    }
}
