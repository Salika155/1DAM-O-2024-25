using ChessLib.Tablero;


namespace ChessLib.Figuras
{
    public class Bishop : Figure
    {
        public Bishop(FigureColor color, FigureType type, Coord coords) : base(color, coords, FigureType.BISHOP)
        {
        }

        public override Coord[] GetAvailablePosition(IChessBoard board)
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
