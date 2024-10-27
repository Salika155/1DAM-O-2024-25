namespace ExamenNov2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> list = new List<Student>();
            Student s = new Student();
            list.Add(s);
            list[0].SetName("Juan");

            Classroom cl = new Classroom(list);
            Student? s1 = cl.GetStudentAt(0);

            s1?.SetName("Ana");
        }
    }
}
