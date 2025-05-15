
using ChessLib.Figuras;

namespace ChessLib.Tablero
{
    public interface IChessBoard : IChessBoardImmutable
    {
        void CreateFigures();
        void Clear();
        bool MoveFigure(int origenX, int origenY, int destinoX, int destinoY, int figureCount);
        bool IsPositionEmpty(Coord movAdelante);
        bool HasEnemyPiece(Coord target, FigureColor color);

        //Interface IChessBoard : IChessBoardImmutable
        //*  {
        // *  resto de metodos que no son get
        //        void InitBoard();
        // *      void Clear();
        //        bool MoveFigure(int x, y -> x, y);
        // *
    }
}

