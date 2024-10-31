using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseConJaviExamen
{
    public enum Gender
    {
        MALE,
        FEMALE,
        OTHER
    }
    public class Student
    {
        private string? _name = string.Empty;
        private int _age;
        private long _nia;
        private Gender _gender;
        //primera opcion
        private readonly List<Mark> _marks = new();
        //tipo de datos : sbyte -> 0 - 255; numero con signo = desde -128 hasta 127, tambien estan ushort, uint, ulong
        //half, float, double, quad (tarjetas graficas)

        //en un examen no hay constructor salvo que se diga que necesita un constructor
        //si un objeto tiene que ser inmutable solo tiene que tener getters, tienes que hacer un constructor dentro pasandole el _nia

        //si dice que alguna propiedad no se puede modificar es porque no quiere setters

        public readonly List<Marks2> _marks2 = new();
        public string? GetName()
        {
            return _name;
        }

        public void SetName(string value)
        {
            _name = value;
        }

        public int GetAge()
        {
            return _age;
        }

        public void SetAge(int value)
        {
            _age = value;
        }

        public long GetNia()
        {
            return _nia;
        }

        //funciones relacionada con marks2
        public bool ContainsSubject(Subject subject)
        {
            #region oculto
            return IndexOfSubject(subject) >= 0;
            #endregion
            return IndexOfSubject(subject) >= 0;
        }

        public int IndexOfSubject(Subject subject)
        {
            #region oculto
            for (int i = 0; i < _marks.Count; i++)
            {
                if (_marks[i].Name == subject)
                {
                    return i;
                }
            }
            return -1;
            #endregion
            for (int i = 0; i < _marks.Count; i++)
                if (_marks[i].Name == subject)
                    return i;
            return -1;
        }

        //esto iria con marks2 porque seria otro metodo de hacerlo pero no me deja implementarlo, asi que lo pongo con el mark normal
        public Mark? GetMark(Subject subject)
        {
            #region oculto
            //si devuelve un -1 vas a querer que devuelva fallo y no un -1;
            int index = IndexOfSubject(subject);

            return (index >= 0) ? _marks[index] : null;
            #endregion
            int index1 = IndexOfSubject(subject);
            return (index1 >= 0)? _marks[index1] : null;
        }

        public void AddMark(Subject subject, double mark)
        {
            #region oculto
            int index = IndexOfSubject(subject);
            if(index >= 0)
            {
                _marks[index].AddMark(mark);
            }
            else
            {
                Mark s = new();
                s.Name = subject;
                s.AddMark(mark);
                _marks.Add(s);
            }
            #endregion
            int index1 = IndexOfSubject(subject);
            if (index1 >= 0)
                _marks[index1].AddMark(mark);
            else
            {
                Mark m = new();
                m.Name = subject;
                m.AddMark(mark);
                _marks.Add(m);
            }    
        }

        public void AddMark2(Subject subject/*, double mark*/)
        {
            #region oculto
            Mark? marks = GetMark(subject);
            if (marks == null)
            {
                marks = new Mark();
                marks.Name = subject;
                _marks.Add(marks);
            }
            _marks.Add(marks);
            #endregion
        }

        //esto iria con el marks2 para generar otra forma de hacerlo
        private Mark? GetMarks(Subject subject)
        {
            #region oculto
            int index = IndexOfSubject(subject);
            return (index >= 0) ? _marks[index] : null;
            #endregion
        }

        //funcion que devuelve la media de todas las notas
        public double GetAverage()
        {
            #region oculto
            double result = 0.0;
            if (_marks.Count == 0)
                return result;
            for(int i = 0; i < _marks.Count; i++)
            {
                Mark m = _marks[i];
                result += m.Note;
            }
            return result / _marks.Count;
            #endregion
        }

        public double GetAverage(Subject s, double mark)
        {
            #region oculto
            double result = 0.0;
            int notesCount = 0;
            
            for (int i = 0; i < _marks.Count; i++)
            {
                Mark m = _marks[i];
                if(m.Name == s)
                {
                    result += m.Note;
                    notesCount++;
                }
            }
            if (notesCount == 0)
                return 0.0;
            return result / _marks.Count;
            #endregion
        }

        public double GetMaxMark(Subject s)
        {
            #region oculto
            double result = 0.0;
            
            for (int i = 0; i < _marks.Count; i++)
            {
                Mark m = _marks[i];
                if (m.Name == s && m.Note > result)
                   result += m.Note;
            }
            return result / _marks.Count;
            #endregion
        }
    }
}
