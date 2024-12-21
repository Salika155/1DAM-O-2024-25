using ChessLib.Tablero;

namespace ChessLib.Figuras
{
    public enum FigureColor
    {
        BLACK,
        WHITE
    }

    public enum FigureType
    {
        PAWN,
        TOWER,
        KING,
        QUEEN,
        KNIGHT,
        BISHOP
    }

    public abstract class Figure : IFigure
    {
        private readonly FigureColor _colorFigure;
        private readonly FigureType _typeFigure;
        private readonly Coord _coords;

        public Coord Coords => _coords;
        public Figure(FigureColor color, Coord coords, FigureType? type)
        {
            _colorFigure = color;
            _coords = coords;
        }
        public abstract Coord[] GetAvailablePosition(IChessBoard board);
    }
}

//class Figure : IFigure
//         *
//{
//         *      public abstract Coords[] GetAvailablePosition(IChessBoard board);
//         * 
//         * }