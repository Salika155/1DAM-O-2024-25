using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjedrezPARATONTOS
{
    public class ChessBoard
    {
        private readonly IFigure?[,] _board = new IFigure?[8, 8];

        public ChessBoard()
        {
            InitializePieces();
        }

        private void InitializePieces()
        {
            // Piezas negras (arriba)
            _board[0, 0] = new Tower(FigureColor.BLACK); // Torre a8
            _board[7, 0] = new Tower(FigureColor.BLACK); // Torre h8
            for (int x = 0; x < 8; x++)
            {
                _board[x, 1] = new Pawn(FigureColor.BLACK); // Peones fila 7
            }

            // Piezas blancas (abajo)
            _board[0, 7] = new Tower(FigureColor.WHITE); // Torre a1
            _board[7, 7] = new Tower(FigureColor.WHITE); // Torre h1
            for (int x = 0; x < 8; x++)
            {
                _board[x, 6] = new Pawn(FigureColor.WHITE); // Peones fila 2
            }
        }

        public void Draw()
        {
            Console.WriteLine("   a  b  c  d  e  f  g  h");
            for (int y = 0; y < 8; y++)
            {
                Console.Write($"{8 - y} "); // Números de fila (8 arriba, 1 abajo)
                for (int x = 0; x < 8; x++)
                {
                    Console.BackgroundColor = (x + y) % 2 == 0 ? ConsoleColor.DarkGray : ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.White;

                    var piece = _board[x, y];
                    Console.Write(piece != null ? $" {GetSymbol(piece)} " : "   ");
                }
                Console.ResetColor();
                Console.WriteLine($" {8 - y}");
            }
            Console.WriteLine("   a  b  c  d  e  f  g  h");
        }

        private static string GetSymbol(IFigure piece)
        {
            return piece switch
            {
                Tower t => t.Color == FigureColor.WHITE ? "T" : "t",
                Pawn p => p.Color == FigureColor.WHITE ? "P" : "p",
                _ => "?"
            };
        }
    }
}
