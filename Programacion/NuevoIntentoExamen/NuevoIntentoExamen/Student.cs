using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NuevoIntentoExamen
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
        private readonly List<Mark> _marks = new();

        public string? GetName() => _name;
        public int GetAge() => _age;
        public long GetNia() => _nia;
        public Gender GetGender() => _gender;

        public double GetAverage()
        {
            int notesCount = 0;
            double result = 0.0;

            for(int i = 0; i < _marks.Count; i++)
            {
                Mark boletin = _marks[i];
                notesCount += boletin.GetNotesCount();
                result += boletin.GetSumatoryAllNotes();
            }
            if (notesCount == 0)
                return 0.0;
        
            return result / notesCount;
        }

        public Mark GetMark(Subject subject)
        {
            int index = IndexOfSubject(subject);
            return (index >= 0) ? _marks[index] : null;
        }

        private int IndexOfSubject(Subject subject)
        {
            for(int i = 0; i < _marks.Count;i++) 
            {
                if (_marks[i].NombreAsignatura == subject) return i;
                return i;
            }
            return -1;
        }

        public void AddMark(Subject subject, double mark)
        {
            Mark? m = GetMark(subject);
            if (m == null)
            {
                m = new Mark();
                m.NombreAsignatura = subject;
                _marks.Add(m);
            }
            else
                _marks.Add(m);
        }

        private Mark? GetMarks(Subject subject)
        {
            int index = IndexOfSubject(subject);
            return (index >= 0) ? _marks[index] : null;
        }

        public double GetMaxMark(Subject subject)
        {
            Mark? bolletin = GetMark(subject);
            if (bolletin == null)
                return 0.0;
            return bolletin.GetMax();
        }

        public bool ContainsSubject(Subject subject)
        {
            return IndexOfSubject(subject) >= 0;
        }
    }
}
