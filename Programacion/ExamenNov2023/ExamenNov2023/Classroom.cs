using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenNov2023
{
    public class Classroom
    {
        private readonly List<Student> _students = new List<Student>();

        private string? _name = "";

        public Classroom()
        {

        }

        public Classroom(List<Student> students)
        {
            if(students != null) 
            {
                for(int i = 0; i <  students.Count; i++) 
                {
                    Student s = students[i];
                    if(s != null) 
                    {
                        _students.Add(s.Clone());
                    }
                }
            }
           
        }

        public string? Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string? GetStudentName() 
        {
            return _name;
        }

        public void SetStudentName(string name) 
        {
            _name = name;
        }

        public int GetStudentCount() 
        {
            return _students.Count;
        }

        public void AddStudent(Student? student) 
        {
            if (student == null)
                return;
            if (!IsValid(student))
                return;
            _students.Add(student);
        }

        public void AddStudent(string studentName)
        {
           Student st = new Student(studentName);

            AddStudent(st);
        }

        public bool IsValid(Student? student)
        {
            return _students != null && _name != null;
        }

        public void RemoveStudentAt(int index) 
        {
            if(index < 0 || index >= _students.Count)
                return;
            _students.RemoveAt(index);
        }

        public void RemoveStudent(Student student)
        {
            RemoveStudentAt(IndexOf(student));
        }

        public int IndexOf(Student student)
        {
            if (student == null)
                return -1;
            return IndexOf(student.GetName());
        }

        public int IndexOf(string? v)
        {
            for(int i = 0; i < _students.Count; i++)
            {
                Student student = _students[i];
                if(student.GetName() == v)
                    return i;
            }
            return -1;
        }

        public void RemoveStudentWithName(string studentName)
        {
            for(int i = 0; i < _students.Count; i++)
            {
                if (_students[i].GetName() == studentName)
                {
                    _students.RemoveAt(i);
                    i--;
                }
            }
        }

        public bool Contains(Student student)
        {
            if (student == null)
                return false;
            return ContainsStudentWithName(student.GetName());
        }

        public bool ContainsStudentWithName(string? studentName) 
        {
            return IndexOf(studentName) >= 0;
        }

        public Student? GetStudentAt(int index)
        {
            if (index < 0 || index >= _students.Count)
                return null;
            return _students[index];
        }
    }
}
