namespace ChessApp.Requests
{
    public class MoveFigure
    {
        public record Request(string PlayerName, int SourceX, int SourceY, int DestinationX, int DestinationY);

        public record Response(bool succeded);
    }
}
