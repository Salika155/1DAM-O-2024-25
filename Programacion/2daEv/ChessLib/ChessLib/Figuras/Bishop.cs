using ChessLib.Tablero;

namespace ChessLib.Figuras
{
    public class Bishop : Figure
    {
        public Bishop(FigureColor color, FigureType type, Coord coords) : base(color, FigureType.BISHOP, coords)
        {

        }

        public override List<Coord> GetAllAvailablePosition(IChessBoard board)
        {
            throw new NotImplementedException();
        }

        //public override List<Coord> GetAllAvailablePosition(IChessBoard board)
        //{
        //    var position = new List<Coord>();

        //    int[] movX = { 1, 1, -1, -1 };
        //    int[] movY = { 1, 1, -1, -1 };

        //    for (int i = 0; i < movX.Length; i++)
        //    {
        //        int x = Coords.X;
        //        int y = Coords.Y;

        //        while (true)
        //        {
        //            x += movX[i];
        //            y += movY[i];

        //            if (x < 0 || x >= board.GetWidth() || y < 0 || y >= board.GetHeight())
        //                break;

        //            var targetCell = board.GetFigureAt(x, y);

        //            if (targetCell != null)
        //            {
        //                if (targetCell.GetColor() != Color)
        //                    position.Add(new Coord(x, y));
        //                break;
        //            }
        //            position.Add(new Coord(x, y));
        //        }
        //    }
        //    return position;
        //}

        //public override Coord? GetAvailablePosition(IChessBoard board)
        //{
        //    var positions = GetAllAvailablePosition(board);

        //    if (positions.Count == 0)
        //        return null;

        //    // Ejemplo: devolver la primera posición válida
        //    return positions[0];
        //}
    }
}

        //protected override bool IsMoveValidForPiece(Coord target, IChessBoard board)
        //{
        //    var availablePositions = GetAllAvailablePosition(board);
        //    foreach (var pos in availablePositions)
        //    {
        //        if (pos.X == target.X && pos.Y == target.Y)
        //            return true;
        //    }
        //    return false;
        //}

//        protected override bool IsMoveValidForPiece(Coord target, IChessBoard board)
//{
//    // Movimiento diagonal
//    int deltaX = Math.Abs(target.X - Coords.X);
//    int deltaY = Math.Abs(target.Y - Coords.Y);

//    if (deltaX != deltaY)
//        return false; // No es un movimiento diagonal

//    return PathIsClear(target, board);
//}

//private bool PathIsClear(Coord target, IChessBoard board)
//{
//    int stepX = target.X > Coords.X ? 1 : -1;
//    int stepY = target.Y > Coords.Y ? 1 : -1;

//    int x = Coords.X + stepX;
//    int y = Coords.Y + stepY;

//    while (x != target.X && y != target.Y)
//    {
//        if (board.GetFigureAt(x, y) != null)
//            return false; // Hay una figura bloqueando el camino

//        x += stepX;
//        y += stepY;
//    }

//    return true;

//    }
//}

//class Bishop : Figure
//         *
//{
//         * public override (le voy a pasar un board)
//         * listas
//         *
//}