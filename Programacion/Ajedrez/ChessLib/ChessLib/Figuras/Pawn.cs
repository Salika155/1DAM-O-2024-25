using ChessLib.Tablero;

namespace ChessLib.Figuras
{
    public class Pawn : Figure
    {
        public Pawn(FigureColor color, FigureType type, Coord coords) 
            : base(color, FigureType.PAWN, coords)
        {
        }

        //public abstract bool ValidateMove(Coord newCoords);
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

        public void Promote(FigureType newType)
        {
            //    if (newType == FigureType.PAWN || newType == FigureType.KING)
            //    {
            //        throw new InvalidOperationException("Un peón no puede promocionar a peón o rey.");
            //    }
            //    Type = newType;
        }

        public override List<Coord> GetAllAvailablePosition(IChessBoard board)
        {
            List<Coord> moves = new List<Coord>();
            //int direction = GetColor == FigureColor.WHITE ? 1 : -1;

            //// Movimiento hacia adelante
            //Coord forward = new Coord(GetPosition().X, GetPosition().Y + direction);
            //if (board.IsPositionEmpty(forward))
            //    moves.Add(forward);

            //// Capturas diagonales
            //CheckDiagonalCapture(board, direction, -1, moves); // Izquierda
            //CheckDiagonalCapture(board, direction, 1, moves);  // Derecha

            return moves;
        }

        public override Coord[] GetAvailablePositions(IChessBoard board)
        {
            throw new NotImplementedException();
        }

        //private void CheckDiagonalCapture(IChessBoard board, int dirY, int dirX, List<Coord> moves)
        //{
        //    Coord target = new Coord(GetPosition().X + dirX, GetPosition().Y + dirY);
        //    if (board.HasEnemyPiece(target, GetColor))
        //        moves.Add(target);
        //}

        //-----

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
