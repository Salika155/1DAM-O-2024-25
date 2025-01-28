using ChessLib.Tablero;

namespace ChessLib.Figuras
{
    public class Bishop : Figure
    {
        public Bishop(FigureColor color, Coord coords) : base(color, coords, FigureType.BISHOP)
        {
        }

        protected override Figure CreateNewInstance(Coord newCoords)
        {
            return new Bishop(this.Color, newCoords);
        }

        public override Coord[] GetAvailablePosition(IChessBoard board)
        {
            throw new NotImplementedException();
        }

        public override List<Coord> GetAvailablePositions(IChessBoard board)
        {
            throw new NotImplementedException();
        }

        
    }
}

//class Bishop : Figure
//         *
//{
//         * public override (le voy a pasar un board)
//         * listas
//         *
//}
