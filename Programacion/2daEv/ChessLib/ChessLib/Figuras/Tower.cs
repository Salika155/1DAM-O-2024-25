
using ChessLib.Tablero;

namespace ChessLib.Figuras
{
    public class Tower : Figure
    {
        public Tower(FigureColor color, Coord coords, FigureType type) : base(color, coords, FigureType.TOWER)
        {
            
        }

        public override Coord[] GetAvailablePosition(IChessBoard board)
        {
            throw new NotImplementedException();
        }
    }
}
