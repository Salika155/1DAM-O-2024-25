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
        int GetMovementsCount();
        //Coord? GetAvailablePosition(IChessBoard board);
        void MoveFigure(Coord targetCoord);
        Coord[] GetAvailablePositions(IChessBoard board);
        //----------------------------------------------------
        List<Coord> GetAllAvailablePosition(IChessBoard board);
        bool ValidateMove(Coord targetCoord, ChessBoard chessBoard);
    }
}

//interface IFigure
//         * {
//    *Coords GetCoord();
//    *ColorType GetColor();
//    *FigureType GetFigureType();
//    *devuelve Coords[] GetAvailablePosition(IChessBoard board);
//    * }
