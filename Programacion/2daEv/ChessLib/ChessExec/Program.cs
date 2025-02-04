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

            ChessBoard board = new ChessBoard();
            board.InitBoard();

            // Mover un peón blanco
            board.MoveFigure(0, 1); // Mover el peón de (0, 1) a (0, 2)

            // Mostrar información básica (solo para probar)

        }

        private static void Init()
        {
            throw new NotImplementedException();
        }
    }
}
