using ChessLib.Figuras;
using ChessLib.Tablero;

namespace ChessExec
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Crear un tablero de ajedrez
            //var chessBoard = new ChessBoard();
            //Init();

            //ChessBoard board = new ChessBoard();
            //board.CreateFigures();

            //// Mover un peón blanco
            //board.MoveFigure(0, 1); // Mover el peón de (0, 1) a (0, 2)

            //// Mostrar información básica (solo para probar)

            //ChessBoard board1 = new ChessBoard();
            //MovementManager movement = new MovementManager();

            //while (true)
            //{
            //    // Turno jugador blanco
            //    Console.WriteLine("Turno de las blancas:");
            //    DrawBoard(board1);
            //    movement.ExecuteTurn(board1, FigureColor.WHITE);

            //    if (board1.IsCheckmate(FigureColor.BLACK))
            //    {
            //        Console.WriteLine("¡Jaque mate! Las blancas ganan.");
            //        break;
            //    }
            //    else if (board.IsKingInCheck(FigureColor.BLACK))
            //    {
            //        Console.WriteLine("¡Jaque al rey negro!");
            //    }

            //    // Turno jugador negro
            //    Console.WriteLine("Turno de las negras:");
            //    DrawBoard(board1);
            //    movement.ExecuteTurn(board1, FigureColor.BLACK);

            //    if (board1.IsCheckmate(FigureColor.WHITE))
            //    {
            //        Console.WriteLine("¡Jaque mate! Las negras ganan.");
            //        break;
            //    }
            //    else if (board1.IsKingInCheck(FigureColor.WHITE))
            //    {
            //        Console.WriteLine("¡Jaque al rey blanco!");
            //    }
            //}

            ChessBoard board = new ChessBoard();
            board.InitializeBoard();

            // Dibuja el tablero inicial
            Utils.DrawBoard(board);

            // Prueba mover un peón blanco
            Console.WriteLine("\nMoviendo un peón blanco:");
            board.MoveFigure(0, 1); // Mueve el peón de (0, 1) a (0, 2)
            Utils.DrawBoard(board);

            // Prueba mover un caballo negro
            Console.WriteLine("\nMoviendo un caballo negro:");
            board.MoveFigure(1, 7); // Mueve el caballo de (1, 7) a (2, 5)
            Utils.DrawBoard(board);

        }

        private static void DrawBoard(ChessBoard board1)
        {
            throw new NotImplementedException();
        }

        private static void Init()
        {
            throw new NotImplementedException();
        }
    }
}
