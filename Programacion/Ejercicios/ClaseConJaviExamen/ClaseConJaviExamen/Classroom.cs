using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseConJaviExamen
{
    public class Classroom
    {
        private readonly List<Student> _studentList = new();

        //a las listas internas no se les da acceso nunca, y si se hace se justifica
        //public List<Student> GetList()
        //{
        //    return _studentList;
        //}
        public int GetStudentCount()
        {
            return _studentList.Count;
        }

        public Student? GetStudentAt(int index) //si quito la ? pongo throw new exception
        {
            if (index < 0 || index >= _studentList.Count)
                return null;
            return _studentList[index];
        }

        public void Add(Student st)
        {

        }

        public void RemoveStudentAt(int index)
        {

        }

        public void RemoveStudentWithName(string name)
        {

        }

        public int IndexOfStudentWithName(string name)
        {

            return -1;
        }

        public bool ContainsStudentWithName(string name)
        {
            return false;
        }

        //bug aqui si la lista esta vacia, es importante
        public Student? GetBestStudent()
        {
            int n = GetStudentCount();
            if (n == 0)
                return null;
            Student? result = GetStudentAt(0);
            for(int i = 1; i < n; i++)
            {
                Student? s = GetStudentAt(i);
                if (s!.GetAverage() > result!.GetAverage())
                    result = s;
            }
            return result;
        }
        //posible pregunta sobre fibonacci en examen
    }
}
