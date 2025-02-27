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
    }
}
