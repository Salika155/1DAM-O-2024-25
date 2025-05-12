using ChessLib.Tablero;

namespace ChessLib.Figuras
{
    public class King : Figure
    {
        public King(FigureColor color, FigureType type, Coord coords) : base(color, FigureType.KING, coords)
        {
        }

        public override List<Coord> GetAllAvailablePosition(IChessBoard board)
        {
            return GetAvailablePosition(board).ToList();
        }

        public override Coord[] GetAvailablePosition(IChessBoard board)
        {
            List<Coord> moves = new List<Coord>();
            int x = Coords.X;
            int y = Coords.Y;

            // Movimiento en todas las direcciones (1 casilla)
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0) 
                        continue;
                    Coord newPos = new Coord(x + i, y + j);
                    if (board.IsPositionEmpty(newPos) || board.HasEnemyPiece(newPos, Color))
                        moves.Add(newPos);
                }
            }

            //tiene que checkear si hay enroque y hacerlo en el caso que si

            return ValidMovesLIst(moves, board);
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
            return FigureType.KING;
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
