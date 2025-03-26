using ChessLib.Figuras;

namespace ChessApp.Requests
{
    public class BattleField
    {
        #region comentado
        //public enum FigureColor
        //{
        //    BLACK,
        //    RED,
        //}

        //public enum FigureType
        //{
        //    PAWN,
        //    KNIGHT,
        //    BISHOP,
        //    KING,
        //    TOWER,
        //    QUEEN
        //}
        #endregion
        public record Figure(
            int x,
            int y
            //FigureColor Color,
            //FigureType Type
            );
        public Figure[] Figures { get; set; } = [];
    }

}
