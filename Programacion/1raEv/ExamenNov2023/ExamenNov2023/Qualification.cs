using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenNov2023
{
    public enum SignatureType
    {
        MATH,
        SCIENCE,
        HISTORY,
        LANGUAGE,
        COUNT
    }

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

        //public double GetQualification()
        //{
        //    throw new NotImplementedException();
        //}

        public double GetQualificationForSignature(SignatureType type)
        {
            if(type == SignatureType.MATH)
                return _maths;
            if (type == SignatureType.SCIENCE)
                return _science;
            if (type == SignatureType.HISTORY)
                return _history;
            if (type == SignatureType.LANGUAGE)
                return _language;
            return 0.0;
        }

        public void SetQualificationForSignature(SignatureType type, double value) 
        {
            if (type == SignatureType.MATH)
                _maths = value;
            if (type == SignatureType.SCIENCE)
                _science = value;
            if (type == SignatureType.HISTORY)
                _history = value;
            if (type == SignatureType.LANGUAGE)
                _language = value;
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

        public double GetAverageNotes()
        {
            return (_maths + _science + _history + _language) / GetSignatureCount();
        }

        public int GetSignatureCount()
        {
            return 4;
            //return SignatureType.COUNT;
        }

        public double GetMajorQualification()
        {
            double result = _maths;

            if (_language >= result)
                result = _language;
            if (_history >= result)
                result = _history;
            if (_science >= result) 
                result = _science;
            return result;
        }

        public double GetMinorQualification()
        {
            double result = _maths;

            if (_language < result)
                result = _language;
            if (_history < result)
                result = _history;
            if (_science < result)
                result = _science;
            return result;
        }

        public SignatureType GetMajorQualificationForSignature()
        {
            double major = GetMajorQualification();

            if (_maths == major)
                return SignatureType.MATH;
            if (_history == major)
                return SignatureType.HISTORY;
            if (_science == major)
                return SignatureType.SCIENCE;
            return SignatureType.LANGUAGE;
        }

        public SignatureType GetMinorQualificationForSignature()
        {
            double minor = GetMinorQualification();

            if (_maths == minor)
                return SignatureType.MATH;
            if (_history == minor)
                return SignatureType.HISTORY;
            if (_science == minor)
                return SignatureType.SCIENCE;
            return SignatureType.LANGUAGE;
        }
    }
}
