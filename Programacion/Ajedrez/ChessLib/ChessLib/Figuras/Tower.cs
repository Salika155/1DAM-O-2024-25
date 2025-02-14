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
            throw new NotImplementedException();
        }

        public Coord[] GetAvailablePosition(IChessBoard board)
        {
            throw new NotImplementedException();
        }

        public override Coord[] GetAvailablePositions(IChessBoard board)
        {
            throw new NotImplementedException();
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
