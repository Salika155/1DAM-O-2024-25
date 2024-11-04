using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevoIntentoExamen
{
    public enum Subject
    {
        MATH,
        SCIENCE,
        HISTORY
    }
    public class Mark
    {
        public double Note;
        public Subject NombreAsignatura;
        //_marks es una lista de notas de cada cosa y generar una asignatura y meterle las notas.
        public readonly List<double> _listaBoletinNotas = new();


        public int GetNotesCount()
        {
            return _listaBoletinNotas.Count;
        }

        public double GetNotesAt(int index)
        {
            if (index > 0 && index <= _listaBoletinNotas.Count)
                return _listaBoletinNotas[index];
            return 0;
        }

        public double GetSumatoryAllNotes()
        {
            double result = 0.0;
            for(int i = 0; i < _listaBoletinNotas.Count; i++)
                result += _listaBoletinNotas[i];
            return result;
        }
    }
}
