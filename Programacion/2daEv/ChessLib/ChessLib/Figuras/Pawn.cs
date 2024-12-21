
using ChessLib.Tablero;

namespace ChessLib.Figuras
{
    internal class Pawn : Figure
    {
        public Pawn(FigureColor color, Coord coords, FigureType type) : base(color, coords, FigureType.PAWN)
        {
        }

        public override Coord[] GetAvailablePosition(IChessBoard board)
        {
            throw new NotImplementedException();
        }
    }
}
