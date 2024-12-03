using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseConJaviExamen
{
    public class Marks2
    {
        public enum Subject
        {
            MATH,
            SCIENCE,

        }
        public class Mark
        {
            private readonly List<double> _notesprivates = new();
            public readonly Subject Name;
            //esto es para el otro metodo
            //_marks es una lista de notas de cada cosa y generar una asignatura y meterle las notas.
            public readonly List<double> _marks = new();

            public Mark(Subject subject)
            {
                Name = subject;
            }

            public void Add(double mark)
            {

            }
        }
    }
}
