
using ChessLib.Tablero;

namespace ChessLib.Figuras
{
    public class Bishop : Figure
    {
        public Bishop(FigureColor color, Coord coords, FigureType type) : base(color, coords, FigureType.BISHOP)
        {

        }

        public override List<Coord> GetAllAvailablePosition(IChessBoard board)
        {
            var position = new List<Coord>();

            int[] movX = { 1, 1, -1, -1 };
            int[] movY = { 1, 1, -1, -1 };

            for (int i = 0; i < movX.Length; i++)
            {
                int x = Coords.X;
                int y = Coords.Y;

                while (true)
                {
                    x += movX[i];
                    y += movY[i];

                    if (x < 0 || x >= board.GetWidth() || y < 0 || y >= board.GetHeight())
                        break;

                    var targetCell = board.GetFigureAt(x, y);

                    if (targetCell != null)
                    {
                        if (targetCell.GetColor() != Color)
                            position.Add(new Coord(x, y));
                        break;   
                    }
                    position.Add(new Coord(x, y));
                }
            }
            return position;
        }

        public override Coord? GetAvailablePosition(IChessBoard board)
        {
            var positions = GetAllAvailablePosition(board);

            if (positions.Count == 0)
                return null;

            // Ejemplo: devolver la primera posición válida
            return positions[0];
        }

        protected override bool IsMoveValidForPiece(Coord target, IChessBoard board)
        {
            //esto esta mal
            while ((target.X > 0 && target.X <= 7) && (target.Y > 0 && target.Y <= 7))
                return true;
            return false;
        }
    }
}

//class Bishop : Figure
//         *
//{
//         * public override (le voy a pasar un board)
//         * listas
//         *
//}