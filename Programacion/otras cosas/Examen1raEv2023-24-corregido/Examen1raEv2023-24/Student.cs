using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1raEv2023_24
{
    public enum GenderType
    {
        M,
        F,
        DESC
    }
    public class Student
    {
        private string _name = ""; //si no quiero que aparezca el warning verde, poner string vacio o ? en string
        //para aceptar valores nulos
        private int _age;
        private GenderType _gender = GenderType.DESC; //mejor dejarlo definido
        private double _altura;
        private double _peso;
        //esto seria la instancia, cuando ponga eso es utilizar la clase.
        private Notes _notes = new Notes(); //se puede dejar libre y despues colocarlo con un SetNotes

        public Student()
        {

        }

        public Student(string name, int age)
        {
            _name = name;
            _age = age;
        }

        public string GetName()
        {
            return _name;
        }

        //este no lo hice yo, por la instancia es posible que haga falta
        //si no es asi tendria que hacer una funcion para cada valor para acceder a ello
        //de esta manera desde notes podemos acceder a todo
        public Notes GetNotes()
        {
            return _notes;
        }

        //mejor checkear que altura o peso no sean menores a ese posible valor absoluto
        public double GetIMC()
        {
            if (Math.Abs(_altura) < 0.000001)
                return double.NaN;
            if (Math.Abs(_peso) < 0.000001)
                return double.NaN;

            return _peso / (_altura + _altura);
        }

        public double GetNoteAverage()
        {
            return _notes.GetAverage();
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
            s._altura = _altura;
            s._peso = _peso;
            s._notes = _notes.Clone();

            return s;
        }

       
        public int GetAge()
        {
            return _age;
        }

        public GenderType GetGenderType()
        {
            return _gender;
        }

        public double GetAltura()
        {
            return _altura;
        }

        public double GetPeso()
        {
            return _peso;
        }

        public void SetName(string name)
        {
            _name = name;
        }

        public void SetAge(int age)
        {
            _age = age;
        }

        public void SetGenderType(GenderType gender)
        {
            _gender = gender;
        }

        public void SetAltura(int altura)
        {
            _altura = altura;
        }

        public void SetPeso(double peso)
        {
            _peso = peso;
        }

        public double GetBestQualification()
        {
            return _notes.GetMajorQualification();
        }
    }
}
