
namespace TestPantalla
{
    public struct Cell
    {
        public char Character;
        public ConsoleColor BackgroundColor;
        public ConsoleColor ForegroundColor;

        public Cell(char character, ConsoleColor backgroundColor, ConsoleColor foregroundColor = ConsoleColor.White)
        {
            Character = character;
            BackgroundColor = backgroundColor;
            ForegroundColor = foregroundColor;
        }
    }

    public class UI
    {
        private readonly int _width;
        private readonly int _height;
        private readonly Cell[,] _buffer;
        
        public int Width => _width;
        public int Height => _height;
        public Cell this[int x, int y]
        {
            get => GetCellAt(x, y);
            set => SetCellAt(x, y, value);
        }

        public UI(int width, int height)
        {
            if (width <= 0)
                throw new ArgumentOutOfRangeException("width");
            if (height <= 0)
                throw new ArgumentOutOfRangeException("height");

            _width = width;
            _height = height;
            _buffer = new Cell[height, width];
        }

        public void Clear()
        {
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    _buffer[y, x].Character = ' ';
                    _buffer[y, x].BackgroundColor = ConsoleColor.Black;
                    _buffer[y, x].ForegroundColor = ConsoleColor.Black;
                }
            }
        }

        public void Show()
        {
            var oldBackgroundColor = Console.BackgroundColor;
            var oldForegroundColor = Console.ForegroundColor;

            for (int y = 0; y < _height; y++)
            {
                Console.SetCursorPosition(0, y);
                for (int x = 0; x < _width; x++)
                {
                    Console.ForegroundColor = _buffer[y, x].ForegroundColor;
                    Console.BackgroundColor = _buffer[y, x].BackgroundColor;
                    Console.Write(_buffer[y, x].Character);
                }
            }
            Console.BackgroundColor = oldBackgroundColor;
            Console.ForegroundColor = oldForegroundColor;
            Console.SetCursorPosition(0, _height);
        }

        private Cell GetCellAt(int x, int y)
        {
            if (x < 0 || x >= _width)
                throw new ArgumentOutOfRangeException("x");
            if (y < 0 || y >= _height)
                throw new ArgumentOutOfRangeException("y");

            return _buffer[y, x];
        }

        private void SetCellAt(int x, int y, Cell value)
        {
            if (x < 0 || x >= _width)
                throw new ArgumentOutOfRangeException("x");
            if (y < 0 || y >= _height)
                throw new ArgumentOutOfRangeException("y");

            _buffer[y, x] = value;
        }

        public void PrintString(int x, int y, string text, ConsoleColor backgroundColor, ConsoleColor foregroundColor)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));
            if (y < 0 || y >= _height)
                throw new ArgumentOutOfRangeException(nameof(y));
            if (x < 0 || x >= _width)
                throw new ArgumentOutOfRangeException(nameof(x));

            for (int i = 0; i < text.Length && (x + i) < _width; i++)
            {
                Cell c = new Cell()
                {
                    Character = text[i],
                    ForegroundColor = foregroundColor,
                    BackgroundColor = backgroundColor
                };

                this[x + i, y] = c;
            }
        }
    }

}
