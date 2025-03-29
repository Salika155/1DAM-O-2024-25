using ChessApp.Modelo;

namespace ChessApp

{
    public class DatabaseUtils
    {
        internal static bool ExistMatch(List<Database.MatchDescription> matches, string name)
        {
            foreach (var match in matches)
                if (match.Name == name)
                    return true;
                return false;
            
        }

        internal static bool ExistMatch(Dictionary<string, List<Database.MatchDescription>> matches, string name)
        {
            foreach(var entry in matches)
                if (ExistMatch(entry.Value, name))
                    return true;
            return false;
        }

        internal static Requests.Response ToMatchResponse(Database.MatchDescription match, string ownerId)
        {
            Requests.Response newMatch = new Requests.Response(
                match.Name,
                ownerId,
                match.OponentId
                );
            return newMatch;
        }

        internal static MatchStatus ToMatchStatus(Database.MatchDescription match, string ownerId)
        {
            throw new NotImplementedException();
        }
    }
}
