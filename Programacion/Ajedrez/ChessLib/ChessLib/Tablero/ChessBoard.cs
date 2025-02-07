using ChessLib.Figuras;

namespace ChessLib.Tablero
{
    public class ChessBoard : IChessBoard
    {
        private readonly Casilla[,] _casillas;
        private readonly int _width;
        private readonly int _height;
        private readonly Figure[] _figures;

        public int Width => _width;
        public int Height => _height;

        public ChessBoard(int width, int height)
        {
            _width = width;
            _height = height;
            _casillas = new Casilla[width, height];
            _figures = new Figure[32];
            CrearCasillas();
            //InitBoard();
            //metodo para iniciar fichas
        }


        public void Clear()
        {
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    _casillas[x, y].Figure = null;
                }
            }
        }

        public IFigure? GetFigureAt(int x, int y)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height)
                return null; // Fuera del tablero.
            return _casillas[x, y].Figure;
        }

        public IFigure? GetFigureAt(int index)
        {
            if (index < 0 || index >= _figures.Length)
                return null;
            return _figures[index];
        }

        public int GetFigureCount()
        {
            return _figures.Length - 1;
        }

        public int GetHeight()
        {
            return _height;
        }

        public int GetWidth()
        {
            return _width;
        }

        //Metodo para inicializar las casillas
        public void InitBoard()
        {
            // Piezas blancas
            _casillas[0, 0].Figure = new Tower(FigureColor.WHITE, FigureType.TOWER, new Coord(0, 0));
            _casillas[7, 0].Figure = new Tower(FigureColor.WHITE, FigureType.TOWER, new Coord(7, 0));
            _casillas[1, 0].Figure = new Knight(FigureColor.WHITE, FigureType.KNIGHT, new Coord(1, 0));
            _casillas[6, 0].Figure = new Knight(FigureColor.WHITE, FigureType.KNIGHT, new Coord(6, 0));
            _casillas[2, 0].Figure = new Bishop(FigureColor.WHITE, FigureType.BISHOP, new Coord(2, 0));
            _casillas[5, 0].Figure = new Bishop(FigureColor.WHITE, FigureType.BISHOP, new Coord(5, 0));
            _casillas[3, 0].Figure = new Queen(FigureColor.WHITE, FigureType.QUEEN, new Coord(3, 0));
            _casillas[4, 0].Figure = new King(FigureColor.WHITE, FigureType.KING, new Coord(4, 0));

            for (int i = 0; i < _width; i++)
            {
                _casillas[i, 1].Figure = new Pawn(FigureColor.WHITE, FigureType.PAWN, new Coord(i, 1));
            }

            // Piezas negras
            _casillas[0, 7].Figure = new Tower(FigureColor.BLACK, FigureType.TOWER, new Coord(0, 7));
            _casillas[7, 7].Figure = new Tower(FigureColor.BLACK, FigureType.TOWER, new Coord(7, 7));
            _casillas[1, 7].Figure = new Knight(FigureColor.BLACK, FigureType.KNIGHT, new Coord(1, 7));
            _casillas[6, 7].Figure = new Knight(FigureColor.BLACK, FigureType.KNIGHT, new Coord(6, 7));
            _casillas[2, 7].Figure = new Bishop(FigureColor.BLACK, FigureType.BISHOP, new Coord(2, 7));
            _casillas[5, 7].Figure = new Bishop(FigureColor.BLACK, FigureType.BISHOP, new Coord(5, 7));
            _casillas[3, 7].Figure = new Queen(FigureColor.BLACK, FigureType.QUEEN, new Coord(3, 7));
            _casillas[4, 7].Figure = new King(FigureColor.BLACK, FigureType.KING, new Coord(4, 7));

            for (int i = 0; i < _width; i++)
            {
                _casillas[i, 6].Figure = new Pawn(FigureColor.BLACK, FigureType.PAWN, new Coord(i, 6));
            }
        }
        //hara falta metodo para inicializar figuras

        public bool MoveFigure(int fromX, int fromY, int toX, int toY)
        {
            var figure = GetFigureAt(fromX, fromY);
            if (figure == null)
                return false; // No hay figura en la casilla de origen

            var targetCoord = new Coord(toX, toY);
            if (!figure.GetAllAvailablePosition(this).Contains(targetCoord))
                return false; // Movimiento no válido

            // Realizar el movimiento
            _casillas[toX, toY].Figure = figure;
            _casillas[fromX, fromY].Figure = null;
            figure.MoveFigure(targetCoord);

            return true;
        }


        public void RemoveFigureAt(int x, int y)
        {
            if (x >= 0 && x < _width && y >= 0 && y < _height)
                _casillas[x, y].Figure = null;
        }

        public void CrearCasillas()
        {
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    var color = (x + y) % 2 == 0 ? CasillaColor.WHITE : CasillaColor.BLACK;

                    _casillas[x, y] = new Casilla(new Coord(x, y));
                }
            }
        }

        public bool MoveFigure(int x, int y)
        {
            return true;
        }


        public void PrintBoard()
        {
            for (int y = Height - 1; y >= 0; y--)
            {
                Console.Write(y + 1 + " "); // Números de filas
                for (int x = 0; x < Width; x++)
                {
                    var figure = GetFigureAt(x, y);
                    char symbol = figure switch
                    {
                        Pawn => 'P',
                        Tower => 'T',
                        Knight => 'N',
                        Bishop => 'B',
                        Queen => 'Q',
                        King => 'K',
                        _ => ' ' // Casilla vacía
                    };

                    // Determinar el color de la casilla
                    Console.BackgroundColor = (x + y) % 2 == 0 ? ConsoleColor.DarkGray : ConsoleColor.White;
                    Console.ForegroundColor = figure != null && figure.GetColor() == FigureColor.BLACK ? ConsoleColor.Black : ConsoleColor.DarkRed;

                    Console.Write($" {symbol} ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }

            Console.Write("  ");
            for (char c = 'A'; c < 'A' + Width; c++)
            {
                Console.Write(" " + c + " "); // Letras de columnas
            }
            Console.WriteLine();
        }

    }
}

//class ChessBoard : IChessBoard
//         *
//{
//         *      IChessBoard b = new ChessBoard();
//         * }