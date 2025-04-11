namespace ChessApp.Requests
{
    public class GetMatch
    {
        internal class Response
        {
            public Figure[] Figures { get; internal set; }

            //internal class Figure
            //{
            //    private BattleField.FigureType type;
            //    private BattleField.FigureColor color;
            //    private int x;
            //    private int y;

            //    public Figure(BattleField.FigureType type, BattleField.FigureColor color, int x, int y)
            //    {
            //        this.type = type;
            //        this.color = color;
            //        this.x = x;
            //        this.y = y;
            //    }
            //}
            public record Figure(
            BattleField.FigureType FigureType,
            BattleField.FigureColor Color,
            int x,
            int y
            );
        }

        //dentro tiene que tener un request y response
        public record Request(string matchName);

        public record Figure(
            BattleField.FigureType FigureType,
            BattleField.FigureColor Color,
            int x,
            int y
            );
    }
}
