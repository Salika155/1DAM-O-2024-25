
namespace ChessLib.Tablero
{
    public interface IChessBoard : IChessBoardImmutable
    {
        void InitBoard();
        void Clear();
        bool MoveSelectedFigure(int x, int y);

        //Interface IChessBoard : IChessBoardImmutable
        //*  {
        // *  resto de metodos que no son get
        //        void InitBoard();
        // *      void Clear();
        //        bool MoveFigure(int x, y -> x, y);
        // *
    }
}

