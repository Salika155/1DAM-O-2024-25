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

        
    }
}
