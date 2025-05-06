using ChessLib.Tablero;

namespace ChessLib.Figuras
{
    public class Knight : Figure
    {
        public Knight(FigureColor color, Coord coords) : base(color, FigureType.KNIGHT, coords)
        {
        }

        public override List<Coord> GetAllAvailablePosition(IChessBoard board)
        {
            var posiblesMovs = new List<Coord>();

            int[][] direccionMovimientos =
            {
                new[] { 2, 1 }, new[] { 2, -1 }, new[] { -2, 1 }, new[] { -2, -1 },
                new[] { 1, 2 }, new[] { 1, -2 }, new[] { -1, 2 }, new[] { -1, -2 }
            };

            foreach (var direccion in direccionMovimientos)
            {
                int newX = Coords.X + direccion[0];
                int newY = Coords.Y + direccion[1];
                if (new Coord(newX, newY).EstaDentroDeLimitesTablero() &&
                board.CanFigureBeMoved(board, Coords.X, Coords.Y, newX, newY))
                {
                    posiblesMovs.Add(new Coord(newX, newY));
                }
            }
            return posiblesMovs;
        }

        #region codigoviejo
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
        #endregion
    }
}
