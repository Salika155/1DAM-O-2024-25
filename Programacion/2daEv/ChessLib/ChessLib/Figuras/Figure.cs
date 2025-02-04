using ChessLib.Tablero;
using System.Drawing;

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
        private Coord _coords;
        private int _movementCount;

        public Figure(FigureColor color, FigureType? type, Coord coords)
        {
            _colorFigure = color;
            _typeFigure = type;
            _coords = coords;
            _movementCount = 0;
        }
        public FigureColor? Color => GetColor();
        public FigureType? Type => GetFigureType();
        public Coord Coords => GetCoord();
        public int MovementCount => GetFigureMovements();


        public FigureColor? GetColor() => _colorFigure;
        public FigureType? GetFigureType() => _typeFigure;
        public Coord GetCoord() => _coords;
        public int GetFigureMovements() => _movementCount;
        

        public void MoveTo(Coord newCoords)
        {
            _coords = newCoords;
            _movementCount++;
        }

        public abstract Coord[] GetAvailablePosition(IChessBoard board);
        public abstract List<Coord> GetAllAvailablePosition(IChessBoard board);
        //tocara cambiarlo y hacerlo propiedad, ya que necesito get y set

        //--------------------------------------

        public bool ValidateMove(Coord targetCoord, ChessBoard chessBoard)
        {
            throw new NotImplementedException();
        }

        //-------------------------------------

        //AQUI
        //public virtual bool IsValidMove(Coord target, IChessBoard board)
        //{
        //    // Comprobar si la coordenada de destino está dentro de los límites del tablero
        //    if (target.X < 0 || target.X >= board.GetWidth() || target.Y < 0 || target.Y >= board.GetHeight())
        //        return false;

        //    // Comprobar si la casilla está ocupada por una figura del mismo color
        //    var targetCell = board.GetFigureAt(target.X, target.Y);
        //    if (targetCell != null && targetCell.GetColor() == this.GetColor())
        //        return false;  // No se puede mover a una casilla ocupada por una pieza del mismo color

        //    // Delega la validación específica a la clase derivada (ejemplo: Bishop, Knight, etc.)
        //    return IsMoveValidForPiece(target, board);
        //}

        //protected abstract bool IsMoveValidForPiece(Coord target, IChessBoard board);
    }
}

//class Figure : IFigure
//         *
//{
//         *      public abstract Coords[] GetAvailablePosition(IChessBoard board);
//         * 
//         * }