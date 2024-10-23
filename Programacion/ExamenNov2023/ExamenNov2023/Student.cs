using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenNov2023
{
    public enum GenderType
    {
        MALE,
        FEMALE,
        OTHER
    }
    public class Student
    {
        private string? _name;
        private int _age;
        private GenderType _gender;
        private double _width;
        private double _height;
        Qualification _qualification = new Qualification();

        public Student()
        {

        }

        public Student(string name, int age)
        {
            _name = name;
            _age = age;
        }

        public Student(string name)
        {
            _name = name;
        }

        public static bool AreEquals(Student st, Student other)
        {
            return st._name == other._name;
        }

        public Qualification GetQualification()
        {
            return _qualification;
        }
        public string? GetName()
        {
            return _name;
        }

        public void SetName(string name) 
        {
            if (name == null)
                return;
            _name = name;
        }

        public int GetAge() 
        {
            return _age;
        }

        public void SetAge(int age) 
        {
            if (age < 0 || age >= 100)
                return;
            _age = age;
        }

        public GenderType GetGender(Student student) 
        {
            if (GenderType.MALE == student._gender)
                return GenderType.MALE;
            if (GenderType.FEMALE == student._gender)
                return GenderType.FEMALE;
            return GenderType.OTHER;
        }

        public void SetGender(GenderType gender)
        {
            if (GenderType.MALE == gender)
                _gender = GenderType.MALE;
            if (GenderType.FEMALE == gender)
                _gender = GenderType.FEMALE;
            else
                _gender = GenderType.OTHER;
        }

        public double GetWidth()
        {
            return _width;
        }

        public double GetHeight() 
        {
            return _height;
        }

        public void SetWidth(double width) 
        {
            _width = width;
        }

        public void SetHeight(double height) 
        {
            _height = height;
        }

        public double GetIMC(double width, double height)
        {
            double height2 = (height * height);
            double aux = width / height2;

            return aux;
        }

        public double GetIMC(Student? student)
        {
            return GetIMC(student);
        }

        public double GetAverageQualif() 
        {
            return _qualification.GetQualification();
        }

        public bool IsElder()
        {
            return _age >= 18;
        }

        public Student Clone()
        {
            Student s = new Student();

            s._name = _name;
            s._age = _age;
            s._gender = _gender;
            s._height = _height;
            s._width = _width;
            s._qualification = _qualification.Clone();

            return s;
        }
    }
}
