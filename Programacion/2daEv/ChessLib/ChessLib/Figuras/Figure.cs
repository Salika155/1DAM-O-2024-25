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
        private FigureColor? _colorFigure;
        private FigureType? _typeFigure;
        private Coord _coords;
        private int _movementCount;

        public Coord Coords
        {
            get => GetCoord();
            set
            {
                _coords = value;
            }
        }
        public FigureColor Color => GetColor();
        public FigureType Type => GetFigureType();
        public Figure(FigureColor color, Coord coords, FigureType? type)
        {
            _colorFigure = color;
            _coords = coords;
            _typeFigure = type;
            _movementCount = 0;
        }

        public int GetFigureMovements() => _movementCount;
        public void SumMovements() => _movementCount++;

        public Coord GetCoord() => Coords;
        public FigureColor GetColor() => Color;
        public FigureType GetFigureType() => Type;

        public abstract Coord? GetAvailablePosition(IChessBoard board);
        
        public abstract List<Coord> GetAllAvailablePosition(IChessBoard board);

        public virtual bool IsValidMove(Coord target, IChessBoard board)
        {
            // Comprobar si la coordenada de destino está dentro de los límites del tablero
            if (target.X < 0 || target.X >= board.GetWidth() || target.Y < 0 || target.Y >= board.GetHeight())
                return false;

            // Comprobar si la casilla está ocupada por una figura del mismo color
            var targetCell = board.GetFigureAt(target.X, target.Y);
            if (targetCell != null && targetCell.GetColor() == this.GetColor())
                return false;  // No se puede mover a una casilla ocupada por una pieza del mismo color

            // Delega la validación específica a la clase derivada (ejemplo: Bishop, Knight, etc.)
            return IsMoveValidForPiece(target, board);
        }

        protected abstract bool IsMoveValidForPiece(Coord target, IChessBoard board);

        
    }
}

//class Figure : IFigure
//         *
//{
//         *      public abstract Coords[] GetAvailablePosition(IChessBoard board);
//         * 
//         * }