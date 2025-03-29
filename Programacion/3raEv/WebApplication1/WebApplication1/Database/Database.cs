using ChessApp.Modelo;
using ChessApp.Requests;

namespace ChessApp
{
    public class Database : IDatabase
    {
        public class MatchDescription
        {
            public string Name = string.Empty;
            public string OponentId = string.Empty;
            //public string WhitePlayer1 = string.Empty;
            //public string BlackPlayer2 = string.Empty;
            //public IBoard Board;
        }
        //private readonly List<Student> _students = new();
        private readonly Dictionary<string, List<MatchDescription>> _matches = new();
        public void AddUser(string userName)
        {
            if (userName == null)
                throw new ArgumentNullException();
            if (userName.Length == 0)
                throw new ArgumentOutOfRangeException();
            //para threats, para que no pasen a la vez, cuando pase uno y llegue consulta de otro, lo lockea hasta terminar con el primero.
            lock (_matches)
            {
                if (_matches.ContainsKey(userName))
                    return;
                _matches[userName] = new List<MatchDescription>();
            }

        }
        //hacer esta
        public Response[] GetMatches()
        {

            List<Response> result = new();
            lock (_matches)
            {
                foreach (var entry in _matches)
                {
                    string ownerId = entry.Key;
                    foreach (var match in entry.Value)
                    {
                        result.Add(DatabaseUtils.ToMatchResponse(match, ownerId));

                    }
                }
            }
            return result.ToArray();
        }

        public Response GetMatchInfo(string matchName)
        {
            throw new NotImplementedException();
        }

        //y esta
        public Response CreateMatch(string name, string ownerId)
        {
            List<MatchDescription> matches;
            MatchDescription match;
            lock (_matches)
            {
                if (!_matches.TryGetValue(ownerId, out matches))
                    throw new ArgumentException(ownerId);
                if (DatabaseUtils.ExistMatch(_matches, name))
                    throw new Exception($"Match {name} already exists");
                match = new MatchDescription()
                {
                    Name = name,
                };
                matches.Add(match);
            }

            return DatabaseUtils.ToMatchResponse(match, ownerId);
        }

        public void JoinMatch(string newOponentId, string matchName)
        {
            throw new NotImplementedException();
        }

        //public Response[] GetMatch(string matchName)
        //{
        //    throw new NotImplementedException();
        //}

        public Modelo.BattleField GetMatch(string matchName)
        {
            lock (_matches)
            {
                foreach (var entry in _matches)
                {
                    foreach (var match in entry.Value)
                    {
                        if (match.Name == matchName)
                        {
                            return new Modelo.BattleField(match); // Convertimos a BattleField
                        }
                    }
                }
            }
            throw new Exception($"Match {matchName} not found");
        }



        MatchStatus IDatabase.GetMatchInfo(string matchName)
        {
            throw new NotImplementedException();
        }

        MatchStatus IDatabase.CreateMatch(string name, string ownerId)
        {
            List<MatchDescription> matches;
            MatchDescription match;
            lock (_matches)
            {
                if (!_matches.TryGetValue(ownerId, out matches))
                    throw new ArgumentException(ownerId);
                if (DatabaseUtils.ExistMatch(_matches, name))
                    throw new Exception($"Match {name} already exists");

                match = new MatchDescription()
                {
                    Name = name,
                };
                matches.Add(match);
            }

            return DatabaseUtils.ToMatchStatus(match, ownerId); // Convertimos a MatchStatus
        }

        MatchStatus[] IDatabase.GetMatches()
        {
            List<MatchStatus> result = new();
            lock (_matches)
            {
                foreach (var entry in _matches)
                {
                    string ownerId = entry.Key;
                    foreach (var match in entry.Value)
                    {
                        result.Add(DatabaseUtils.ToMatchStatus(match, ownerId)); // Convertimos a MatchStatus
                    }
                }
            }
            return result.ToArray();
        }

        public AllAvailablePos GetAvailablePosition(string matchName, int fromX, int fromY)
        {
            throw new NotImplementedException();
        }

        public void Move(string matchName, int fromX, int fromY, int toX, int toY)
        {
            throw new NotImplementedException();
        }

        #region codigostudentcontroller
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
        #endregion
    }
}
