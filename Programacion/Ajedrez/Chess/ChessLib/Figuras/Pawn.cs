
using ChessLib.Tablero;

namespace ChessLib.Figuras
{
    internal class Pawn : Figure
    {
        public Pawn(FigureColor color, FigureType type, Coord coords) : base(color, coords, FigureType.PAWN)
        {
        }

        public override Coord[] GetAvailablePosition(IChessBoard board)
        {
            throw new NotImplementedException();
        }
    }
}
