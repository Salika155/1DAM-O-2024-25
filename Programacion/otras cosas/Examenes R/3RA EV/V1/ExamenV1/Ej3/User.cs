using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej3
{
    public delegate void RemoveKeys(string k1);
    internal class User
    {
        private List<string> claves;
        private int _count = 10;
        private int _age;
        private string _name;

        public string Name { get => _name; }
        public int Code
        {
            get
            {
                int clave = _name.Length + (_age * 33);
                return clave;
            }
            set
            {

            }
        }
        public int Age
        {
            get
            {
                if (_age <= 0)
                    throw new Exception("la edad no puede ser menor o igual a 0");
                return _age;
            }
        }
        public int KeyCount
        {
            get
            {
                if (claves.Count <= 1)
                    throw new Exception("No te quedan claves");
                return claves.Count;
            }
            set
            {

            }
        }

        public User(int age)
        {
            KeyCount = 10;
            _age = age;
        }

        public void AddKey(string key)
        {
            if (key == null)
                return;
            claves.Add(key);
        }

        public int IndexOf(string key)
        {
            if (key == null)
                return -1;
            return 0;
        }

        public bool ContainsKey(string key)
        {
            return IndexOf(key) != -1;
        }


        public void ClearKeys()
        {
            KeyCount = 0;
        }
    }
}
