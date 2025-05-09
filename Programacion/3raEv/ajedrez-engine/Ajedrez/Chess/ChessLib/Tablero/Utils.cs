
using ChessLib.Figuras;

namespace ChessLib.Tablero
{
    public class Utils
    {
        internal static int IndexOfCasilla(int x, int y, int width)
        {
            return y * width + x;
        }

        //esto creo que deberia ir aqui de alguna manera
        public static void DrawBoard(ChessBoard board)
        {
            //esto lo imprime junto, quiero separarlo
            Console.Write("a" + "   " + "b" + "   " + "c" + "   " + "d" + "   " + "e" + "   " + "f" + "   " + "g" + "   " + "h");
            for (int y = 0; y < board.GetHeight(); y++)
            {
                Console.Write(8 - y + " ");
                for (int x = 0; x < board.GetWidth(); x++)
                {
                    IFigure? figura = board.GetFigureAt(x, y);
                    Console.Write(figura != null ? GetSymbol(figura) : "· ");
                }
                Console.WriteLine();
            }
        }

        static string GetSymbol(IFigure figura)
        {
            if (figura is Pawn) return figura.GetColor() == FigureColor.WHITE ? "P " : "p ";
            if (figura is Tower) return figura.GetColor() == FigureColor.WHITE ? "T " : "t ";
            if (figura is Knight) return figura.GetColor() == FigureColor.WHITE ? "N " : "n ";
            if (figura is Bishop) return figura.GetColor() == FigureColor.WHITE ? "B " : "b ";
            if (figura is Queen) return figura.GetColor() == FigureColor.WHITE ? "Q " : "q ";
            if (figura is King) return figura.GetColor() == FigureColor.WHITE ? "K " : "k ";
            return "· ";
        }

        internal static bool IsValidCoordinates(int x, int y, int width, int height)
        {
            return x >= 0 && x < width && y >= 0 && y < height;
        }
    }
}