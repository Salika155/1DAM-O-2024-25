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
        public Subject NombreAsignatura;
        //esto es para el otro metodo
        //_marks es una lista de notas de cada cosa y generar una asignatura y meterle las notas.
        public readonly List<double> _listaBoletinNotas = new();
        private readonly List<double> _notesprivates = new();

        public Mark()
        {

        }
        public Mark(Subject subject)
        {
            NombreAsignatura = subject;
        }

        public Mark(double note, Subject name)
        {
            Note = note;
            NombreAsignatura = name;
        }

        //esta funcion si la lista es private tendre que tener un metodo get y set para acceder y
        public void AddMark(double mark)
        {
            if (mark < 0 || mark > 10.0)
                return;
            _listaBoletinNotas.Add(mark);
        }

        public int GetNotesCount()
        {
            return _listaBoletinNotas.Count;
        }

        public double GetNoteAt(int index)
        {
            //comprobar index
            return _listaBoletinNotas[index];
        }

        public void SetNoteAt(int index, double value)
        {
            //comprobar index no se salga de rango, ni value se salga tampoco
            _listaBoletinNotas[index] = value;
        }

        public double GetAverage()
        {
            double result = 0.0;
            for (int i = 0; i < _listaBoletinNotas.Count; i++)
            {
                Mark m = _listaBoletinNotas[i];
                result += m.GetAverage();
            }
            return result / _listaBoletinNotas.Count;
        }

        public double GetAverage(Subject s)
        {
            //comprobacion del count
            Mark? boletin = GetMaxMarks(s);
            if (boletin == null)
                return 0.0;
            return boletin.GetAverage();

        }

        private Mark? GetMaxMarks(Subject s)
        {
            double result = 0.0;
            if (_listaBoletinNotas.Count == 0)
                return result;
            Mark? m = GetMarks(s);
            if (m == null || m._listaBoletinNotas.Count == 0)
                return result;
            //esta sin hacer
            return new Mark();
        }

        private Mark? GetMarks(Subject s)
        {
            int index = IndexOfSubject(s);
            return (index >= 0) ? _listaBoletinNotas[index] : null;
        }

        private int IndexOfSubject(Subject s)
        {
            throw new NotImplementedException();
        }

        //esto esta mal y no tendria que existir pero no encuentro otra manera de que funcione
        public static implicit operator Mark(double v)
        {
            throw new NotImplementedException();
        }

        public double GetAllNotesSumatory()
        {
            //comprobar que el count no sea 0, no se puede dividir por 0
            //recorrer notas y sumar
            double result = 0.0;
            for (int i = 0; i < _listaBoletinNotas.Count; i++)
                result += _listaBoletinNotas[i];
            return result / _listaBoletinNotas.Count;
        }

        internal double GetMax()
        {
            throw new NotImplementedException();
        }
    }
}
