
using ChessLib.Tablero;

namespace ChessLib.Figuras
{
    public interface IFigure
    {
        FigureType Type { get; }
        FigureColor Color { get; }
    }
}

//interface IFigure
//         * {
//    *Coords GetCoord();
//    *ColorType GetColor();
//    *FigureType GetFigureType();
//    *devuelve Coords[] GetAvailablePosition(IChessBoard board);
//    * }

