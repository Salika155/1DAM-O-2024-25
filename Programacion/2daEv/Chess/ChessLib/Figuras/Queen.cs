
using ChessLib.Tablero;

namespace ChessLib.Figuras
{
    public class Queen : Figure
    {
        public Queen(FigureColor color, FigureType type, Coord coords) : base(color, coords, FigureType.QUEEN)
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
