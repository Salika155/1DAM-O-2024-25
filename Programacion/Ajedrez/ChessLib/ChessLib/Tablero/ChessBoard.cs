using ChessLib.Figuras;

namespace ChessLib.Tablero
{
    public class ChessBoard : IChessBoard
    {
        private readonly Casilla[,] _casillas;
        private readonly int _width;
        private readonly int _height;
        private readonly Figure[] _figures;
        private IFigure? _selectedFigure = null;
        private Coord? _selectedCoord = null;
        private FigureColor _currentTurn = FigureColor.RED;

        public int Width => _width;
        public int Height => _height;

        public ChessBoard(int width, int height)
        {
            _width = width;
            _height = height;
            _casillas = new Casilla[width, height];
            _figures = new Figure[32];
            CrearCasillas();
            InitBoard();
            //InitBoard();
            //metodo para iniciar fichas
        }

        #region crearfiguras
        private void CrearFiguras()
        {
            CrearPeones();
            CrearTorres();
            CrearAlfiles();
            CrearCaballos();
            CrearReyes();
        }

        private void CrearReyes()
        {
            //reyes blancos
            _casillas[3, 0].Figure = new Queen(FigureColor.RED, new Coord(3, 0));
            _casillas[4, 0].Figure = new King(FigureColor.RED, new Coord(4, 0));
            //reyes negros
            _casillas[3, 7].Figure = new Queen(FigureColor.BLACK, new Coord(3, 7));
            _casillas[4, 7].Figure = new King(FigureColor.BLACK, new Coord(4, 7));
        }

        private void CrearCaballos()
        {
            //caballos blancos
            _casillas[1, 0].Figure = new Knight(FigureColor.RED, new Coord(1, 0));
            _casillas[6, 0].Figure = new Knight(FigureColor.RED, new Coord(6, 0));
            //caballos negros
            _casillas[1, 7].Figure = new Knight(FigureColor.BLACK, new Coord(1, 7));
            _casillas[6, 7].Figure = new Knight(FigureColor.BLACK, new Coord(6, 7));
        }

        private void CrearAlfiles()
        {
            //alfiles blancos
            _casillas[2, 0].Figure = new Bishop(FigureColor.RED, new Coord(2, 0));
            _casillas[5, 0].Figure = new Bishop(FigureColor.RED, new Coord(5, 0));
            //alfiles negros
            _casillas[2, 7].Figure = new Bishop(FigureColor.BLACK, new Coord(2, 7));
            _casillas[5, 7].Figure = new Bishop(FigureColor.BLACK, new Coord(5, 7));
        }

        private void CrearTorres()
        {
            //torres blancas
            _casillas[0, 0].Figure = new Tower(FigureColor.RED, new Coord(0, 0));
            _casillas[7, 0].Figure = new Tower(FigureColor.RED, new Coord(7, 0));
            //torres negras
            _casillas[0, 7].Figure = new Tower(FigureColor.BLACK, new Coord(0, 7));
            _casillas[7, 7].Figure = new Tower(FigureColor.BLACK, new Coord(7, 7));
        }

        private void CrearPeones()
        {
            // Piezas blancas
            for (int i = 0; i < _width; i++)
            {
                _casillas[i, 1].Figure = new Pawn(FigureColor.RED, new Coord(i, 1));
            }

            // Piezas negras
            for (int i = 0; i < _width; i++)
            {
                _casillas[i, 6].Figure = new Pawn(FigureColor.BLACK, new Coord(i, 6));
            }
        }
        #endregion

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

        public void InitBoard()
        {
            CrearFiguras();
        }

        public void InitGame()
        {
            while (true)
            {
                Console.Clear();
                PrintBoard();
                Console.WriteLine($"Turno de las piezas: {_currentTurn}");
                ExecuteTurn();
            }
        }

        public void ExecuteTurn()
        {
            while(true)
            {
                Console.WriteLine($"Turno de: {_currentTurn}");
                var origen = SeleccionarPieza();
                    if (origen == null)
                    continue;

                Console.WriteLine($"Has seleccionado una pieza en {ConvertirANotacionAjedrez(origen.Value)}");
                MostrarMovimientosDisponibles(this);
                Console.WriteLine("Introduce la casilla de destino (Ejemplo: E3):");
                var destino = LeerCordenadas();
                if (destino == null)
                    continue;


            }
        }

        //Metodo para inicializar las casillas
        public void CrearCasillas()
        {
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    var color = (x + y) % 2 == 0 ? CasillaColor.WHITE : CasillaColor.BLACK;
                    _casillas[x, y] = new Casilla(new Coord(x, y), color);
                }
            }
        }

        public bool MoveFigure(IChessBoard board, int fromX, int fromY, int toX, int toY)
        {
            //tiene que haber alguna manera de sacar todo esto sin necesidad de volver a 
            //crearlos pero ahora no lo se
           var figure = GetFigureAt(fromX, fromY);
            if (figure == null)
                return false;
            if (!CanFigureBeMoved(board, fromX, fromY, toX, toY))
                return false;
            
            // Realizar el movimiento
            _casillas[toX, toY].Figure = figure;
            _casillas[fromX, fromY].Figure = null;
            figure.MoveFigure(new Coord(toX, toY));
            return true;
        }

        public bool CanFigureBeMoved(IChessBoard board, int fromX, int fromY, int toX, int toY)
        {
            var figure = GetFigureAt(fromX, fromY);
            return FigureBeMoved(board, figure, toX, toY);
        }

        private bool FigureBeMoved(IChessBoard board, IFigure? figure, int toX, int toY)
        {
            if (figure == null)
                return false;
            var targetCoord = new Coord(toX, toY);
            var availablePositions = figure.GetAllAvailablePosition(board);

            // Recorrer manualmente la lista en lugar de usar Contains
            foreach (var coord in availablePositions)
            {
                if (coord.X == targetCoord.X && coord.Y == targetCoord.Y)
                    return true;
            }
            return false;
        }

        public void RemoveFigureAt(int x, int y)
        {
            if (x >= 0 && x < _width && y >= 0 && y < _height)
                _casillas[x, y].Figure = null;
        }

        public bool MoveSelectedFigure(int x, int y)
        {
            var figure = GetFigureAt(x, y);
            if (figure == null)
            {
                _selectedFigure = null;
                _selectedCoord = null;
                return false; // No hay figura en esa casilla
            }
            _selectedFigure = figure;
            _selectedCoord = new Coord(x, y);
            return true; // Figura seleccionada correctamente
        }

        //ESTE POR HUEVOS TIENE QUE PODERSE SIMPLIFICAR
        public void MostrarMovimientosDisponibles(IChessBoard board)
        {
            if (_selectedFigure == null || _selectedCoord == null)
            {
                Console.WriteLine("No hay ninguna figura seleccionada.");
                return;
            }

            var availableMoves = _selectedFigure.GetAllAvailablePosition(board);
            //esto es para no usar el this
            //ESTO PODRIA HACERSE CON UN DELEGADO VISIT CREO


            Console.WriteLine($"Movimientos disponibles para {_selectedFigure.GetType().Name} en {_selectedCoord}:");

            for (int y = Height - 1; y >= 0; y--)
            {
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

                    // Si esta casilla está en los movimientos permitidos, márcala con '*'
                    if (availableMoves.Any(c => c.X == x && c.Y == y))
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.BackgroundColor = (x + y) % 2 == 0 ? ConsoleColor.DarkGray : ConsoleColor.White;
                    }

                    Console.ForegroundColor = figure != null && figure.GetColor() == FigureColor.BLACK ? ConsoleColor.Black : ConsoleColor.DarkRed;
                    Console.Write($" {symbol} ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        //dibuja tablero
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
                    PrintColorCasillas(x, y, figure, symbol);
                }
                Console.WriteLine();
            }
            PrintLetrasFichas();
        }

        // Determinar el color de la casilla
        public void PrintLetrasFichas()
        {
            Console.Write("  ");
            for (char c = 'A'; c < 'A' + Width; c++)
            {
                Console.Write(" " + c + " "); // Letras de columnas
            }
            Console.WriteLine();
        }

        public void PrintColorCasillas(int x, int y, IFigure figure, char symbol)
        {
            Console.BackgroundColor = (x + y) % 2 == 0 ? ConsoleColor.DarkGray : ConsoleColor.White;
            Console.ForegroundColor = figure != null && figure.GetColor() == FigureColor.BLACK ? ConsoleColor.Black : ConsoleColor.DarkRed;

            Console.Write($" {symbol} ");
            Console.ResetColor();
        }
    }
}

//class ChessBoard : IChessBoard
//         *
//{
//         *      IChessBoard b = new ChessBoard();
//         * }