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

            int[] dx = { -1, 0, 1 };
            int[] dy = { -1, 0, 1 };

            foreach (int offsetX in dx)
            {
                foreach (int offsetY in dy)
                {
                    if (offsetX == 0 && offsetY == 0)
                        continue; // Ignora quedarse en el mismo sitio

                    int newX = Coords.X + offsetX;
                    int newY = Coords.Y + offsetY;

                    if (Utils.IsValidCoordinates(newX, newY, board.GetWidth(), board.GetHeight()))
                    {
                        var figura = board.GetFigureAt(newX, newY);
                        if (figura == null || figura.GetColor() != Color)
                        {
                            moves.Add(new Coord(newX, newY));
                        }
                    }
                }
            }

            return moves.ToArray();
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



        //para eliminar figuras cuando atacan otras.
        //list = list.Where(figure => figure.Coords != coords);

        //funcion en utils para sumar movimientos, pasandole figura, y x e y, le sumo o resto en funcion del movimiento
        //asi tengo todos los movimientos juntos en una misma (para la torre, reina y alfil



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

        //para eliminar figuras cuando atacan otras.
        //list = list.Where(figure => figure.Coords != coords);

        //funcion en utils para sumar movimientos, pasandole figura, y x e y, le sumo o resto en funcion del movimiento
        //asi tengo todos los movimientos juntos en una misma (para la torre, reina y alfil



        //        while (Utils.IsValidCoordinates(x, y, board.GetWidth(), board.GetHeight()))
        //{
        //    Coord destino = new(x, y);
        //    var figura = board.GetFigureAt(x, y);

        //    if (figura == null)
        //    {
        //        moves.Add(destino);
        //    }
        //    else
        //    {
        //        if (figura.GetColor() != Color)
        //            moves.Add(destino);
        //        break;
        //    }

        //    x += destino.X;
        //    y += destino.Y;
        //}

        //return moves.ToArray();


        //public override Coord[] GetAvailablePosition(IChessBoard board)
        //{
        //    List<Coord> moves = new List<Coord>();
        //    int x = Coords.X;
        //    int y = Coords.Y;

        //    // Movimiento en todas las direcciones (1 casilla)
        //    for (int i = -1; i <= 1; i++)
        //    {
        //        for (int j = -1; j <= 1; j++)
        //        {
        //            if (i == 0 && j == 0) 
        //                continue;
        //            Coord newPos = new Coord(x + i, y + j);
        //            if (board.IsPositionEmpty(newPos) || board.HasEnemyPiece(newPos, Color))
        //                moves.Add(newPos);
        //        }
        //    }

        //    //tiene que checkear si hay enroque y hacerlo en el caso que si

        //    return ValidMovesLIst(moves, board);
        //}


    }
}
