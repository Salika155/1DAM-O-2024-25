using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevoIntentoExamen
{
    public class Classroom
    {
        private readonly List<Student> _studenList = new List<Student>();

        public Classroom() 
        {
        }

        public int GetStudentCount()
        {
            return _studenList.Count;
        }

        public Student? GetStudent(int index)
        {
            if (index < 0 || index <= _studenList.Count)
                return null;
            return _studenList[index];

        }
        public void AddStudent(Student? student)
        {
            if (student == null)
                return;
            _studenList.Add(student);
        }

        public void RemoveStudentAt(int index)
        {
            if (0 <= index && index > _studenList.Count)
                return;
            _studenList.RemoveAt(index);
        }

        public void RemoveStudentWithName(string name)
        {
            RemoveStudentAt(IndexOfStudentWithName(name));
        }

        private int IndexOfStudentWithName(string name)
        {
            if (name == null)
                return -1;
            for(int i = 0; i < _studenList.Count; i++)
            {
                if (_studenList[i].GetName() == name)
                    return i;
            }
            return -1;
        }

        public bool ContainsStudentWithName(string name)
        {
            return IndexOfStudentWithName(name) >= 0;
        }

        //hasta aqui lo basico

        public List<Student> GetAllStudentsWithName(string name)
        {
            List<Student> _studentWithNameList = new();

            for(int i = 0; i < _studenList.Count; i++)
            {
                Student s = _studenList[i];
                if(s.GetName() == name)
                {
                    _studentWithNameList.Add(s);
                }
            }
            return _studentWithNameList;
        }

        public Student? GetBestStudent()
        {
            int n = GetStudentCount();
            if (n == 0)
                return null;
            Student? result = GetStudent(0);
            for(int i = 0; i < n; i++)
            {
                Student? s = GetStudent(i);
                if (s!.GetAverage() > result!.GetAverage())
                    result = s;
            }
            return result;
        }

        public Student? GetStudent(string name)
        {
            int index = IndexOfStudentWithName(name);
            return _studenList[index];
        }

        public Student? GetStudentWithName(string name)
        {
            int index = IndexOfStudentWithName(name);
            return (index < 0) ? null : _studenList[index];
        }


    }
}
