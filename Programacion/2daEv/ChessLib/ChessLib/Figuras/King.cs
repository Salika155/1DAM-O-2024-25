
using ChessLib.Tablero;

namespace ChessLib.Figuras
{
    public class King : Figure
    {
        public King(FigureColor color, Coord coords, FigureType type) : base(color, coords, FigureType.KING)
        {
        }

        public override Coord[] GetAvailablePosition(IChessBoard board)
        {
            throw new NotImplementedException();
        }
    }
}
