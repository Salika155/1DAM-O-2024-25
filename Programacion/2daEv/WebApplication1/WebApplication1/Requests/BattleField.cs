using ChessLib.Figuras;

namespace ChessApp.Requests
{
    public class BattleField
    {
        #region comentado
        public enum FigureColor
        {
            BLACK,
            RED,
        }

        public enum FigureType
        {
            PAWN,
            KNIGHT,
            BISHOP,
            KING,
            TOWER,
            QUEEN
        }
        #endregion
        public record Figure(
            FigureType Type,
            FigureColor Color,
            int X,
            int Y
            )
        {
            //public Figure(int x, int y, FigureColor color, FigureType type)
            //{
            //    x = this.x;
            //    y = this.y;
            //    Color = color;
            //    Type = type;
            //}
            //public Figure(int x, int y, FigureColor color, FigureType type)
            //{
            //    X = x;
            //    Y = y;
            //    Color = color;
            //    Type = type;
            //}
            //public Figure()
            //{
            //}
        }
        public BattleField()
        {
           

        }

        public Figure[] Figures { get; set; } = [];
        public MatchStatus Status = MatchStatus.Empty;
    }

}
