using ChessApp.Requests;

namespace ChessApp
{
    public class Database : IDatabase
    {
        private class MatchDescription
        {
            public string WhitePlayer1 = string.Empty;
            public string BlackPlayer2 = string.Empty;
            //public IBoard Board;
        }
        private readonly List<Student> _students = new();
        private readonly Dictionary<string, List<MatchDescription>> _matches = new ();
        public void AddUser(string userName)
        {
            if (userName == null)
                throw new ArgumentNullException();
            if (userName.Length == 0)
                throw new ArgumentOutOfRangeException();
            //para threats, para que no pasen a la vez, cuando pase uno y llegue consulta de otro, lo lockea hasta terminar con el primero.
            lock(_matches)
            {
                if (_matches.ContainsKey(userName))
                    return;
                _matches[userName] = new List<MatchDescription>();
            }
            
        }

        public MatchRecord[] GetMatches()
        {
            throw new NotImplementedException();
        }

        public MatchRecord GetMatchInfo(string matchName)
        {
            throw new NotImplementedException();
        }

        public MatchRecord CreateMatch(string name, string password, string ownerId)
        {
            throw new NotImplementedException();
        }

        public void JoinMatch(string newOponentId, string matchName)
        {
            throw new NotImplementedException();
        }

        public MatchRecord[] GetMatch(string matchName)
        {
            throw new NotImplementedException();
        }

        MatchRecord IDatabase.GetMatch(string matchName)
        {
            throw new NotImplementedException();
        }

        //public Database()
        //{

        //}
        //public void AddStudent(Student student)
        //{
        //    _students.Add(student);
        //}

        //public object GetStudentFromList(long id)
        //{
        //    return _students.ToList();
        //}

        //public Student[] GetStudents()
        //{
        //    return _students.ToArray();
        //}

        //public Student? GetStudentWithId(long id)
        //{
        //    throw new NotImplementedException();
        //}

        //public void RemoveStudent(long id)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool UpdateStudent(long id, Student student)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
