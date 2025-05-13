using ChessLib.Tablero;

namespace ChessLib.Figuras
{
    public class Knight : Figure
    {
        public Knight(FigureColor color, FigureType type, Coord coords) : base(color, FigureType.KNIGHT, coords)
        {
        }

        public override List<Coord> GetAllAvailablePosition(IChessBoard board)
        {
            return GetAvailablePosition(board).ToList();
        }

        public override Coord[] GetAvailablePosition(IChessBoard board)
        {
            List<Coord> validMoves = new();
            int[,] movimientos = new int[,]
            {
            { 2, 1 }, { 1, 2 }, { -1, 2 }, { -2, 1 },
            { -2, -1 }, { -1, -2 }, { 1, -2 }, { 2, -1 }
            };

            for (int i = 0; i < movimientos.GetLength(0); i++)
            {
                int newX = Coords.X + movimientos[i, 0];
                int newY = Coords.Y + movimientos[i, 1];
                Coord destino = new(newX, newY);

                if (Utils.IsValidCoordinates(destino.X, destino.Y, board.GetWidth(), board.GetHeight()))
                {
                    var figura = board.GetFigureAt(newX, newY);
                    if (figura == null || figura.GetColor() != Color)
                        validMoves.Add(destino);
                }
            }
            return validMoves.ToArray();
        }

        public override FigureType? GetFigureType()
        {
            return FigureType.KNIGHT;
        }


        //public Coord[] ValidMovesLIst(List<Coord> listMoves, IChessBoard board)
        //{
        //    // Filtramos los movimientos que están fuera del tablero o bloqueados por otras piezas
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
