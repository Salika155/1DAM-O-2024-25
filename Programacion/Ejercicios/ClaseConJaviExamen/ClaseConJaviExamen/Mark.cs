using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseConJaviExamen
{
    public enum Subject
    {
        MATH,
        SCIENCE,

    }
    public class Mark
    {
        public double Note;
        public Subject Name;
        //esto es para el otro metodo
        //_marks es una lista de notas de cada cosa y generar una asignatura y meterle las notas.
        public readonly List<double> _marks = new();

        public Mark()
        {

        }

        public Mark(double note, Subject name)
        {
            Note = note;
            Name = name;
        }

        internal void AddMark(double mark)
        {
            throw new NotImplementedException();
        }
    }
}
