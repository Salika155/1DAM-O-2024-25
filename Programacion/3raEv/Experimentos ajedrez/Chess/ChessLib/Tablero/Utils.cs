
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


        //esto es porque al mover figura se me cambiaba de color la casilla 
        //Haciendo este metodo se asegura que la casilla cambie
        public static void RedibujarCasilla(IChessBoard board, int x, int y)
        {
            if (!IsValidCoordinates(x, y, board.GetWidth(), board.GetHeight()))
                return;

            var casilla = board.GetCasillaAt(x, y);
            var figura = board.GetFigureAt(x, y);

            if (casilla == null)
                return;

            // Opcional: Mover el cursor a la posición correspondiente en consola

            //lo primero es para la posicion horizontal de las casillas, ocupando 3 espacios en su diseño
            //lo segundo es para invertir el eje para que la fila 0 este abajo y la 7 arriba
            Console.SetCursorPosition(x * 3 + 2, (board.GetHeight() - y) + 1);
            if (figura != null)
            {
                DrawFigure(figura, x, y);
            }
            else
            {
                DrawCasilla(casilla);
            }
            Console.ResetColor();
        }


        public static bool IsValidCoordinates(int x, int y, int width, int height)
        {
            return x >= 0 && x < width && y >= 0 && y < height;
        }

        public static void DrawBoard(ChessBoard board)
        {
            Console.WriteLine("   a  b  c  d  e  f  g  h ");
            Console.WriteLine(" ");
            for (int row = 0; row < board.GetHeight(); row++)
            {
                Console.Write(row + " ");
                for (int col = 0; col < board.GetWidth(); col++)
                {
                    IFigure? figura = board.GetFigureAt(col, row);
                    Casilla? casilla = board.GetCasillaAt(col, row);
                    if (figura != null)
                    {
                        DrawFigure(figura, col, row);
                    }
                    else if (casilla != null)
                    {
                        DrawCasilla(casilla);
                    }
                    //Console.Write(figura != null ? GetSymbol(figura) : "· ");
                }
                Console.ResetColor();
                Console.WriteLine();
            }
            Console.WriteLine(" ");
            Console.WriteLine("   a  b  c  d  e  f  g  h ");
        }

        private static void DrawFigure(IFigure figure, int x, int y)
        {//esto es, al dibujar de nuevo hace que el background sea como la figura
            // Color de fondo basado en coordenadas (no cambiar)
            var background = (figure.GetCoord().X + figure.GetCoord().Y) % 2 == 0
                ? ConsoleColor.White : ConsoleColor.Red;

            // ¡CORRECCIÓN CLAVE AQUÍ! (Colores invertidos)
            Console.ForegroundColor = figure.GetColor() == FigureColor.WHITE
                ? ConsoleColor.DarkYellow  : ConsoleColor.Black;     

            Console.BackgroundColor = background;
            Console.Write(GetSymbol(figure));
        }

        private static void DrawCasilla(Casilla? casilla)
        {
            var fondo = casilla?.Color == CasillaColor.WHITE ? ConsoleColor.White : ConsoleColor.Red;
            var texto = casilla?.Color == CasillaColor.WHITE ? ConsoleColor.Black : ConsoleColor.White;

            Console.BackgroundColor = fondo;
            Console.ForegroundColor = texto;
            Console.Write("   "); // <-- 3 espacios en blanco
            //Console.ResetColor();
        }

        public static string GetSymbol(IFigure figura)
        {
            switch(figura)
            {
                case Pawn: return " P ";
                case Tower: return " T ";
                case Knight: return " N ";
                case Bishop: return " B ";
                case Queen: return " Q ";
                case King: return " K ";
                default: return "   "; 
            }
        }


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

        public static void AgregarMovimientosLineales(IFigure figure, IChessBoard board, List<Coord> moves, int dx, int dy)
        {
            int x = figure.Coords.X + dx;
            int y = figure.Coords.Y + dy;

            while (IsValidCoordinates(x, y, board.GetWidth(), board.GetHeight()))
            {
                var destino = new Coord(x, y);
                var figura = board.GetFigureAt(x, y);

                if (figura == null)
                {
                    moves.Add(destino);
                }
                else
                {
                    if (figura.GetColor() != figure.GetColor())
                        moves.Add(destino); // puede capturar
                    break; // no puede seguir más allá
                }
                x += dx;
                y += dy;
            }
        }

        public static Coord ParsearCoordenada(string texto)
        {
            if (texto.Length != 2)
                throw new ArgumentException("Coordenada inválida");

            #region parsecomentado
            //char col = char.ToLower(texto[0]);
            //char fila = texto[1];

            //int x = col - 'a';
            //int y = 8 - (fila - '0'); // Porque la fila 8 es Y=0

            //if (x < 0 || x >= 8 || y < 0 || y >= 8)
            //    throw new ArgumentException("Coordenada fuera de rango");
            //return new Coord(x, y);
            #endregion
            texto = texto.ToLower();
            int col = texto[0] - 'a';  // 'a' -> 0, 'b' -> 1, etc.
            int row = texto[1] - '0';  // '0' -> 0, '1' -> 1, etc.
            return new Coord(row, col);
        }

        public static void DrawBoardWithHighlight(ChessBoard board, Coord origen, List<Coord> movimientosValidos)
        {
            Console.WriteLine("    a    b    c    d    e    f    g    h  ");
            Console.WriteLine(" ");
            for (int row = 0; row < board.GetHeight(); row++)
            {
                Console.Write(row + " ");
                for (int col = 0; col < board.GetWidth(); col++)
                {
                    IFigure? figura = board.GetFigureAt(col, row);
                    Casilla? casilla = board.GetCasillaAt(col, row);

                    // 1. Resaltar ORIGEN (amarillo)
                    if (col == origen.X && row == origen.Y)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                    }
                    // 2. Resaltar MOVIMIENTOS VÁLIDOS (verde)
                    else if (movimientosValidos.Any(m => m.X == col && m.Y == row))
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                    }

                    // 3. Dibujar contenido de la casilla
                    if (figura != null)
                    {
                        Console.Write($" {GetSymbol(figura)} ");
                    }
                    else
                    {
                        Console.Write("  ·  "); // Casilla vacía
                    }

                    Console.ResetColor();
                }
                Console.WriteLine();
            }
            Console.WriteLine(" ");
            Console.WriteLine("    a    b    c    d    e    f    g    h  ");
        }
    }
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

//public static void DrawBoardWithHighlights(ChessBoard board, Coord origen, List<Coord> movimientosValidos)
//{
//    Console.WriteLine("  a   b   c   d   e   f   g   h");
//    Console.WriteLine("---------------------------------");
//    for (int y = 0; y < 8; y++)
//    {
//        Console.Write(y + "|");
//        for (int x = 0; x < 8; x++)
//        {
//            // Resaltar origen (amarillo) y destinos válidos (verde)
//            if (x == origen.X && y == origen.Y)
//                Console.BackgroundColor = ConsoleColor.DarkYellow;
//            else if (movimientosValidos.Any(m => m.X == x && m.Y == y))
//                Console.BackgroundColor = ConsoleColor.DarkGreen;

//            IFigure figura = board.GetFigureAt(x, y);
//            Console.Write($" {(figura != null ? Utils.GetSymbol(figura) : " ")} |");
//            Console.ResetColor();
//        }
//        Console.WriteLine(y + "\n---------------------------------");
//    }
//    Console.WriteLine("  a   b   c   d   e   f   g   h");
//}

//private static void DrawFigure(IFigure figure, int x, int y)
//{//esto es, al dibujar de nuevo hace que el background sea como la figura

//    //Console.BackgroundColor = (x + y) % 2 == 0 ? ConsoleColor.White : ConsoleColor.Red;
//    ////Console.ForegroundColor = figure.GetColor() == FigureColor.WHITE ? ConsoleColor.Black : ConsoleColor.DarkYellow;
//    //Console.Write(Utils.GetSymbol(figure));
//    //Console.ResetColor();
//    // Color de fondo basado en coordenadas (no cambiar)
//    var background = (figure.GetCoord().X + figure.GetCoord().Y) % 2 == 0
//        ? ConsoleColor.White
//        : ConsoleColor.Red;

//    // ¡CORRECCIÓN CLAVE AQUÍ! (Colores invertidos)
//    Console.ForegroundColor = figure.GetColor() == FigureColor.WHITE
//        ? ConsoleColor.DarkYellow  // Amarillo para blancas
//        : ConsoleColor.Black;      // Negro para negras

//    Console.BackgroundColor = background;
//    Console.Write(GetSymbol(figure));
//    //Console.ResetColor();
//}