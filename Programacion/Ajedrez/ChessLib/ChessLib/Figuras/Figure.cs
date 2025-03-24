using ChessLib.Tablero;

namespace ChessLib.Figuras
{
    public enum FigureColor
    {
        BLACK,
        RED
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
        private FigureType _typeFigure;
        private Coord _coords;
        private int _movementCount;


        public Figure(FigureColor color, FigureType type, Coord coords)
        {
            _colorFigure = color;
            _typeFigure = type;
            _coords = coords;
            _movementCount = 0;
        }

        public FigureColor? Color => _colorFigure;
        public FigureType? Type => _typeFigure;
        public Coord Coords => _coords;
        //coordenadas requiere de un set
        public int MovementCount => _movementCount;

        public FigureColor? GetColor() => _colorFigure;
        public FigureType? GetFigureType() => _typeFigure;
        public Coord GetCoord() => _coords;
        public int GetMovementsCount() => _movementCount;

        public void MoveFigure(Coord newCoords)
        {
            _coords = newCoords;
            _movementCount++;
        }

        // Métodos abstractos
        public abstract Coord[] GetAvailablePositions(IChessBoard board);
        public abstract List<Coord> GetAllAvailablePosition(IChessBoard board);


        //--------------------------------------

        public bool ValidateMove(Coord targetCoord, ChessBoard chessBoard)
        {
            throw new NotImplementedException();
        }



        //FigureColor IFigure.GetColor() => _colorFigure ?? throw new InvalidOperationException();

        //FigureType IFigure.GetFigureType() => _typeFigure ?? throw new InvalidOperationException();
    }
}

//class Figure : IFigure
//         *
//{
//         *      public abstract Coords[] GetAvailablePosition(IChessBoard board);
//         * 
//         * }