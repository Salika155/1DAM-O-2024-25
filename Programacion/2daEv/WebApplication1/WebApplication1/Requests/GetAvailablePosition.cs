namespace ChessApp.Requests
{
    public class GetAvailablePosition
    {
        public record Coordinates(
           int x,
           int y);

        public record Request(string playerName, int x, int y)
        {

        }

        public class Response
        {
            public Coordinates[] Coords { get; set; } = [];

        }

        public Coordinates[] Coords { get; set; } = [];
    }
}
