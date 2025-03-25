//using ChessApp.Requests;
namespace ChessApp
{
    public interface IDatabase
    {
        void AddStudent(Student student);
        void RemoveStudent(long id);
        Student? GetStudentWithId(long id);
        bool UpdateStudent(long id, Student student);
        Student[] GetStudents();
        object GetStudentFromList(long id);

        void AddUser(string userName);
        Requests.MatchRecord[] GetMatches();
        Requests.MatchRecord GetMatchInfo(string matchName);
        Requests.MatchRecord CreateMatch(string name, string password, string ownerId);
        void JoinMatch(string newOponentId, string matchName);
        GetMatch(string matchName);
        
    }
}
