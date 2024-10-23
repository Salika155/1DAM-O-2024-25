using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Examen1raEv2023_24
{

    public enum Signatures

    {
        MATEMATICAS,
        LENGUAJE,
        HISTORIA,
        CIENCIA
    }

    public class Notes
    {
        //List<Student> students = new List<Student>();
        private List<Notes> _n = new List<Notes>();

        private double _maths;
        private double _language;
        private double _history;
        private double _science;


        
        

        public Notes()
        {

        }

        

        public double GetMath()
        {
            return _maths;
        }

        public void SetMath(double value)
        {
            _maths = value;
        }

        public double GetHistory()
        {
            return _history;
        }

        public void SetHistory(double value)
        {
            _history = value;
        }

        public double GetLanguage() 
        {
            return _language;
        }

        public void SetLanguage(double value)
        {
            _language = value;
        }

        public double GetScience()
        {
            return _science;
        }

        public void SetScience(double value)
        {
            _science = value;
        }

        public double GetQualificationForSignature(Signatures signatures)
        {
            if (signatures == Signatures.MATEMATICAS)
                return GetMath();
            if (signatures == Signatures.CIENCIA)
                return GetScience();
            if (signatures == Signatures.LENGUAJE)
                return GetLanguage();
            if (signatures == Signatures.HISTORIA)
                return GetHistory();
            return 0.0;
            //se puede hacer retornando el valor _maths por ejemplo, o el getmath directamente
        }


        public void SetQualificationForSignature(Signatures signature, double value)
        {
            if (signature == Signatures.MATEMATICAS)
                _maths = value;
            if (signature == Signatures.CIENCIA)
                _science = value;
            if (signature == Signatures.LENGUAJE)
                _language = value;
            if (signature == Signatures.HISTORIA)
                _history = value;

        }

        public double GetMajorQualification()
        {
            double result = _maths;

            if (_language >= result) 
                result = _language;
            if (_science >= result)
                result = _science;
            if (_history >= result)
                result = _history;
            if (_maths >= result)
                result = _maths;
            return result;
        }

        public Signatures GetMajorQualificationSignature()
        {
            double major = GetMajorQualification();

            if (_maths == major)
                return Signatures.MATEMATICAS;
            if (_science == major)
                return Signatures.CIENCIA;
            if (_language == major)
                return Signatures.LENGUAJE;
            return Signatures.HISTORIA;

        }

        public double GetMinorQualification()
        {
            double result = _maths;

            if (_language <= result)
                result = _language;
            if (_science <= result)
                result = _science;
            if (_history <= result)
                result = _history;
            if (_maths <= result)
                result = _maths;
            return result;
        }

        public Signatures GetMinorQualificationSignature()
        {
            double minor = GetMinorQualification();

            if (_maths == minor)
                return Signatures.MATEMATICAS;
            if (_science == minor)
                return Signatures.CIENCIA;
            if (_language == minor)
                return Signatures.LENGUAJE;
            return Signatures.HISTORIA;
        }

        public double GetAverage()
        {
            return (_maths + _science + _language + _history) / GetSignatureCount();
        }

        public int GetSignatureCount()
        {
            return 4;
        }

        public Notes Clone()
        {
            Notes result = new Notes();

            result._maths = _maths;
            result._history = _history;
            result._language = _language;
            result._science = _science;

            return result;
        }
    }
}
