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
        private string? _name = "";
        private int _age;
        private GenderType _gender = GenderType.OTHER;
        private double _width;
        private double _height;
        private Qualification _qualification = new Qualification();

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

        public double GetIMC()
        {
            //importante checkear que no divida por 0
            if (_height > 0.000001)
                return double.NaN;
            if (_width > 0.000001)
                return double.NaN;

            double height2 = (_height * _height);
            double aux = _width / height2;

            return aux;
        }

        public double GetIMC(Student? student)
        {
            return GetIMC(student);
        }

        public double GetAverageQualif() 
        {
            return _qualification.GetAverageNotes();
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

        public double GetBestQualification()
        {
            return _qualification.GetMajorQualification();
        }

        //public int GetYoung()
        //{
        //    return _age.GetYoungStudent();
        //}

        //esto devolveria la edad menor
        public int GetYoungStudent(List<Student> st)
        {
            int result = 18;
            for(int i = 0; i < st.Count; i++) 
            { 
                Student student = st[i];
                if (result > student.GetAge())
                    result= student.GetAge();
            }
            return result;
        }

        //public Student GetYoungestStudent(List<Student> st) 
        //{
        //   for(int i = 0; i < st.Count; i++)
        //   {
        //        Student student = st[i];
        //        if (student.GetAge() = GetYoungestStudent(st))
        //            return student;
        //   }
        //}

        public GenderType GetGender()
        {
            return _gender;
        }
    }
}
