using ChessLib.Tablero;

namespace ChessLib.Figuras
{
    public interface IFigure
    {
        Coord GetCoord();
        FigureColor GetColor();
        FigureType GetFigureType();
        int GetFigureMovements();
        Coord? GetAvailablePosition(IChessBoard board);
        List<Coord> GetAllAvailablePosition(IChessBoard board); 
    }
}

//interface IFigure
//         * {
//    *Coords GetCoord();
//    *ColorType GetColor();
//    *FigureType GetFigureType();
//    *devuelve Coords[] GetAvailablePosition(IChessBoard board);
//    * }
