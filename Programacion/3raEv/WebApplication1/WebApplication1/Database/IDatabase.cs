
namespace ChessApp
{
    public interface IDatabase
    {
        //void AddStudent(Student student);
        //void RemoveStudent(long id);
        //Student? GetStudentWithId(long id);
        //bool UpdateStudent(long id, Student student);
        //Student[] GetStudents();
        //object GetStudentFromList(long id);

        void AddUser(string userName);
        //hacer esta
        Modelo.MatchStatus[] GetMatches();
        //para mañana
        Modelo.MatchStatus GetMatchInfo(string matchName);
        //y esta
        Modelo.MatchStatus CreateMatch(string name, string ownerId);
        //y esta -> me pone como oponente
        void JoinMatch(string newOponentId, string matchName);
        Modelo.BattleField GetMatch(string matchName);
        //getavailableposition y mover ficha
        Modelo.AllAvailablePos GetAvailablePosition(string matchName, int fromX, int fromY);
        void Move(string matchName, int fromX, int fromY, int toX, int toY);
        
    }
}
