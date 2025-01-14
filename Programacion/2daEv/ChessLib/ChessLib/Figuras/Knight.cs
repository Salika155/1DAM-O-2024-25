
using ChessLib.Tablero;

namespace ChessLib.Figuras
{
    public class Knight : Figure
    {
        public Knight(FigureColor color, Coord coords, FigureType type) : base(color, coords, FigureType.KNIGHT)
        {
        }

        public override List<Coord> GetAllAvailablePosition(IChessBoard board)
        {
            throw new NotImplementedException();
        }

        public override Coord? GetAvailablePosition(IChessBoard board)
        {
            throw new NotImplementedException();
        }

        protected override bool IsMoveValidForPiece(Coord target, IChessBoard board)
        {
            throw new NotImplementedException();
        }
    }
}
