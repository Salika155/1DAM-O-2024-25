using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1raEv2023_24
{
    public class Classroom
    {
        private List<Student> _students = new List<Student>();
        private string? _nameClassroom = "";

        public Classroom()
        {

        }

        public Classroom(string nameClassroom)
        {
            _nameClassroom = nameClassroom;
        }

        //esto es, para evitar que pasen un null de estudiante y se añada a la clase, comprobamos que no sea
        //null, y recorriendo la lista lo añadimos a la posicion, en este caso 0.

        public Classroom(List<Student> students)
        {
            if (students != null)
            {
                for (int i = 0; i < students.Count; i++)
                {
                    Student s = students[i];
                    if (s != null)
                    {
                        _students.Add(s.Clone());
                        //en este caso al pasarle al Add el s.Clone esta mejor que pasarle solo s
                        //porque haria una copia en profundidad del student
                    }
                }
            }
        }

        //para que classroom sea un wrapped de la lista classroom, hay que acceder y recorrerla
        public Student? GetStudentAt(int index)
        {
            if (index < 0 || index >= _students.Count)
                return null;
            return _students[index];
        }

        public int GetStudentCount()
        {
            //if (_students == null)
            //    return 0;
            //esto no seria necesario al ser private, si fuese protected si seria correcto
            return _students.Count;
        }

        public void AddStuden(Student student)
        {
            //en este caso si pueden pasar un null
            if (student == null)
                return;
            _students.Add(student);
        }

        public void RemoveStudentAt(int index)
        {
            if (index < 0 || index >= _students.Count)
                return;
            _students.RemoveAt(index);
        }

        //Consejo: cuanto tengamos ContainStudents no hacerlo, es mejor hacer un IndexOf, y aprovechar esta
        //funcion para hacer el Contain para obtener la posicion tambien.
        #region funcion ContainStudentWithName comentado
        //public bool ContainStudentWithName(string name)
        //{
        //    for (int i = 0; i < _students.Count; i++)
        //    {
        //        if (_students[i].GetName() == name)
        //            return true;
        //    }
        //    return false;
        //}
        #endregion

        public int IndexOfStudentWithName(string name)
        {
            for (int i = 0; i < _students.Count; i++)
            {
                if (_students[i].GetName() == name)
                    return i;
            }
            return -1;
        }

        public bool ContainStudentWithName(string name)
        {
            return IndexOfStudentWithName(name) >= 0;
        }

        public void RemoveStudentsWithName(string name)
        {
            if (_students == null)
                return;

            for (int i = 0; i < _students.Count; i++)
            {
                if (_students[i].GetName() == name)
                {
                    _students.RemoveAt(i);
                    i--;
                }   
            }
        }

        public string? GetNameClassroom()
        {
            return _nameClassroom;
        }

        public void SetNameClassroom(string name)
        {
            _nameClassroom = name;
        }

    }
}
