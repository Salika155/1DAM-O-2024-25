
using ChessLib.Figuras;

namespace ChessLib.Tablero
{
    public interface IChessBoard : IChessBoardImmutable
    {
        void CreateFigures();
        void Clear();
        bool MoveFigure(int x, int y);
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

