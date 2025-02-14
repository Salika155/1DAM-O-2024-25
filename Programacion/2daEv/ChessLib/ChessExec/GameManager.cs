using ChessLib.Figuras;
using ChessLib.Tablero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessExec
{
    public class GameManager
    {
        private readonly ChessBoard _board;
        private readonly MovementManager _movementManager;
        private FigureColor _currentTurn;

        public GameManager()
        {
            _board = new ChessBoard();
            _movementManager = new MovementManager();
            _currentTurn = FigureColor.WHITE; // Las blancas siempre empiezan
        }

        public void StartGame()
        {
            while (true)
            {
                Utils.DrawBoard(_board);
                Console.WriteLine($"Turno de las {(_currentTurn == FigureColor.WHITE ? "blancas" : "negras")}:");

                // Ejecutar el turno del jugador actual
                _movementManager.ExecuteTurn(_board, _currentTurn);

                // Verificar si el oponente está en jaque o jaque mate
                FigureColor opponentColor = _currentTurn == FigureColor.WHITE ? FigureColor.BLACK : FigureColor.WHITE;
                if (_board.IsCheckmate(opponentColor))
                {
                    Console.WriteLine($"¡Jaque mate! Las {_currentTurn} ganan.");
                    break;
                }
                else if (_board.IsKingInCheck(opponentColor))
                {
                    Console.WriteLine($"¡Jaque al rey {opponentColor}!");
                }

                // Cambiar de turno
                _currentTurn = opponentColor;
            }
        }
    }
}
