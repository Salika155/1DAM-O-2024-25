
using ChessLib.Tablero;

namespace ChessLib.Figuras
{
    public class Queen : Figure
    {
        public Queen(FigureColor color, Coord coords, FigureType type) : base(color, coords, FigureType.QUEEN)
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
