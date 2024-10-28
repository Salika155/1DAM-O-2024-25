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
        //tipo de datos : sbyte -> 0 - 255; numero con signo = desde -128 hasta 127, tambien estan ushort, uint, ulong
        //half, float, double, quad (tarjetas graficas)

        //en un examen no hay constructor salvo que se diga que necesita un constructor
        //si un objeto tiene que ser inmutable solo tiene que tener getters, tienes que hacer un constructor dentro pasandole el _nia

        //si dice que alguna propiedad no se puede modificar es porque no quiere setters

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

        public void AddMark(Subject subject, double mark)
        {

        }
        //funcion que devuelve la media de todas las notas
        public double GetAverage()
        {
            return 0.0;
        }

        public double GetAverage(Subject s, double mark)
        {
            return 0.0;
        }
    }
}
