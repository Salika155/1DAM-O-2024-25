using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trucos
{
    internal class Utils
    {
        public static string EsMayorDeEdad(int n)
        {
            int age = n;
            string result = "";

            //if (age >= 18)
            //{
            //    result = "Es mayor de edad";
            //}
            //else
            //{
            //    result = "Es menor de edad";
            //}
            //return result;
            return result = (age >= 18) ? "Es mayor de edad" : "Es menor de edad";
        }

        public static string GetCategoryName(string n)
        {
            string? category = null;
            //string name = "";
            string name = category ?? "Otro";
            //esto hara que si el valor es igual a category lo devuelva como null, si no devuelva la otra opcion
            //que es el string con "Otro"

            //if (category != null)
            //{
            //    name = category;
            //}
            //else
            //{
            //    name = "Otra";
            //}
            return name;
        }

        //Comparar string en lista y si empiezan por A mayuscula añadirlos a una nueva lista
        public static List<string> GetNamesWithA(List<string> n)
        {
            List<string> names2 = new List<string>();
            foreach (string name in n)
            {
                if (name.ToUpper()[0] == 'A')
                    names2.Add(name);
            }
            return names2;
        }
        public static List<string> GetNamesWithA2(List<string> n)
        {
            List<string> names2 = n.Where(n => n.ToUpper()[0] == 'A').ToList();
            return names2;
        }



    }
}
