using ChessLib.Tablero;

namespace ChessLib.Figuras
{
    public interface IFigure
    {
        //puedo hacer get; como en properties ya que solo son gets
        FigureColor? GetColor();
        //este es posible que si tenga que hacerlo propiedad para un get/set
        FigureType? GetFigureType();
        //mismo caso
        Coord GetCoord();
        int GetFigureMovements();
        //Coord? GetAvailablePosition(IChessBoard board);
        Coord[] GetAvailablePosition(IChessBoard board);

        //puedo hacer un metodo por si quiero saber el otro color GetColorOpuesto
        //--------------------------------------------
        //esto va aparte de momento
        bool ValidateMove(Coord targetCoord, ChessBoard chessBoard);
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
