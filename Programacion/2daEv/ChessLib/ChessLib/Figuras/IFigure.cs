
using ChessLib.Tablero;

namespace ChessLib.Figuras
{
    public interface IFigure
    {
        Coord GetCoord();
        FigureColor GetColor();
        FigureType GetFigureType();
        Coord[] GetAvailablePosition(IChessBoard board);
        int GetFigureMovements();
    }
}

//interface IFigure
//         * {
//    *Coords GetCoord();
//    *ColorType GetColor();
//    *FigureType GetFigureType();
//    *devuelve Coords[] GetAvailablePosition(IChessBoard board);
//    * }
