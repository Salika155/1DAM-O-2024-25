using ChessLib.Tablero;

namespace ChessLib.Figuras
{
    public class Queen : Figure
    {
        public Queen(FigureColor color, FigureType type, Coord coords) : base(color, FigureType.QUEEN, coords)
        {
        }

        public override Coord[] GetAvailablePosition(IChessBoard board)
        {
            List<Coord> moves = new();

            // Movimiento como torre
            Utils.AgregarMovimientosLineales(this, board, moves, 1, 0);   // Derecha
            Utils.AgregarMovimientosLineales(this, board, moves, -1, 0);  // Izquierda
            Utils.AgregarMovimientosLineales(this, board, moves, 0, 1);   // Abajo
            Utils.AgregarMovimientosLineales(this, board, moves, 0, -1);  // Arriba

            // Movimiento como alfil
            Utils.AgregarMovimientosLineales(this, board, moves, 1, 1);    // Abajo derecha
            Utils.AgregarMovimientosLineales(this, board, moves, -1, -1);  // Arriba izquierda
            Utils.AgregarMovimientosLineales(this, board, moves, 1, -1);   // Arriba derecha
            Utils.AgregarMovimientosLineales(this, board, moves, -1, 1);   // Abajo izquierda

            return moves.ToArray();
        }

        public override List<Coord> GetAllAvailablePosition(IChessBoard board)
        {
            return GetAvailablePosition(board).ToList();
        }

        public override FigureType? GetFigureType()
        {
            return FigureType.QUEEN;
        }

        //private void AgregarMovimientosLineales(IChessBoard board, List<Coord> moves, int dx, int dy)
        //{
        //    int x = Coords.X + dx;
        //    int y = Coords.Y + dy;

        //    while (Utils.IsValidCoordinates(x, y, board.GetWidth(), board.GetHeight()))
        //    {
        //        Coord destino = new(x, y);
        //        var figura = board.GetFigureAt(x, y);

        //        if (figura == null)
        //        {
        //            moves.Add(destino);
        //        }
        //        else
        //        {
        //            if (figura.GetColor() != Color)
        //                moves.Add(destino);
        //            break;
        //        }

        //        x += dx;
        //        y += dy;
        //    }
        //}

        //public Coord[] ValidMovesLIst(List<Coord> listMoves, IChessBoard board)
        //{
        //    Filtramos los movimientos que están fuera del tablero o bloqueados por otras piezas
        //    List<Coord> validMoves = new List<Coord>();
        //    foreach (var move in listMoves)
        //    {
        //        if (board.IsPositionEmpty(move) || board.HasEnemyPiece(move, Color))
        //        {
        //            validMoves.Add(move);
        //        }
        //    }

        //    return validMoves.ToArray();
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
