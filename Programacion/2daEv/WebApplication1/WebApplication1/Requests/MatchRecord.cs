using ChessLib.Figuras;

namespace ChessApp.Requests
{
    public record MatchRecord(
        string? Name,
        string? OwnerId,
        string? OponentId,
        string NextPlayerId,
        string WinnerId,
        bool IsStarted,
        bool IsCompleted
        );

    public class Match
    {
        public string? Name { get; set; } = string.Empty;
        public string? OwnerId { get; set; } = string.Empty;
        public string? OponentId { get; set; } = string.Empty;
        public string NextPlayerId { get; set; } = string.Empty;
        public string WinnerId { get; set; } = string.Empty;
        public bool IsStarted { get; set; }
        public bool IsCompleted { get; set; }
        #region codigo
        //public class BattleField
        //{
        //    #region comentado
        //    //public enum FigureColor
        //    //{
        //    //    BLACK,
        //    //    RED,
        //    //}

        //    //public enum FigureType
        //    //{
        //    //    PAWN,
        //    //    KNIGHT,
        //    //    BISHOP,
        //    //    KING,
        //    //    TOWER,
        //    //    QUEEN
        //    //}
        //    #endregion
        //    public record Figure(
        //        int x,
        //        int y,
        //        FigureColor Color,
        //        FigureType Type
        //        );
        //    public Figure[] Figures { get; set; } = [];
        //}

        //public class AvailablePosition
        //{
        //    public record Coordinates(
        //       int x,
        //       int y);

        //    public record Request(int x, int y)
        //    {

        //    }

        //    public class Response
        //    {

        //    }

        //    public Coordinates[] Coords { get; set; } = [];
        //}
        #endregion
    }
}
