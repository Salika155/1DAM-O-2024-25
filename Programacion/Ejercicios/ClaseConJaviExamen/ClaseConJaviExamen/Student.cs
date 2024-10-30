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

        public readonly List<Mark> _marks2 = new();
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
            return IndexOfSubject(subject) >= 0;
        }

        public int IndexOfSubject(Subject subject)
        {
            for(int i = 0; i < _marks.Count; i++)
            {
                if (_marks[i].Name == subject)
                {
                    return i;
                }
            }
            return -1;
        }

        //esto iria con marks2 porque seria otro metodo de hacerlo pero no me deja implementarlo, asi que lo pongo con el mark normal
        public Mark? GetMark(Subject subject)
        {
            //si devuelve un -1 vas a querer que devuelva fallo y no un -1;
            int index = IndexOfSubject(subject);

            return (index >= 0) ? _marks[index] : null;

        }

        public void AddMark(Subject subject, double mark)
        {
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
        }

        public void AddMark2(Subject subject, double mark)
        {
            Mark? marks = GetMark(subject);
            if (marks == null)
            {
                marks = new Mark();
                marks.Name = subject;
                _marks.Add(marks);
            }
            _marks.Add(marks);
        }

        //esto iria con el marks2 para generar otra forma de hacerlo
        private Mark? GetMarks(Subject subject)
        {
            int index = IndexOfSubject(subject);
            return (index >= 0) ? _marks[index] : null;
        }

        //funcion que devuelve la media de todas las notas
        public double GetAverage()
        {
            double result = 0.0;
            if (_marks.Count == 0)
                return result;
            for(int i = 0; i < _marks.Count; i++)
            {
                Mark m = _marks[i];
                result += m.Note;
            }
            return result / _marks.Count;
        }

        public double GetAverage(Subject s, double mark)
        {
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
        }

        public double GetMaxMark(Subject s)
        {
            double result = 0.0;
            
            for (int i = 0; i < _marks.Count; i++)
            {
                Mark m = _marks[i];
                if (m.Name == s && m.Note > result)
                   result += m.Note;
            }
            return result / _marks.Count;
        }
    }
}
