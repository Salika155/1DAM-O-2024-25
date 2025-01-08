

using ChessLib.Figuras;

namespace ChessLib.Tablero
{
    public interface IChessBoardImmutable
    {
        IFigure? GetFigureAt(int? x, int? y);
        int GetWidth();
        int GetHeight();
        IFigure? GetFigureAt(int? index);
        int GetFigureCount();
    }
}

//Interface IChessBoardImmutable -> solo le paso figuras para tener acceso a consultas de getters
//         * {
//         *  getters
//         * }
// *      List<> GetList(); -> si quiero hacer una copia de la lista.
// *      IFigure? GetFigureAt(x, y); -> mira una lista casilla
// *      int GetWidth();
// *      int GetHeigh();
// *      GetFigureAt(index)
// *      GetFigureCount()

