using ChessLib.Tablero;

namespace ChessLib.Figuras
{
    public class Pawn : Figure
    {
        public Pawn(FigureColor color, FigureType type, Coord coords) 
            : base(color, FigureType.PAWN, coords)
        {
        }

        public override Coord[] GetAvailablePosition(IChessBoard board)
        {
            List<Coord> moves = new List<Coord>();
            int direction = Color == FigureColor.WHITE ? 1 : -1;

            Coord movAdelante = new Coord(Coords.X, Coords.Y + direction);
            if (board.IsPositionEmpty(movAdelante))
                moves.Add(movAdelante);

            CheckDiagonalCapture(board, direction, -1, moves); // Izquierda
            CheckDiagonalCapture(board, direction, 1, moves);  // Derecha
            return moves.ToArray();
        }

        private void CheckDiagonalCapture(IChessBoard board, int directionY, int directionX, List<Coord> moves)
        {
            Coord target = new Coord(Coords.X + directionX, Coords.Y + directionY);
            if (board.HasEnemyPiece(target, Color))
                moves.Add(target);
        }

        public virtual bool ValidateMove(Coord newCoords)
        {
            return true;
        }

        public Coord[] ValidMovesLIst(List<Coord> listMoves, IChessBoard board)
        {
            // Filtramos los movimientos que están fuera del tablero o bloqueados por otras piezas
            List<Coord> validMoves = new List<Coord>();
            foreach (var move in listMoves)
            {
                if (board.IsPositionEmpty(move) || board.HasEnemyPiece(move, Color))
                {
                    validMoves.Add(move);
                }
            }

            return validMoves.ToArray();
        }

        public override FigureType? GetFigureType()
        {
            return FigureType.PAWN;
        }

        //public override bool ValidateMove(Coord newCoords)
        //{
        //    int direction = (Color == FigureColor.WHITE) ? 1 : -1;
        //    if (newCoords.X == Coords.X && newCoords.Y == Coords.Y + direction)
        //    {
        //        return true;
        //    }
        //    // Captura en diagonal.
        //    if (Math.Abs(newCoords.X - Coords.X) == 1 && newCoords.Y == Coords.Y + direction)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        public void Promote(FigureType newType, FigureType? type)
        {
            if (newType == FigureType.PAWN || newType == FigureType.KING)
            {
                throw new InvalidOperationException("Un peón no puede promocionar a peón o rey.");
            }

            type = newType;
        }

        public override List<Coord> GetAllAvailablePosition(IChessBoard board)
        {
            throw new NotImplementedException();
        }

        

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
