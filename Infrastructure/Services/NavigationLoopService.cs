using ConsoleCS_ProjectManagementSystem.Model.Interfaces;
using System.Collections.Immutable;

namespace ConsoleCS_ProjectManagementSystem.Infrastructure.Services
{
    public class NavigationLoopService
    {
        private readonly ImmutableList<IElement> _elements;
        private readonly int _cursorPosition;


        private ConsoleColor _defaultColor = Console.ForegroundColor;
        private ConsoleColor _highlightColor = ConsoleColor.Green;

        public ConsoleKey PressedKey { get; private set; }

        public NavigationLoopService(IEnumerable<IElement> elements, int cursorPosition)
        {
            _elements = elements.ToImmutableList();
            _cursorPosition = cursorPosition;
        }

        public int GetNumberSelectedElement(bool ReadKey)
        {
            int topCursorPosition = _cursorPosition;
            int downCursorPosition = _elements.Count() + _cursorPosition;

            int _windowHeight = Console.WindowHeight;
            int _bufferHeight = Console.BufferHeight;

            if (topCursorPosition != downCursorPosition)
            {
                Console.SetCursorPosition(0, _cursorPosition);

                HighlightElement(topCursorPosition, topCursorPosition);

                PressedKey = GetPressedKey(ref topCursorPosition, downCursorPosition, ReadKey);
            }
            return topCursorPosition - _cursorPosition;
        }



        private void HighlightElement(int correntCursorPosition, int pastCursorPosition)
        {
            Console.SetCursorPosition(0, pastCursorPosition);
            Console.WriteLine(_elements[pastCursorPosition - _cursorPosition].Name);
            Console.SetCursorPosition(0, correntCursorPosition);
            Console.ForegroundColor = _highlightColor;
            Console.WriteLine(_elements[correntCursorPosition - _cursorPosition].Name);
            Console.ForegroundColor = _defaultColor;
            Console.CursorTop = correntCursorPosition;
        }


        private ConsoleKey GetPressedKey(ref int topCursorPosition, int downCursorPosition, bool ReadLeftArrow)
        {
            ConsoleKey key;

            do
            {
                key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.UpArrow)
                {
                    if (topCursorPosition > _cursorPosition)
                    {
                        HighlightElement(topCursorPosition - 1, topCursorPosition);
                        topCursorPosition--;
                    }
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    if (topCursorPosition < downCursorPosition - 1)
                    {
                        HighlightElement(topCursorPosition + 1, topCursorPosition);
                        topCursorPosition++;
                    }
                }
                else if (key == ConsoleKey.LeftArrow && ReadLeftArrow == true)
                {
                    return key;
                }
            }
            while (key != ConsoleKey.Enter);

            return key;
        }

    }
}



