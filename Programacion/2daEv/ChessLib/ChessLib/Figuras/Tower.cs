using ChessLib.Tablero;
using System.Drawing;

namespace ChessLib.Figuras
{
    public class Tower : Figure
    {
        public Tower(FigureColor color, FigureType type, Coord coords) : base(color, FigureType.TOWER, coords)
        {
            
        }

        public override List<Coord> GetAllAvailablePosition(IChessBoard board)
        {
            return GetAvailablePosition(board).ToList();
        }

        public override Coord[] GetAvailablePosition(IChessBoard board)
        {
            List<Coord> moves = new List<Coord>();
            int x = Coords.X;
            int y = Coords.Y;

            // Movimiento horizontal y vertical
            for (int i = 0; i < 8; i++)
            {
                if (i != x) moves.Add(new Coord(i, y));
                if (i != y) moves.Add(new Coord(x, i));
            }
            //// Filtramos los movimientos que están fuera del tablero o bloqueados por otras piezas
            //moves = moves.Where(m => board.IsPositionEmpty(m) || board.HasEnemyPiece(m, Color)).ToList();
            List<Coord> validMoves = new List<Coord>();
            foreach (var move in moves)
            {
                if (board.IsPositionEmpty(move) || board.HasEnemyPiece(move, Color))
                {
                    validMoves.Add(move);
                }
            }
            return validMoves.ToArray();
        }

    }

    //public override List<Coord> GetAllAvailablePosition(IChessBoard board)
    //{
    //    throw new NotImplementedException();
    //}

    //public override Coord? GetAvailablePosition(IChessBoard board)
    //{
    //    throw new NotImplementedException();
    //}

    //protected override bool IsMoveValidForPiece(Coord target, IChessBoard board)
    //{
    //    throw new NotImplementedException();
    //}
}

