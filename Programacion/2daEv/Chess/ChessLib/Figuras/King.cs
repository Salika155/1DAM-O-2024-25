
using ChessLib.Tablero;

namespace ChessLib.Figuras
{
    public class King : Figure
    {
        public King(FigureColor color, FigureType type, Coord coords) : base(color, coords, type)
        {
        }

        public override Coord[] GetAvailablePosition(IChessBoard board)
        {
            throw new NotImplementedException();
        }

        public override List<Coord> GetAvailablePositions(IChessBoard board)
        {
            throw new NotImplementedException();
        }

        protected override Figure CreateNewInstance(Coord newCoords)
        {
            throw new NotImplementedException();
        }
    }
}