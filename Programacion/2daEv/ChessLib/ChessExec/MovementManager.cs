using ChessLib;
using ChessLib.Figuras;
using ChessLib.Tablero;

namespace ChessExec
{
    internal class MovementManager
    {
        //internal void ExecuteTurn(ChessBoard board1, FigureColor wHITE)
        //{
        //    throw new NotImplementedException();
        //}

        public void ExecuteTurn(ChessBoard board, FigureColor turn)
        {
            //foreach (var figura in board.GetAllFigures())
            //{
            //    if (figura != null && figura.GetColor() == turn)
            //    {
            //        var movimientosValidos = figura.GetAvailablePosition(board);

            //        if (movimientosValidos.Length > 0)
            //        {
            //            Coord destino = SelectBestMove(figura, movimientosValidos);
            //            board.MoveFigure(figura.GetCoord(), destino);
            //        }
            //    }
            //}
        }

        public Coord SelectBestMove(Figure figura, Coord[] movimientos)
        {
            // Lógica de selección de movimiento (ej: priorizar capturas)
            return movimientos[0]; // Versión simplificada
        }



    }
}