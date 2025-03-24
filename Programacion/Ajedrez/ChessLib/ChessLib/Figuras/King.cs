using ChessLib.Tablero;

namespace ChessLib.Figuras
{
    public class King : Figure
    {
        public King(FigureColor color, Coord coords) : base(color, FigureType.KING, coords)
        {
        }

        public override List<Coord> GetAllAvailablePosition(IChessBoard board)
        {
            List<Coord> movim = new List<Coord>();
            int[][] direcciones =
            {
                new[] { 0, 1 }, new[] { 1, 1 }, new[] { 1, 0 }, new[] { 1, -1 },
                new[] { 0, -1 }, new[] { -1, -1 }, new[] { -1, 0 }, new[] { -1, 1 }
            };

            foreach (var direcct in direcciones)
            {
                int newX = Coords.X + direcct[0];
                int newY = Coords.Y + direcct[1];

                if (new Coord(newX, newY).EstaDentroDeLimitesTablero() &&
                board.CanFigureBeMoved(board, Coords.X, Coords.Y, newX, newY))
                {
                    movim.Add(new Coord(newX, newY));
                }
            }

            return movim;
        }

        //public Coord[] GetAvailablePosition(IChessBoard board)
        //{
        //    throw new NotImplementedException();
        //}

        //public override Coord[] GetAvailablePositions(IChessBoard board)
        //{
        //    throw new NotImplementedException();
        //}

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
