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

        public string? GetName()
        {
            return _name;
        }

        internal int GetAverage()
        {
            throw new NotImplementedException();
        }
    }
}
