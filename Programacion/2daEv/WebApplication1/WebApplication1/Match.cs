namespace ChessApp
{
    public class Match
    {
        public string? Name { get; set; } = string.Empty;
        public string? OwnerId { get; set; } = string.Empty;
        public string? OponentId { get; set; } = string.Empty;
        public string NextPlayerId { get; set; } = string.Empty;
        public string WinnerId { get; set; } = string.Empty;
        public bool IsStarted { get; set; }
        public bool IsCompleted { get; set; }
    }
}
