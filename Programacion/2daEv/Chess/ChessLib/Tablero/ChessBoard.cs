using ChessLib.Figuras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            InitBoard();
            //metodo para iniciar fichas
        }

        public ChessBoard() : this(8, 8)
        {

        }

        public static IChessBoard b { get; } = new ChessBoard();

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public IFigure? GetFigureAt(int? x, int? y)
        {
            if (x == null || y == null)
                return null;
            for (int i = 0; i < _figures.Length - 1; i++)
            {
                Figure? f = _figures[i];

                if (f.Coords.X == x && f.Coords.Y == y)
                    return f;
            }
            return null;
        }

        public IFigure? GetFigureAt(int? index)
        {
            if (index <= 0 || index > _figures.Length)
                return null;

            for (int i = 0; i < _figures.Length; i++)
            {
                Figure f = _figures[i];
                if (index == i)
                    return f;
            }
            return null;
        }

        public int IndexOfFIgure(int index)
        {
            for (int i = 0; i < _figures.Length; i++)
            {
                if (i == index)
                    return i;
            }
            return -1;
        }

        public bool ContainsFigure(int index)
        {
            return IndexOfFIgure(index) != -1;
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
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    _casillas[x, y] = CrearCasilla(x, y);
                }
            }
            CrearFiguras();
        }

        public void CrearFiguras()
        {
            int index = 0;

            // Peones
            for (int x = 0; x < _width; x++)
            {
                _figures[index++] = new Pawn(FigureColor.WHITE, new Coord(x, 1), FigureType.PAWN);
                _figures[index++] = new Pawn(FigureColor.BLACK, new Coord(x, 6), FigureType.PAWN);

                // Asigna las figuras a las casillas correspondientes
                _casillas[x, 1].Figure = _figures[index - 2]; // Peón blanco
                _casillas[x, 6].Figure = _figures[index - 1]; // Peón negro
            }

            // Torres
            _figures[index++] = new Tower(FigureColor.WHITE, new Coord(0, 0), FigureType.TOWER);
            _figures[index++] = new Tower(FigureColor.WHITE, new Coord(7, 0), FigureType.TOWER);
            _figures[index++] = new Tower(FigureColor.BLACK, new Coord(0, 7), FigureType.TOWER);
            _figures[index++] = new Tower(FigureColor.BLACK, new Coord(7, 7), FigureType.TOWER);

            // Asigna las torres a las casillas correspondientes
            _casillas[0, 0].Figure = _figures[index - 4];
            _casillas[7, 0].Figure = _figures[index - 3];
            _casillas[0, 7].Figure = _figures[index - 2];
            _casillas[7, 7].Figure = _figures[index - 1];

            // Caballos
            _figures[index++] = new Knight(FigureColor.WHITE, new Coord(1, 0), FigureType.KNIGHT);
            _figures[index++] = new Knight(FigureColor.WHITE, new Coord(6, 0), FigureType.KNIGHT);
            _figures[index++] = new Knight(FigureColor.BLACK, new Coord(1, 7), FigureType.KNIGHT);
            _figures[index++] = new Knight(FigureColor.BLACK, new Coord(6, 7), FigureType.KNIGHT);

            // Asigna los caballos a las casillas correspondientes
            _casillas[1, 0].Figure = _figures[index - 4];
            _casillas[6, 0].Figure = _figures[index - 3];
            _casillas[1, 7].Figure = _figures[index - 2];
            _casillas[6, 7].Figure = _figures[index - 1];

            // Alfiles
            _figures[index++] = new Bishop(FigureColor.WHITE, new Coord(2, 0), FigureType.BISHOP);
            _figures[index++] = new Bishop(FigureColor.WHITE, new Coord(5, 0), FigureType.BISHOP);
            _figures[index++] = new Bishop(FigureColor.BLACK, new Coord(2, 7), FigureType.BISHOP);
            _figures[index++] = new Bishop(FigureColor.BLACK, new Coord(5, 7), FigureType.BISHOP);

            // Asigna los alfiles a las casillas correspondientes
            _casillas[2, 0].Figure = _figures[index - 4];
            _casillas[5, 0].Figure = _figures[index - 3];
            _casillas[2, 7].Figure = _figures[index - 2];
            _casillas[5, 7].Figure = _figures[index - 1];

            // Reina
            _figures[index++] = new Queen(FigureColor.WHITE, new Coord(3, 0), FigureType.QUEEN);
            _figures[index++] = new Queen(FigureColor.BLACK, new Coord(3, 7), FigureType.QUEEN);

            // Asigna las reinas a las casillas correspondientes
            _casillas[3, 0].Figure = _figures[index - 2];
            _casillas[3, 7].Figure = _figures[index - 1];

            // Rey
            _figures[index++] = new King(FigureColor.WHITE, new Coord(4, 0), FigureType.KING);
            _figures[index++] = new King(FigureColor.BLACK, new Coord(4, 7), FigureType.KING);

            // Asigna los reyes a las casillas correspondientes
            _casillas[4, 0].Figure = _figures[index - 2];
            _casillas[4, 7].Figure = _figures[index - 1];
        }

        //esto asi no me gusta, tengo que revisarlo
        public static Figure CrearFigura(FigureColor color, FigureType type, int x, int y)
        {
            switch (type)
            {
                case FigureType.PAWN:
                    return new Pawn(color, new Coord(x, y), type);

                case FigureType.TOWER:
                    return new Tower(color, new Coord(x, y), type);

                case FigureType.BISHOP:
                    return new Bishop(color, new Coord(x, y), type);

                case FigureType.KNIGHT:
                    return new Knight(color, new Coord(x, y), type);

                case FigureType.KING:
                    return new King(color, new Coord(x, y), type);

                case FigureType.QUEEN:
                    return new Queen(color, new Coord(x, y), type);

                default:
                    throw new NotImplementedException($"La figura de tipo {type} no está implementada.");
            }
        }
        //hara falta metodo para inicializar figuras

        public bool MoveFigure(int x, int y)
        {
            throw new NotImplementedException();
        }

        public static Casilla CrearCasilla(int x, int y)
        {
            var color = (x + y) % 2 == 0 ? CasillaColor.WHITE : CasillaColor.BLACK;
            return new Casilla(new Coord(x, y));
        }

        public void PrintBoard()
        {
            for (int y = _height - 1; y >= 0; y--)
            {
                for (int x = 0; x < _width; x++)
                {
                    IFigure? figure = GetFigureAt(x, y);
                    if (figure != null)
                    {
                        DrawFigure(figure);
                    }
                    else
                    {
                        Console.Write(" . ");
                    }
                }
                Console.WriteLine();
            }
        }

        public static void DrawFigure(IFigure figure)
        {
            switch (figure.Type)
            {
                case FigureType.BISHOP:
                    Console.Write(" B ");
                    break;
                case FigureType.KING:
                    Console.Write(" K ");
                    break;
                case FigureType.KNIGHT:
                    Console.Write(" S ");
                    break;
                case FigureType.PAWN:
                    Console.Write(" P ");
                    break;
                case FigureType.QUEEN:
                    Console.Write(" Q ");
                    break;
                case FigureType.TOWER:
                    Console.Write(" T ");
                    break;
            }
        }
    }
}

//class ChessBoard : IChessBoard
//         *
//{
//         *      IChessBoard b = new ChessBoard();
//         * }