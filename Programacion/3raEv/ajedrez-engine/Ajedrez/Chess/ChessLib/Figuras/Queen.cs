using ChessLib.Tablero;

namespace ChessLib.Figuras
{
    public class Queen : Figure
    {
        public Queen(FigureColor color, FigureType type, Coord coords) : base(color, FigureType.QUEEN, coords)
        {
        }

        public override Coord[] GetAvailablePosition(IChessBoard board)
        {
            List<Coord> moves = new List<Coord>();
            int x = Coords.X;
            int y = Coords.Y;

            // Movimiento horizontal, vertical y diagonal
            for (int i = 0; i < 8; i++)
            {
                if (i != x) moves.Add(new Coord(i, y));
                if (i != y) moves.Add(new Coord(x, i));
                if (i > 0)
                {
                    if (x + i < 8 && y + i < 8) moves.Add(new Coord(x + i, y + i));
                    if (x - i >= 0 && y - i >= 0) moves.Add(new Coord(x - i, y - i));
                    if (x + i < 8 && y - i >= 0) moves.Add(new Coord(x + i, y - i));
                    if (x - i >= 0 && y + i < 8) moves.Add(new Coord(x - i, y + i));
                }
            }
            // Filtramos los movimientos que están fuera del tablero o bloqueados por otras piezas
            List<Coord> validMoves = new List<Coord>();
            foreach (var move in moves)
            {
                if (board.IsPositionEmpty(move) || board.HasEnemyPiece(move, Color))
                {
                    validMoves.Add(move);
                }
            }

            //// Filtramos los movimientos que están fuera del tablero o bloqueados por otras piezas
            //moves = moves.Where(m => board.IsPositionEmpty(m) || board.HasEnemyPiece(m, Color)).ToList();

            return validMoves.ToArray();
        }

        public override List<Coord> GetAllAvailablePosition(IChessBoard board)
        {
            return GetAvailablePosition(board).ToList();
        }

        public override FigureType? GetFigureType()
        {
            return FigureType.QUEEN;
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
}
