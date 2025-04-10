using ChessApp;
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
        Requests.Response[] GetMatches();
        //para mañana
        MatchStatus GetMatchInfo(string matchName);
        //y esta
        Requests.Response CreateMatch(string name, string ownerId);
        //y esta -> me pone como oponente
        void JoinMatch(string newOponentId, string matchName);
        Requests.BattleField GetMatch(string matchName);
        //getavailableposition y mover ficha
        
    }
}
