using ChessApp;
using Microsoft.AspNetCore.Mvc;

namespace ChessApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //anotacion de arriba dice que clase de abajo sea apicontroller -> recorre las clases buscando anotacion apicontroller
    public class StudentController : ControllerBase
    {
        private static readonly List<Student> _studentList = new List<Student>();
        [HttpGet]
        public List<Student> Get()
        {
            return _studentList;
        }

        public void AddStudent(Student student)
        {
            if (student != null)
            _studentList.Add(student);
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