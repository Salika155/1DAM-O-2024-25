namespace ChessApp.Requests
{
    public class AvailablePosition
    {
        public record Coordinates(
           int x,
           int y);

        public record Request(int x, int y)
        {

        }

        public class Response
        {

        }

        public Coordinates[] Coords { get; set; } = [];
    }
}
