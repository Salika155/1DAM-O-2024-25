using ChessLib.Tablero;
using System.Drawing;

namespace ChessLib.Figuras
{
    public class Tower : Figure
    {
        public Tower(FigureColor color, Coord coords) : base(color, FigureType.TOWER, coords)
        {
            
        }

        public override List<Coord> GetAllAvailablePosition(IChessBoard board)
        {
            List<Coord> movim = new List<Coord>();

            int[][] direccionMov =
            { new[] { 0, 1 }, new[] { 1, 0 }, new[] { 0, -1 }, new[] { -1, 0 } };

            foreach (var direccion in direccionMov)
            {
                int newX = Coords.X + direccion[0];
                int newY = Coords.Y + direccion[1];

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
