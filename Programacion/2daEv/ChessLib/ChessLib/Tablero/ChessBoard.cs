using ChessLib.Figuras;
using System.Drawing;

namespace ChessLib.Tablero
{
    public class ChessBoard : IChessBoard
    {
        private readonly Casilla[ , ] _casillas;
        private readonly int _width;
        private readonly int _height;
        private readonly Figure[] _figures;
        private int _figureCount = 0;

        public int Width => _width;
        public int Height => _height;

        public ChessBoard(int width, int height)
        {
            _width = width;
            _height = height;
            _casillas = new Casilla[width, height];
            _figures = new Figure[32];
            InitializeBoard();
            //metodo para iniciar fichas
        }

        public ChessBoard() : this (8, 8)
        {

        }

        public void InitializeBoard()
        {
            CrearCasillas();
            CreateFigures();
        }

        public void CrearCasillas()
        {
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    var color = (x + y) % 2 == 0 ? CasillaColor.WHITE : CasillaColor.BLACK;
                    var coord = new Coord(x, y);
                    _casillas[x, y] = new Casilla(coord);
                }
            }
        }

        public void CreateFigures()
        {
            // Colocar las piezas blancas
            CreateFigure(FigureType.TOWER, FigureColor.WHITE, new Coord(0, 0));
            CreateFigure(FigureType.KNIGHT, FigureColor.WHITE, new Coord(1, 0));
            CreateFigure(FigureType.BISHOP, FigureColor.WHITE, new Coord(2, 0));
            CreateFigure(FigureType.QUEEN, FigureColor.WHITE, new Coord(3, 0));
            CreateFigure(FigureType.KING, FigureColor.WHITE, new Coord(4, 0));
            CreateFigure(FigureType.BISHOP, FigureColor.WHITE, new Coord(5, 0));
            CreateFigure(FigureType.KNIGHT, FigureColor.WHITE, new Coord(6, 0));
            CreateFigure(FigureType.TOWER, FigureColor.WHITE, new Coord(7, 0));

            for (int x = 0; x < 8; x++)
            {
                CreateFigure(FigureType.PAWN, FigureColor.WHITE, new Coord(x, 1));
            }

            // Colocar las piezas negras
            CreateFigure(FigureType.TOWER, FigureColor.BLACK, new Coord(0, 7));
            CreateFigure(FigureType.KNIGHT, FigureColor.BLACK, new Coord(1, 7));
            CreateFigure(FigureType.BISHOP, FigureColor.BLACK, new Coord(2, 7));
            CreateFigure(FigureType.QUEEN, FigureColor.BLACK, new Coord(3, 7));
            CreateFigure(FigureType.KING, FigureColor.BLACK, new Coord(4, 7));
            CreateFigure(FigureType.BISHOP, FigureColor.BLACK, new Coord(5, 7));
            CreateFigure(FigureType.KNIGHT, FigureColor.BLACK, new Coord(6, 7));
            CreateFigure(FigureType.TOWER, FigureColor.BLACK, new Coord(7, 7));

            for (int x = 0; x < 8; x++)
            {
                CreateFigure(FigureType.PAWN, FigureColor.BLACK, new Coord(x, 6));
            }
        }

        public void CreateFigure(FigureType type, FigureColor color, Coord coord)
        {
            if (_figureCount >= _figures.Length)
            {
                throw new Exception("No se pueden añadir más figuras, el array está lleno.");
            }

            Figure figura = type switch
            {
                FigureType.TOWER => new Tower(color, type, coord),
                FigureType.KNIGHT => new Knight(color, type, coord),
                FigureType.BISHOP => new Bishop(color, type, coord),
                FigureType.QUEEN => new Queen(color, type, coord),
                FigureType.KING => new King(color, type, coord),
                FigureType.PAWN => new Pawn(color, type, coord),
                _ => throw new ArgumentException("Tipo de figura inválido")
            };

            _casillas[coord.X, coord.Y].Figure = figura;
            _figures[_figureCount++] = figura;
        }

        public bool MoveFigure(int x, int y)
        {
            
            // Verificar si las coordenadas están dentro del tablero
            if (x < 0 || x >= _width || y < 0 || y >= _height)
                return false;

            // Obtener la figura en la posición actual
            var figure = _casillas[x, y].Figure;

            // Verificar si hay una figura en la posición actual
            if (figure == null)
                return false;

            // Obtener las posiciones disponibles para la figura
            var availablePositions = figure.GetAvailablePosition(this);

            // Verificar si la nueva posición está en las posiciones disponibles
            foreach (var pos in availablePositions)
            {
                if (pos.X == x && pos.Y == y)
                {
                    // Mover la figura a la nueva posición
                    _casillas[x, y].Figure = figure;
                    return true;
                }
            }
            return false;
        }

        public void RemoveFigureAt(int x, int y)
        {
            if (x >= 0 && x < _width && y >= 0 && y < _height)
                _casillas[x, y].Figure = null;
        }

        public IFigure? GetFigureAt(int x, int y)
        {
            if (x < 0 || x >= _width || y < 0 || y >= _height)
                return null; // Fuera del tablero.
            return _casillas[x, y].Figure;
        }

        public IFigure GetFigureAt(int index)
        {
            if (index < 0 || index >= _figures.Length)
            {
                throw new ArgumentOutOfRangeException("Index is out of range");
            }
            return _figures[index];
        }

        public int GetFigureCount()
        {
            return _figures.Length;
        }

        public int GetHeight()
        {
            return _height;
        }

        public int GetWidth()
        {
            return _width;
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
            _figureCount = 0;
        }

        public bool IsPositionEmpty(Coord movAdelante)
        {
            throw new NotImplementedException();
        }

        public bool HasEnemyPiece(Coord target, FigureColor color)
        {
            throw new NotImplementedException();
        }

        public bool IsKingInCheck(FigureColor color)
        {
            Coord kingPosition = FindKingPosition(color);
            foreach (var figura in _figures)
            {
                if (figura != null && figura.Color != color)
                {
                    var availablePositions = figura.GetAvailablePosition(this);
                    foreach (var pos in availablePositions)
                    {
                        if (pos.X == kingPosition.X && pos.Y == kingPosition.Y)
                            return true;
                    }
                }
            }
            return false;
        }

        private Coord FindKingPosition(FigureColor color)
        {
            foreach (var figura in _figures)
            {
                if (figura != null && figura.Type == FigureType.KING && figura.Color == color)
                    return figura.Coords;
            }
            throw new Exception("Rey no encontrado");
        }

        public bool IsCheckmate(FigureColor color)
        {
            if (!IsKingInCheck(color)) return false;

            foreach (var figura in _figures)
            {
                if (figura != null && figura.Color == color)
                {
                    var availablePositions = figura.GetAvailablePosition(this);
                    if (availablePositions.Length > 0)
                        return false;
                }
            }

            return true;
        }
    }
}

//class ChessBoard : IChessBoard
//         *
//{
//         *      IChessBoard b = new ChessBoard();
//         * }