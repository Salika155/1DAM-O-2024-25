using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenNov2023
{
    public class Qualification
    {
        private double _maths;
        private double _science;
        private double _history;
        private double _language;

        public Qualification()
        {

        }
        public Qualification Clone()
        {
            Qualification q = new Qualification();

            q._maths = _maths;
            q._science = _science;
            q._history = _history;
            q._language = _language;
            return q;
        }

        public double GetQualification()
        {
            throw new NotImplementedException();
        }

        public double GetHistory() 
        {
            return _history;
        }

        public double GetLanguage() 
        {
            return _language;
        }

        public double GetMath() 
        {
            return _maths;
        }

        public double GetScience() 
        {
            return _science;
        }

        public void SetMath(double value)
        {
            _maths = value;
        }

        public void SetHistory(double value)
        {
            _history = value;
        }

        public void SetLanguage(double value)
        {
            _language = value;
        }

        public void SetScience(double value)
        {
            _science = value;
        }
    }
}
