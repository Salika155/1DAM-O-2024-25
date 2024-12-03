using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nuevoEx1raRep
{
    public class Notes : Student
    {
        private double _math;
        private double _literature;
        private double _english;
        private double _history;
        private double _science;
        private double _notesCount;


        public Notes() 
        {

        }

        public double Count
        {
            get => _notesCount;
        }

        public double Math
        {
            get => _math;
            set => _math = value;
        }

        public double Literature
        {
            get => _literature;
            set => _literature = value;
        }

        public double English
        {
            get => _english;
            set => _english = value;
        }

        public double History
        {
            get => _history;
            set => _history = value;
        }

        public double Science
        {
            get => _science;
            set => _science = value;
        }

        public Notes Clone()
        {
            Notes notes = new Notes();

            notes.Math = _math;
            notes.Literature = _literature;
            notes.English = _english;
            notes.History = _history;
            notes.Science = _science;

            return notes;
        }

        public void SetQualificationForSignature()
        {
            
        }


    }
}
