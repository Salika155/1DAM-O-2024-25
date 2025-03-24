namespace ChessApp.Requests
{
    public record MatchRecord(
        string? Name,
        string? OwnerId,
        string NextPlayerId,
        string WinnerId,
        bool IsStarted,
        bool IsCompleted
        );

    public class Match
    {
        public string? Name { get; set; } = string.Empty;
        public string? OwnerId { get; set; } = string.Empty;
        public string NextPlayerId { get; set; } = string.Empty;
        public string WinnerId { get; set; } = string.Empty;
        public bool IsStarted { get; set; } 
        public bool IsCompleted { get; set; }

    }
}
