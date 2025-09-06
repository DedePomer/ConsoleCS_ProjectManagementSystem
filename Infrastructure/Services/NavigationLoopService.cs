namespace ConsoleCS_ProjectManagementSystem.Infrastructure.Services
{
    public class NavigationLoopService
    {
        private ConsoleColor _defaultColor = Console.ForegroundColor;
        private ConsoleColor _highlightColor = ConsoleColor.Green;

        private readonly List<string> _elemments;
        private readonly int _cursorPosition;

        public ConsoleKey PressedKey { get; private set; }

        public NavigationLoopService(List<string> elemments, int cursorPosition)
        {
            _elemments = elemments;
            _cursorPosition = cursorPosition;
        }

        private void HighlightElement(int correntCursorPosition, int pastCursorPosition)
        {
            Console.SetCursorPosition(0, pastCursorPosition);
            Console.WriteLine(_elemments[pastCursorPosition - _cursorPosition]);
            Console.SetCursorPosition(0, correntCursorPosition);
            Console.ForegroundColor = _highlightColor;
            Console.WriteLine(_elemments[correntCursorPosition - _cursorPosition]);
            Console.ForegroundColor = _defaultColor;
            Console.CursorTop = correntCursorPosition;
        }


        private ConsoleKey GetPressedKey(int topCursorPosition, int downCursorPosition)
        {
            ConsoleKey key;

            while ((key = Console.ReadKey(true).Key) != ConsoleKey.Enter)
            {
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
                else if (key == ConsoleKey.LeftArrow)
                {
                    return key;
                }
            }

            return key;
        }

        public int GetNumberSelectedElement()
        {
            int topCursorPosition = _cursorPosition;
            int downCursorPosition = _elemments.Count() + _cursorPosition;

            Console.CursorTop = _cursorPosition;

            HighlightElement(topCursorPosition, topCursorPosition);

            PressedKey = GetPressedKey(topCursorPosition, downCursorPosition);

            return topCursorPosition - _cursorPosition;
        }

    }
}
