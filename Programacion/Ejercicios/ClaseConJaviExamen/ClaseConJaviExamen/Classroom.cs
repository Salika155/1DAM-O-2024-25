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

        public void Add(Student? st)
        {
            if (st == null)
                return;
            _studentList.Add(st);
        }

        public void RemoveStudentAt(int index)
        {
            if (0 <= index && index > _studentList.Count)
                _studentList.RemoveAt(index);

        }

        public void RemoveStudentWithName(string name)
        {
            int index = IndexOfStudentWithName(name);
            if (index >= 0)
                _studentList.RemoveAt(index);
            //esta es la buena
            //RemoveStudentAt(IndexOfStudentWithName(name));
        }

        public void RemoveStudentsWithName(string name)
        {
            if (name == null)
                return;

            for(int i = _studentList.Count; i >= 0; i--)
            {
                if (_studentList[i].GetName() == name)
                    _studentList.RemoveAt(i);
            }

            //otra manera pero peor
            //while (true)
            //{
            //    int index = IndexOfStudentWithName(name);
            //    if (index < 0)
            //        break;
            //    _studentList.RemoveAt(index);
            //}
        }

        public int IndexOfStudentWithName(string name)
        {
            //int result = -1;
            if (name == null)
                return -1;
            for (int i = 0; i < _studentList.Count; i++)
            {
                if (_studentList[i].GetName() == name)
                    //result = i -> esto es por si quiero recorrerlo para encontrar el ultimo
                    return i;
            }
            return -1;
        }

        public List<Student> GetAllStudentsWithName(string name)
        {
            List<Student> result = new();
            for (int i = 0; i < _studentList.Count; i++)
            {
                Student s = _studentList[i];
                if (s.GetName() == name)
                    //result = i -> esto es por si quiero recorrerlo para encontrar el ultimo
                    result.Add(s);
            }
            return result;

        }


        public bool ContainsStudentWithName(string name)
        {
            return IndexOfStudentWithName(name) >= 0;
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
       

        public Student? GetStudent(string name)
        {
            int index = IndexOfStudentWithName(name);
            return _studentList[index];
        }

        //public Marks2? GetMark(Subject subject)
        //{
        //    //si devuelve un -1 vas a querer que devuelva fallo y no un -1;
        //    int index = IndexOfSubject(subject);

        //    return (index >= 0) ? _marks[index] : null;

        //}

        public Student? GetStudentWithName(string name)
        {
            int index = IndexOfStudentWithName(name);
            return (index < 0) ? null : _studentList[index];
        }

        int a = 0;
        //int a = (z == 7)? 1 : (cosa > 0)? 2 : 3

        //posible pregunta sobre fibonacci en examen
    }


}
