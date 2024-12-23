using ChessLib.Figuras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
            for (int i = 0; i < _figures.Length; i++)
            {
                _figures[i] = null; // Limpia cada posición del array sin cambiar la referencia.
            }
        }

        public IFigure? GetFigureAt(int? x, int? y)
        {
            if (x == null || y == null)
                return null;
            for (int i = 0; i <= _figures.Length - 1; i++)
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
                var whitePawn = CrearFigura(FigureColor.WHITE, FigureType.PAWN, x, 1);
                //Console.WriteLine($"Creando figura: {whitePawn.Color} {whitePawn.Type} en {whitePawn.Coords}");
                _figures[index++] = whitePawn;

                // Crear y asignar peones negros
                var blackPawn = CrearFigura(FigureColor.BLACK, FigureType.PAWN, x, 6);
                //Console.WriteLine($"Creando figura: {blackPawn.Color} {blackPawn.Type} en {blackPawn.Coords}");
                _figures[index++] = blackPawn;
            }

            // Torres
            //esta no la dibuja
            var whiteTower1 = CrearFigura(FigureColor.WHITE, FigureType.TOWER, 0, 0);
            //var whiteTower1 = new Tower(FigureColor.WHITE, FigureType.TOWER, new Coord(0, 0));
            var whiteTower2 = CrearFigura(FigureColor.WHITE, FigureType.TOWER, 7, 0);
            var blackTower1 = CrearFigura(FigureColor.BLACK, FigureType.TOWER, 0, 7);
            var blackTower2 = CrearFigura(FigureColor.BLACK, FigureType.TOWER, 7, 7);
             
            _figures[index++] = whiteTower1;
            _figures[index++] = whiteTower2;
            _figures[index++] = blackTower1;
            _figures[index++] = blackTower2;

            _casillas[0, 0].Figure = whiteTower1;
            _casillas[7, 0].Figure = whiteTower2;
            _casillas[0, 7].Figure = blackTower1;
            _casillas[7, 7].Figure = blackTower2;

            // Caballos
            var whiteKnight1 = CrearFigura(FigureColor.WHITE, FigureType.KNIGHT, 1, 0);
            //var whiteKnight1 = new Knight(FigureColor.WHITE, new Coord(1, 0), FigureType.KNIGHT);
            var whiteKnight2 = CrearFigura(FigureColor.WHITE, FigureType.KNIGHT, 6, 0);
            var blackKnight1 = CrearFigura(FigureColor.BLACK, FigureType.KNIGHT, 1, 7);
            var blackKnight2 = CrearFigura(FigureColor.BLACK, FigureType.KNIGHT, 6, 7);

            _figures[index++] = whiteKnight1;
            _figures[index++] = whiteKnight2;
            _figures[index++] = blackKnight1;
            _figures[index++] = blackKnight2;

            _casillas[1, 0].Figure = whiteKnight1;
            _casillas[6, 0].Figure = whiteKnight2;
            _casillas[1, 7].Figure = blackKnight1;
            _casillas[6, 7].Figure = blackKnight2;

            // Alfiles
            var whiteBishop1 = CrearFigura(FigureColor.WHITE, FigureType.BISHOP, 2, 0);
            //var whiteBishop1 = new Bishop(FigureColor.WHITE, new Coord(2, 0), FigureType.BISHOP);
            var whiteBishop2 = CrearFigura(FigureColor.WHITE, FigureType.BISHOP, 5, 0);
            var blackBishop1 = CrearFigura(FigureColor.BLACK, FigureType.BISHOP, 2, 7);
            var blackBishop2 = CrearFigura(FigureColor.BLACK, FigureType.BISHOP, 5, 7);

            _figures[index++] = whiteBishop1;
            _figures[index++] = whiteBishop2;
            _figures[index++] = blackBishop1;
            _figures[index++] = blackBishop2;

            _casillas[2, 0].Figure = whiteBishop1;
            _casillas[5, 0].Figure = whiteBishop2;
            _casillas[2, 7].Figure = blackBishop1;
            _casillas[5, 7].Figure = blackBishop2;

            // Reina
            var whiteQueen = CrearFigura(FigureColor.WHITE, FigureType.QUEEN, 3, 0);
            var blackQueen = CrearFigura(FigureColor.BLACK, FigureType.QUEEN, 3, 7);

            _figures[index++] = whiteQueen;
            _figures[index++] = blackQueen;

            _casillas[3, 0].Figure = whiteQueen;
            _casillas[3, 7].Figure = blackQueen;

            //Rey
            var whiteKing = CrearFigura(FigureColor.WHITE, FigureType.KING, 4, 0);
            var blackKing = CrearFigura(FigureColor.BLACK, FigureType.KING, 4, 7);
            
            //Console.WriteLine($"Creando rey blanco: {whiteKing.Color}, {whiteKing.Type}, {whiteKing.Coords}");
            //Console.WriteLine($"Creando rey negro: {blackKing.Color}, {blackKing.Type}, {blackKing.Coords}");
            _figures[index++] = whiteKing;
            _figures[index++] = blackKing;

            _casillas[4, 0].Figure = whiteKing;
            _casillas[4, 7].Figure = blackKing;
        }

        //esto asi no me gusta, tengo que revisarlo
        public static Figure CrearFigura(FigureColor color, FigureType type, int x, int y)
        {
            //return new Figure(color, new Coord(x, y), type);
            switch (type)
            {
                case FigureType.PAWN:
                    return new Pawn(color, type, new Coord(x, y));

                case FigureType.TOWER:
                    return new Tower(color, type, new Coord(x, y));

                case FigureType.BISHOP:
                    return new Bishop(color, type, new Coord(x, y));

                case FigureType.KNIGHT:
                    return new Knight(color, type, new Coord(x, y));

                case FigureType.KING:
                    return new King(color, type, new Coord(x, y));

                case FigureType.QUEEN:
                    return new Queen(color, type, new Coord(x, y));

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
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    IFigure? figure = GetFigureAt(x, y);
                    //FigureColor figure1 = GetFigureColor()
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
            //Console.WriteLine($"Dibujando figura: {figure.Color} {figure.Type}");
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
                default:
                    Console.Write(" ? ");
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