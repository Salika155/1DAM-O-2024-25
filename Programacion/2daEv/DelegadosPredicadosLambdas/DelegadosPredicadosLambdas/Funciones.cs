using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DelegadosPredicadosLambdas.Program;

namespace DelegadosPredicadosLambdas
{
    public class Funciones
    {
        public static bool DamePares(int n)
        {
            return (n % 2 == 0) ? true : false;
        }
        public static bool ExisteJuan(Delegado.Persona p)
        {
            return (p.Nombre == "Juan") ? true : false;
        }
        public static bool ExistenMayoresEdad(Delegado.Persona p)
        {
            return (p.Edad >= 18) ? true : false;
        }

        public static int Cuadrado(int n)
        {
            return n * n;
        }

        public static int SumaNumeros(int n1, int n2) => n1 + n2;

        public static bool CompararElementos<T>(T element1, T element2, ComparatorPersonasGenerico<T> comparator)
        {
            return comparator(element1, element2);
        }
    }
}
