using ChessApp.Requests;
using System.Drawing;
using System.Xml.Linq;

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
        //hacer esta
        public Response[] GetMatches()
        {

            List<Response> result = new();
            lock(_matches)
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

        //public Response GetMatchInfo(string matchName)
        //{
        //    throw new NotImplementedException();
        //}

        //y esta
        public Response CreateMatch(string name, string ownerId)
        {
            List<MatchDescription> matches;
            MatchDescription match;
            lock(_matches)
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
        //public creatematch.Response GetMatch()

        
        public BattleField GetMatch(string matchName)
        {
            BattleField result = new BattleField();
            result.Status = GetMatchInfo(matchName);
                { 
            //result.Status = new MatchStatus()
            //{
            //    Name = matchName,
            //    OwnerId = "test",
            //    OponentId = "nacho",
            //    NextPlayerId = "test",
            //    WinnerId = "",
            //    IsStarted = true,
            //    IsCompleted = false
            };
            List<BattleField.Figure> figures = new();
            figures.Add(new BattleField.Figure(
               BattleField.FigureType.PAWN,
               BattleField.FigureColor.BLACK,
               0,
               0
               ));
            figures.Add(new BattleField.Figure(
               BattleField.FigureType.TOWER,
               BattleField.FigureColor.RED,
               1,
               1
               ));


            result.Figures = figures.ToArray();
            return result;
        }

        public MatchStatus GetMatchInfo(string matchName)
        {
            //comprobar
            MatchStatus result = new();
            {
                result.Name = matchName;
                result.OwnerId = "test";
                result.OponentId = "nacho";
                result.NextPlayerId = "test";
                result.WinnerId = "";
                result.IsStarted = true;
                result.IsCompleted = false;
            };
            return result;
        }

        public List<GetAvailablePosition> GetAvailablePositions(string playerName, int x, int y)
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
