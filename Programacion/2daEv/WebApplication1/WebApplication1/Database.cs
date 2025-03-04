namespace ChessApp
{
    public class Database : IDatabase
    {
        private readonly List<Student> _students = new();

        //public Database()
        //{

        //}
        public void AddStudent(Student student)
        {
            _students.Add(student);
        }

        public object GetStudentFromList(long id)
        {
            return _students.ToList();
        }

        public Student[] GetStudents()
        {
            return _students.ToArray();
        }

        public Student? GetStudentWithId(long id)
        {
            throw new NotImplementedException();
        }

        public void RemoveStudent(long id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateStudent(long id, Student student)
        {
            throw new NotImplementedException();
        }
    }
}
