namespace ChessLib
{
    public class Class1
    {
        /*
        * Clases:
        * interface IChessBoard
        * {
        *      void InitBoard();
        *      void Clear();
        *      List<> GetList(); -> si quiero hacer una copia de la lista.
        *      bool MoveFigure(int x, y -> x, y);
        *      IFigure? GetFigureAt(x, y); -> mira una lista casilla
        *      int GetWidth();
        *      int GetHeigh();
        *      GetFigureAt(index)
        *      GetFigureCount()
        *      
        * }
        * 
        * Interface IChessBoardImmutable -> solo le paso figuras para tener acceso a consultas de getters
        * {
        *  getters
        * }
        * 
        *  Interface IChessBoard : IChessBoardImmutable
        *  {
        *  resto de metodos que no son get
        *  }
        *  
        * 
        * 
        * interface IFigure
        * {
        *      Coords GetCoord();
        *      ColorType GetColor();
        *      FigureType GetFigureType();
        *      devuelve Coords[] GetAvailablePosition(IChessBoard board);
        * }
        * 
        * class Figure : IFigure
        * {
        *      public abstract Coords[] GetAvailablePosition(IChessBoard board);
        * 
        * }
        * 
        * class Bishop : Figure
        * {
        * public override (le voy a pasar un board)
        * listas
        * }
        * 
        * 
        * struct coords (inmutable)
        * {
        *  x
        *  y
        *  private readonly
        * }
        * 
        * class ChessBoard : IChessBoard
        * {
        *      IChessBoard b = new ChessBoard();
        * }
        * 
        * 
        * */
    }
}
