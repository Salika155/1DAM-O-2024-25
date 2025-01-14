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
        private readonly FigureColor? _colorFigure;
        private readonly FigureType? _typeFigure;
        private readonly Coord _coords;
        private int _movementCount;

        public Coord Coords => _coords;
        public Figure(FigureColor color, Coord coords, FigureType? type)
        {
            _colorFigure = color;
            _coords = coords;
            _typeFigure = type;
            _movementCount = 0;
        }
        public abstract Coord[] GetAvailablePosition(IChessBoard board);

        public Coord GetCoord()
        {
            return _coords;
        }

        public FigureColor GetColor()
        {
            throw new NotImplementedException();
        }

        public FigureType GetFigureType()
        {
            throw new NotImplementedException();
        }

        public int GetFigureMovements()
        {
            throw new NotImplementedException();
        }
    }
}

//class Figure : IFigure
//         *
//{
//         *      public abstract Coords[] GetAvailablePosition(IChessBoard board);
//         * 
//         * }