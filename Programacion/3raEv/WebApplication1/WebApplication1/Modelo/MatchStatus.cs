namespace ChessApp.Modelo
{
    public record MatchStatus(
    
        string? Name,
        string? OwnerId,
        string? OponentId = "",
        string NextPlayerId = "",
        string WinnerId = "",
        bool IsStarted = false,
        bool IsCompleted = false
        );
    
}
