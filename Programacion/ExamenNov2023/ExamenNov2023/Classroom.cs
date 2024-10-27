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

        private string? _classroomName = "";

        public Classroom()
        {

        }

        public Classroom(string classroomName)
        {
            _classroomName = classroomName;
        }

        public Classroom(List<Student> students)
        {
            #region ocultar
            if (students != null) 
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
            #endregion
            if (students != null)
            {
                for (int i = 0; i < _students.Count; i++)
                {
                    Student s = new Student();
                    if (s != null)
                    {
                        _students.Add(s);
                    }
                }
            }
            
        }

        public string? Name
        {
            get { return _classroomName; }
            set { _classroomName = value; }
        }

        public string? GetStudentName() 
        {
            return _classroomName;
        }

        public void SetStudentName(string name) 
        {
            _classroomName = name;
        }

        public int GetStudentCount() 
        {
            return _students.Count;
        }

        public void AddStudent(Student? student) 
        {
            #region ocultar
            if (student == null)
                return;
            if (!IsValid(student))
                return;
            _students.Add(student);
            #endregion
            if (student != null)
                _students.Add(student);
            return;

        }

        public void AddStudent(string studentName)
        {
            #region ocultar
            Student st = new Student(studentName);

            AddStudent(st);
            #endregion
            Student s = new Student(studentName);
                AddStudent(st);
        }

        public bool IsValid(Student? student)
        {
            return _students != null && _classroomName != null;
        }

        public void RemoveStudentAt(int index) 
        {
            #region ocultar
            //if(index < 0 || index >= _students.Count)
            //    return;
            //_students.RemoveAt(index);
            #endregion
            if(index < 0 || index >= _students.Count)
                return;
            _students.RemoveAt(index);
        }

        public void RemoveStudent(Student student)
        {
            #region ocultar
            //RemoveStudentAt(IndexOf(student));
            #endregion
            RemoveStudentAt(IndexOf(student));
        }

        public int IndexOf(Student student)
        {
            #region ocultar
            if (student == null)
                return -1;
            return IndexOf(student.GetName());
            #endregion
            
        }

        public int IndexOf(string? name)
        {
            #region ocultar
            //for (int i = 0; i < _students.Count; i++)
            //{
            //    Student student = _students[i];
            //    if(student.GetName() == name)
            //        return i;
            //}
            //return -1;
            #endregion
            for(int i = 0; i < _students.Count; i++)
            {
                Student s = _students[i];
                if (s.GetName() == name)
                    return i;
            }
            return -1;

        }

        public int IndexOfStudentWithName(string? name)
        {
            #region ocultar
            //for (int i = 0; i < _students.Count; i++)
            //{
            //    if (_students[i].GetName() == name)
            //        return i;
            //}
            //return -1;
            #endregion
            for(int i = 0; i < _students.Count; i++)
            {
                if (_students[i].GetName() == name)
                    return i;
            }
            return -1;

        }

        public void RemoveStudentWithName(string studentName)
        {
            #region ocultar
            for (int i = 0; i < _students.Count; i++)
            {
                if (_students[i].GetName() == studentName)
                {
                    _students.RemoveAt(i);
                    i--;
                }
            }
            #endregion
            for(int i = 0; i <  _students.Count; i++)
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
            #region ocultar
            //if (student == null)
            //    return false;
            //return ContainsStudentWithName(student.GetName());
            #endregion
            if (student == null)
                return false;
            return ContainsStudentWithName(student.GetName());
        }

        public bool ContainsStudentWithName(string? studentName) 
        {
            #region ocultar
            //return IndexOf(studentName) >= 0;
            #endregion
            return IndexOfStudentWithName(studentName) >= 0;
        }

        public Student? GetStudentAt(int index)
        {
            #region ocultar
            //if (index < 0 || index >= _students.Count)
            //    return null;
            //return _students[index];
            #endregion
            if (index < 0 || index >= _students.Count)
                return null;
            return _students[index];
        }
    }
}
