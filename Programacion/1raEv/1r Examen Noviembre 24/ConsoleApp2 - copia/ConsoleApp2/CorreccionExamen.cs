using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class CorreccionExamen
    {
        public static bool Infernal(int n)
        {
            if (n == 0)
                return false;

            string num = Math.Abs(n).ToString(); // Convertimos a cadena y tomamos valor absoluto.

            // Recorremos la cadena buscando tres '6' consecutivos
            for (int i = 0; i <= num.Length - 3; i++) // Aseguramos no salirnos de la longitud
            {
                if (num[i] == '6' && num[i + 1] == '6' && num[i + 2] == '6')
                {
                    return true; // Retornamos true si encontramos "666"
                }
            }

            return false; // Si recorremos todo sin hallar "666"
        }


        public static bool IsPrimo(int n)
        {
            if (n <= 1) // Números menores o iguales a 1 no son primos
                return false;

            for (int i = 2; i <= Math.Sqrt(n); i++) // Solo verificamos hasta la raíz cuadrada de n
            {
                if (n % i == 0) // Si es divisible por cualquier número, no es primo
                    return false;
            }

            return true; // Si no encontramos divisores, es primo
        }


        public static int SumaNumerosPrimos(int n)
        {
            if (n <= 0) // Si el valor de entrada es no válido, retornamos 0
                return 0;

            int suma = 0; // Almacenará la suma de primos
            int count = 0; // Cuenta cuántos primos llevamos
            int numero = 2; // Comenzamos desde el primer número primo

            while (count < n) // Repetimos hasta encontrar los primeros n primos
            {
                if (IsPrimo(numero)) // Si el número es primo, lo sumamos
                {
                    suma += numero;
                    count++;
                }
                numero++; // Avanzamos al siguiente número
            }

            return suma; // Retornamos la suma de los primeros n primos
        }
    }
}
