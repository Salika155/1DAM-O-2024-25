namespace ChessApp.Requests
{
    public class GetMatchStatus
    {
        public record Request(string matchName);

        public class Response
        {
            public string? Name { get; set; } = string.Empty;
            public string? OwnerId { get; set; } = string.Empty;
            public string? OponentId { get; set; } = string.Empty;
            public string NextPlayerId { get; set; } = string.Empty;
            public string WinnerId { get; set; } = string.Empty;
            public bool IsStarted { get; set; } = false;
            public bool IsCompleted { get; set; } = false;
            public static readonly MatchStatus Empty = new MatchStatus();

        }
    }
}
