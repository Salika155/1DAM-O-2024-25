
using ChessLib.Tablero;

namespace ChessLib.Figuras
{
    internal class Pawn : Figure
    {
        public Pawn(FigureColor color, Coord coords, FigureType type) : base(color, coords, FigureType.PAWN)
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
