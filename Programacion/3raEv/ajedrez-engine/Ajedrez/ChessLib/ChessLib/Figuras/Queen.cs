using ChessLib.Tablero;
using System.Drawing;

namespace ChessLib.Figuras
{
    public class Queen : Figure
    {
        private readonly Tower _towerMovement;
        private readonly Bishop _bishopMovement;

        public Queen(FigureColor color, Coord coords) : base(color, FigureType.QUEEN, coords)
        {
            // Creamos instancias "ficticias" solo para reutilizar su lógica de movimiento
            _towerMovement = new Tower(color, coords);
            _bishopMovement = new Bishop(color, coords);
        }

        public override List<Coord> GetAllAvailablePosition(IChessBoard board)
        {
            List<Coord> movim = new List<Coord>();
            var towerMovim = _towerMovement.GetAllAvailablePosition(board);
            var alfilMovim = _bishopMovement.GetAllAvailablePosition(board);

            CombineMoves(movim, towerMovim);
            CombineMoves(movim, alfilMovim);
            return movim;
        }

        private void CombineMoves(List<Coord> target, List<Coord> origenfigura)
        {
            foreach(var movim in origenfigura)
            {
                if (!ContainsCoord(target, movim))
                target.Add(movim);
            }
        }

        private bool ContainsCoord(List<Coord> coords, Coord movim)
        {
            //esto seguramente se pueda cambiar por una llamada a indexof
            foreach (var c in coords)
            {
                if (c.X == movim.X && c.Y == movim.Y)
                    return true;
            }
            return false;
        }

        //public  Coord[] GetAvailablePosition(IChessBoard board)
        //{
        //    throw new NotImplementedException();
        //}

        //public override Coord[] GetAvailablePositions(IChessBoard board)
        //{
        //    throw new NotImplementedException();
        //}

        //public override List<Coord> GetAllAvailablePosition(IChessBoard board)
        //{
        //    throw new NotImplementedException();
        //}

        //public override Coord? GetAvailablePosition(IChessBoard board)
        //{
        //    throw new NotImplementedException();
        //}

        //protected override bool IsMoveValidForPiece(Coord target, IChessBoard board)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
