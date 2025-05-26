
using ChessLib.Figuras;

namespace ChessLib.Tablero
{
    
    public interface IChessBoard : IChessBoardImmutable
    {
        public delegate void FigureVisitor(IFigure? figure);
        public delegate void CasillaVisitor(Casilla? casilla);
        public delegate void CoordVisitor(Coord? coord);

        public delegate bool FigureFilter(IFigure? figure);
        public delegate bool CasillaFilter(Casilla? casilla);
        public delegate bool CoordFilter(Coord? coord);
        void CreateFigures();
        void Clear();
        bool MoveFigure(int origenX, int origenY, int destinoX, int destinoY);
        
        bool HasEnemyPiece(Coord target, FigureColor color);
        //estos creo que sobran
        bool IsPositionEmpty(Coord movAdelante);
        bool IsValidPosition(Coord target);
        void VisitFigures(FigureVisitor visitor);
        void VisitCoords(CoordVisitor visitor);
        void VisitCasillas(CasillaVisitor visitor);
        List<IFigure> FilterFigures(FigureFilter filter);
        List<Casilla> FilterCasillas(CasillaFilter filter);
        List<Coord> FilterCoords(CoordFilter filter);


        //Interface IChessBoard : IChessBoardImmutable
        //*  {
        // *  resto de metodos que no son get
        //        void InitBoard();
        // *      void Clear();
        //        bool MoveFigure(int x, y -> x, y);
        // *
    }
}

