using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaExamen
{
    class Student : IComparable<Student>
    {
        public string Name = string.Empty;
        public int Id = 0;
        public static bool operator == (Student? a, Student? b)
        {
            if (a is null)
                return false;
            return true;
        }

        public static bool operator != (Student? a, Student? b)
        {
            return true;
        }

        public int CompareTo(Student? other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            if (GetType() == obj.GetType())
            {
                Student s = (Student)obj;
                return s.Name == Name;
            }
            return base.Equals(obj);
        }

        //selainventa
        public bool Match(Comparison<Student> comparer, Student other)
        {
            if (comparer == null)
                return false;
            return comparer(this, other) == 0;
        }
        public int CompareTo(Student? other)
        {
            if (other == null)
                return -1;
            int n;
            n = Name.CompareTo(other.Name);
            if (n != 0)
                return n;
            //n = Id.CompareTo(other.Id); -> un boxing haciendo un new por debajo -> coger esa variable de stack y pasarla a heap
            if (Id > other.Id)
                return -1;
            if (Id < other.Id)
                return 1;

            return 0;
        }
        //sagrado para diccionarios o cualquier coleccion que quiera hacer uso de tu hash
        public override int GetHashCode()
        {
            //para el caso de que el name sea el key
            return Name.GetHashCode() + Id;
        }
    }
}

//servidor de ajedreces
