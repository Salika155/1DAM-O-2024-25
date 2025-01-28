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
        BASE,
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

        public FigureColor Color => _colorFigure;
        public Coord Coords => _coords;
        public FigureType Type => _typeFigure;

        public Figure(FigureColor color, Coord coords, FigureType type)
        {
            _colorFigure = color;
            _coords = coords;
            _typeFigure = type;
        }
        public abstract List<Coord> GetAvailablePositions(IChessBoard board);

        public Figure Move(Coord newCoords)
        {
            return CreateNewInstance(newCoords);
        }

        protected abstract Figure CreateNewInstance(Coord newCoords);
        public abstract Coord[] GetAvailablePosition(IChessBoard board);
        
    }
}

//class Figure : IFigure
//         *
//{
//         *      public abstract Coords[] GetAvailablePosition(IChessBoard board);
//         * 
//         * }