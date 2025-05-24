
using ChessLib.Figuras;
using System.Drawing;

namespace ChessLib.Tablero
{
    public class Utils
    {
        internal static int IndexOfCasilla(int x, int y, int width)
        {
            return y * width + x;
        }

        //esto creo que deberia ir aqui de alguna manera
        //public static void DrawBoard(ChessBoard board)
        //{
        //    //esto lo imprime junto, quiero separarlo
        //    Console.Write("a" + "   " + "b" + "   " + "c" + "   " + "d" + "   " + "e" + "   " + "f" + "   " + "g" + "   " + "h");
        //    for (int y = 0; y < board.GetHeight(); y++)
        //    {
        //        Console.Write(8 - y + " ");
        //        for (int x = 0; x < board.GetWidth(); x++)
        //        {
        //            IFigure? figura = board.GetFigureAt(x, y);
        //            Console.Write(figura != null ? GetSymbol(figura) : "· ");
        //        }
        //        Console.WriteLine();
        //    }
        //}

        

        public static bool IsValidCoordinates(int x, int y, int width, int height)
        {
            return x >= 0 && x < width && y >= 0 && y < height;
        }

        //public static void DrawBoard(ChessBoard board)
        //{
        //    Console.WriteLine("   a  b  c  d  e  f  g  h ");
        //    Console.WriteLine(" ");
        //    for (int y = board.GetHeight() - 1; y >= 0; y--)
        //    {
        //        Console.Write(1 + y + " ");
        //        for (int x = 0; x < board.GetWidth(); x++)
        //        {
        //            IFigure? figura = board.GetFigureAt(x, y);
        //            Casilla? casilla = board.GetCasillaAt(x, y);
        //            if (figura != null)
        //            {
        //                DrawFigure(figura, x, y);
        //            }
        //            else if (casilla != null)
        //            {
        //                DrawCasilla(casilla);
        //            }
        //            Console.Write(figura != null ? GetSymbol(figura) : "· ");
        //        }
        //        Console.ResetColor();
        //        Console.WriteLine();
        //    }
        //    Console.WriteLine(" ");
        //    Console.WriteLine("   a  b  c  d  e  f  g  h ");
        //}

        public static void DrawBoard(ChessBoard board)
        {
            Console.WriteLine("   a  b  c  d  e  f  g  h ");
            Console.WriteLine(" ");
            for (int y = 7; y >= 0; y--)
            {
                //Console.Write(8 - y + " ");
                Console.Write(1 + y + " ");
                for (int x = 0; x < board.GetWidth(); x++)
                {
                    var background = ((x + y) % 2 == 0) ? ConsoleColor.White : ConsoleColor.Red;
                    Console.BackgroundColor = background;

                    IFigure? figura = board.GetFigureAt(x, y);
                    if (figura != null)
                    {
                        DrawFigure(figura);
                    }
                    else
                    {
                        Console.Write("   "); // Casilla vacía
                    }
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
            Console.WriteLine(" ");
            Console.WriteLine("   a  b  c  d  e  f  g  h ");
        }

        //private static void DrawFigure(IFigure figure, int x, int y)
        //{//esto es, al dibujar de nuevo hace que el background sea como la figura

        //    Console.BackgroundColor = (x + y) % 2 == 0 ? ConsoleColor.White : ConsoleColor.Red;
        //    Console.ForegroundColor = figure.GetColor() == FigureColor.WHITE ? ConsoleColor.Black : ConsoleColor.DarkYellow;
        //    Console.Write(Utils.GetSymbol(figure));
        //    Console.ResetColor();
        //}
        private static void DrawFigure(IFigure figure)
        {
            Console.ForegroundColor = figure.GetColor() == FigureColor.WHITE ? ConsoleColor.Black : ConsoleColor.DarkYellow;
            Console.Write(Utils.GetSymbol(figure));
        }

        private static void DrawCasilla(Casilla? casilla)
        {
            var fondo = casilla?.Color == CasillaColor.WHITE ? ConsoleColor.White : ConsoleColor.Red;
            var texto = casilla?.Color == CasillaColor.WHITE ? ConsoleColor.Black : ConsoleColor.White;

            Console.BackgroundColor = fondo;
            Console.ForegroundColor = texto;
            Console.Write("   "); // <-- 3 espacios en blanco
            Console.ResetColor();
        }

        public static string GetSymbol(IFigure figura)
        {
            if (figura is Pawn) return " P ";
            if (figura is Tower) return " T ";
            if (figura is Knight) return " N ";
            if (figura is Bishop) return " B ";
            if (figura is Queen) return " Q ";
            if (figura is King) return " K ";
            else
                return "  ";
        }

        //static string GetSymbol(IFigure figura)
        //{
        //    if (figura is Pawn) return figura.GetColor() == FigureColor.WHITE ? "P " : "p ";
        //    if (figura is Tower) return figura.GetColor() == FigureColor.WHITE ? "T " : "t ";
        //    if (figura is Knight) return figura.GetColor() == FigureColor.WHITE ? "N " : "n ";
        //    if (figura is Bishop) return figura.GetColor() == FigureColor.WHITE ? "B " : "b ";
        //    if (figura is Queen) return figura.GetColor() == FigureColor.WHITE ? "Q " : "q ";
        //    if (figura is King) return figura.GetColor() == FigureColor.WHITE ? "K " : "k ";
        //    return "· ";
        //}

        //BISHOP
        public void MoveInDiagonal(IFigure figure, IChessBoard board, List<Coord> lista, int dx, int dy)//es posible que necesite meterle un ifigure
        {
            int x = figure.GetCoord().X + dx;
            int y = figure.GetCoord().Y + dy;

            while (Utils.IsValidCoordinates(dx, dy, board.GetWidth(), board.GetHeight()))
            {
                Coord destino = new(x, y);
                IFigure? figura = board.GetFigureAt(x, y);

                if (figura == null)
                {
                    lista.Add(destino);
                }
                else
                {
                    if (figura.GetColor() != figure.GetColor())
                        lista.Add(destino);
                    break;
                }

                x += dx;
                y += dy;
            }
        }

        //public static Coord ParsearCoordenada(string texto)
        //{
        //    if (texto.Length != 2)
        //        throw new ArgumentException("Coordenada inválida");

        //    char col = char.ToLower(texto[0]);
        //    char fila = texto[1];

        //    int x = col - 'a';
        //    int y = (fila - '0') - 1; // Porque la fila 8 es Y=0

        //    if (x < 0 || x >= 8 || y < 0 || y >= 8)
        //        throw new ArgumentException("Coordenada fuera de rango");

        //    return new Coord(x, y);
        //}
        //public static Coord ParsearCoordenada(string texto)
        //{
        //    if (texto.Length != 2)
        //        throw new ArgumentException("Coordenada inválida");

        //    char col = char.ToLower(texto[0]);
        //    char fila = texto[1];

        //    int x = col - 'a';
        //    int y = 7 - (fila - '1'); // '1' → 6, '2' → 5, ..., '8' → -1 (¡error!)

        //    // Corrección definitiva:
        //    y = 8 - (fila - '0'); // '1' → 7, '2' → 6, ..., '8' → 0

        //    if (x < 0 || x >= 8 || y < 0 || y >= 8)
        //        throw new ArgumentException("Coordenada fuera de rango");

        //    return new Coord(x, y);
        //}

        public static Coord ParsearCoordenada(string texto)
        {
            if (texto.Length != 2)
                throw new ArgumentException("Coordenada inválida");

            char col = char.ToLower(texto[0]);
            char fila = texto[1];

            int x = col - 'a';  // a=0, b=1, ..., h=7
            int y = 8 - (fila - '0');  // '1'→7, '2'→6, ..., '8'→0

            if (x < 0 || x >= 8 || y < 0 || y >= 8)
                throw new ArgumentException("Coordenada fuera de rango");

            Console.WriteLine($"DEBUG: Input '{texto}' → Coord ({x},{y})"); // Debug
            return new Coord(x, y);
        }
    }
}