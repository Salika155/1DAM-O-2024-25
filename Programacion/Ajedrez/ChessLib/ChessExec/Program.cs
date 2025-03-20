using ChessLib.Tablero;

namespace ChessExec
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Crear un tablero de ajedrez
            var chessBoard = new ChessBoard(8, 8);
            Init();
            chessBoard.PrintBoard();


            // Mostrar información básica (solo para probar)
        }

        private static void Init()
        {
            
            
        }
    }

        
    
}
