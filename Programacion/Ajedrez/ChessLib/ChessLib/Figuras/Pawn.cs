using ChessLib.Tablero;

namespace ChessLib.Figuras
{
    public class Pawn : Figure
    {
        public Pawn(FigureColor color, Coord coords) 
            : base(color, FigureType.PAWN, coords)
        {
        }

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
            int direction = (Color == FigureColor.RED) ? 1 : -1;

            //// Movimiento hacia adelante
            //Coord forward = new Coord(GetPosition().X, GetPosition().Y + direction);
            //if (board.IsPositionEmpty(forward))
            //    moves.Add(forward);
            MovimientoHaciaDelante(board, moves, direction);
            CapturaDiagonal(board, moves, direction);

            return moves;
        
        }

        public void CapturaDiagonal(IChessBoard board, List<Coord> moves, int direction)
        {
            int[] desplazamientoDiagonal = { -1, 1 };

            foreach (var desplazam in desplazamientoDiagonal)
            {
                ValidaMovYAdd(board, moves, Coords.X + desplazam, Coords.Y + direction);
            }
        }

        public void MovimientoHaciaDelante(IChessBoard board, List<Coord> movim, int direccion)
        {
            ValidaMovYAdd(board, movim, Coords.X, Coords.Y + direccion);

            if (MovementCount == 0)
            {
                ValidaMovYAdd(board, movim, Coords.X, Coords.Y + 2 * direccion);
            }
        }

        public void ValidaMovYAdd(IChessBoard board, List<Coord> moves, int newX, int newY)
        {
            if (new Coord(newX, newY).EstaDentroDeLimitesTablero() &&
                board.CanFigureBeMoved(board, Coords.X, Coords.Y, newX, newY))
            {
                moves.Add(new Coord(newX, newY));
            }
        }

    }
}
