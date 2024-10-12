using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trucos
{
    public class Prueba
    {
        public string? name;
        public string? description;

        public Prueba(string name, string descripcion) 
        {
            

        }
        public int Add(int a, int b)
        {
            return a + b;
        }

        public double Add(double a, double b) 
        {
            return a + b;
        }

        public T Add<T>(T a, T b) where T : struct
        {
            return (dynamic)a + (dynamic)b;
        }


       
    }
}
