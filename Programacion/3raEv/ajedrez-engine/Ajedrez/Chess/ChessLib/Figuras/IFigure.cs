using ChessLib.Tablero;

namespace ChessLib.Figuras
{
    public interface IFigure
    {
        FigureColor? GetColor();
        //este es posible que si tenga que hacerlo propiedad para un get/set
        FigureType? GetFigureType();
        //mismo caso
        Coord GetCoord();
        int GetFigureMovements();
        //Coord? GetAvailablePosition(IChessBoard board);
        Coord[] GetAvailablePosition(IChessBoard board);
        //--------------------------------------------
        //esto va aparte de momento
        bool ValidateMove(Coord targetCoord, ChessBoard chessBoard);
        List<Coord> GetAllAvailablePosition(IChessBoard board);
        void IncrementCount();
    }
}

//interface IFigure
//         * {
//    *Coords GetCoord();
//    *ColorType GetColor();
//    *FigureType GetFigureType();
//    *devuelve Coords[] GetAvailablePosition(IChessBoard board);
//    * }
