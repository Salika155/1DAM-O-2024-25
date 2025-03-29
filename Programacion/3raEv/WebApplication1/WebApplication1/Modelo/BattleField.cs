using static ChessApp.Database;

namespace ChessApp.Modelo
{
    public class BattleField
    {
        public string Name { get; set; }
        public string OponentId { get; set; }

        public BattleField(MatchDescription match)
        {
            Name = match.Name;
            OponentId = match.OponentId;
        }
    }
}
