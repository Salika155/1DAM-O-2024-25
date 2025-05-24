
using ChessLib.Figuras;

namespace ChessLib.Tablero
{
    public interface IChessBoard : IChessBoardImmutable
    {
        public delegate void VisitFigureDelegate(IFigure figure);
        void CreateFigures();
        void Clear();
        bool MoveFigure(int origenX, int origenY, int destinoX, int destinoY);
        
        bool HasEnemyPiece(Coord target, FigureColor color);
        //estos creo que sobran
        bool IsPositionEmpty(Coord movAdelante);
        bool IsValidPosition(Coord target);
        void VisitFigures(VisitFigureDelegate visitor);

        //Interface IChessBoard : IChessBoardImmutable
        //*  {
        // *  resto de metodos que no son get
        //        void InitBoard();
        // *      void Clear();
        //        bool MoveFigure(int x, y -> x, y);
        // *
    }
}

