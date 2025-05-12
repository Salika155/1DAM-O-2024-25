using ChessLib.Tablero;

namespace ChessLib.Figuras
{
    public class Knight : Figure
    {
        public Knight(FigureColor color, FigureType type, Coord coords) : base(color, FigureType.KNIGHT, coords)
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

            // Movimientos en L
            int[] dx = { 2, 1, -1, -2, -2, -1, 1, 2 };
            int[] dy = { 1, 2, 2, 1, -1, -2, -2, -1 };

            for (int i = 0; i < 8; i++)
            {
                Coord newPos = new Coord(x + dx[i], y + dy[i]);
                if (board.IsPositionEmpty(newPos) || board.HasEnemyPiece(newPos, Color))
                    moves.Add(newPos);
            }

            return moves.ToArray();
        }

        public override FigureType? GetFigureType()
        {
            return FigureType.KNIGHT;
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
