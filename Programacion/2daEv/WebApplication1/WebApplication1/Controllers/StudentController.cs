using ChessApp;
using Microsoft.AspNetCore.Mvc;

namespace ChessApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //anotacion de arriba dice que clase de abajo sea apicontroller -> recorre las clases buscando anotacion apicontroller

    //studentcontroller es una pool
    public class StudentController : ControllerBase
    {

        private IDatabase _database;

        public StudentController(IDatabase database)
        {
            _database = database;
        }
        
        #region codigoanterior
        //private static readonly Dictionary<long, Student> _studentList = new Dictionary<long, Student>();

        //public static Student? GetStudentFromList(long id)
        //{
        //    Student? result = null;
        //    _studentList.TryGetValue(id, out result);
        //    return result;
        //    //foreach (var student in _studentList)
        //    //    if (student.Id == id)
        //    //        return student;
        //    //return null;
        //}
        #endregion
        [HttpGet]

        //injeccion de dependencias: singleton, me lo das lo uso y me lo cargo, o una pool de algo
        public Student[] Get()
        {
            return _database.GetStudents();
        }

        
        public Student? GetStudent(long id)
        {
            return _database.GetStudentFromList(id) as Student;
        }

        [HttpPost]
        public bool UpdateStudent(long id, [FromBody] Student newStudent)
        {
            //esto para lista antes
            //int index = GetIndexOfStudent(id);
            //_studentList[index] = newStudent;

            //este caso es para el diccionario
            //if (!_studentList.ContainsKey(id))
            //    return false;
            //_studentList[id] = newStudent;

            //var student = GetStudentFromList(id);
            //if (student == null)
            //    return false;
            //if (id != newStudent.Id)
            //    return false;
            //student.Name = newStudent.Name;
            //student.Age = newStudent.Age;
            if (_database.GetStudentFromList(id) == null)
                return false;

            _database.UpdateStudent(id, newStudent);
            return true;

        }

        private int GetIndexOfStudent(long id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public Student AddStudent(/*[FromBody]*/Student student)
        {
            if (student != null)
                //_studentList[student.Id] = student;
                _database.AddStudent(student);
            return student;
        }

        [HttpGet("{id}")]
        public void DeleteStudent(long id)
        {
            //_studentList.Remove(id);
            _database.RemoveStudent(id);
        }

    }
}

//var w1 = new WeatherForecast()
//{
//    Name = "Sofia",
//};
//l.Add(w1);

//var w2 = new WeatherForecast()
//{
//    Name = "Adrian"
//};
//l.Add(w2);

//pool y singleton
//class connection
//public static Connection GetConnection()
//{
//    if (_instance == null)
//        _intance = new Connection(...);
//    return _instance;
//}
////private static Connection
///
//FigureWrapper -> actua intermedio en la clase