using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorreccionExamenV1nov24
{
    internal class Funciones
    {
        public static bool Infernal(int n)
        {
            if (n == 0)
                return false;

            n = Math.Abs(n); // Tomamos el valor absoluto del número.

            int consecutiveSixes = 0; // Contador para los '6' consecutivos.

            while (n > 0) // Recorremos los dígitos del número.
            {
                if (n % 10 == 6) // Si el último dígito es un 6.
                {
                    consecutiveSixes++;
                    if (consecutiveSixes == 3) // Si encontramos tres '6' consecutivos.
                    {
                        return true;
                    }
                }
                else
                {
                    consecutiveSixes = 0; // Reiniciamos el contador si el dígito no es '6'.
                }

                n /= 10; // Eliminamos el último dígito.
            }

            return false; // Si no encontramos "666", retornamos false.
        }

        public static bool IsPrimo(int n)
        {
            if (n <= 1) // Números menores o iguales a 1 no son primos.
                return false;

            for (int i = 2; i <= Math.Sqrt(n); i++) // Solo verificamos hasta la raíz cuadrada de n.
            {
                if (n % i == 0) // Si es divisible por cualquier número, no es primo.
                    return false;
            }

            return true; // Si no encontramos divisores, es primo.
        }

        public static int SumaNumerosPrimos(int n)
        {
            if (n <= 0) // Si el valor de entrada es no válido, retornamos 0.
                return 0;

            int suma = 0; // Almacenará la suma de primos.
            int count = 0; // Cuenta cuántos primos llevamos.
            int numero = 2; // Comenzamos desde el primer número primo.

            while (count < n) // Repetimos hasta encontrar los primeros n primos.
            {
                if (IsPrimo(numero)) // Si el número es primo, lo sumamos.
                {
                    suma += numero;
                    count++;
                }
                numero++; // Avanzamos al siguiente número.
            }

            return suma; // Retornamos la suma de los primeros n primos.
        }
    }
}
