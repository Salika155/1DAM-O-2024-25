using ChessLib.Tablero;
using ChessLib.Figuras;

namespace ChessExec
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Crear un tablero de ajedrez
            //GameController game = new GameController();
            //game.IniciarJuego();
            var chessBoard = new ChessBoard(8, 8);
            chessBoard.InitBoard();
            chessBoard.PrintBoard();


            // Mostrar información básica (solo para probar)
        }
    }

        
    
}
