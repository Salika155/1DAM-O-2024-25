using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegadosPredicadosLambdas
{
    public class Delegado
    {
        public class Persona
        {
            private string _nombre = string.Empty;
            private int _edad;

            public string Nombre { get => _nombre; set => _nombre = value; }
            public int Edad { get => _edad; set => _edad = value; }
        }
    }
}

/*
 * ✅ 1. Filter (Filtrado)
¿Qué hace?
Un filter selecciona elementos de una colección que cumplen una condición.

¿Delegado típico?
public delegate bool Predicate<T>(T item);
¿Dónde lo ves?
En métodos como List<T>.FindAll(), Where() en LINQ, etc.

🧪 Ejemplo:
List<int> numeros = new() { 1, 2, 3, 4, 5 };
List<int> pares = numeros.FindAll(n => n % 2 == 0);
// Resultado: 2 y 4
✅ 2. Comparator (Comparador)
¿Qué hace?
Compara dos elementos. Devuelve true o false si cumplen una cierta relación (igualdad, mayor/menor, etc.).

¿Delegado típico?

public delegate bool Comparator<T>(T a, T b);
¿Dónde lo ves?
En ordenaciones (Sort()), comprobaciones (Any(), All()), estructuras como diccionarios, etc.

🧪 Ejemplo:
Comparator<int> compararEdades = (a, b) => a == b;
bool iguales = compararEdades(20, 20);  // true
✅ 3. Visitor (Visitador)
¿Qué hace?
Aplica una acción a cada elemento de una colección. No devuelve nada.

¿Delegado típico?

public delegate void Action<T>(T item);
¿Dónde lo ves?
En ForEach(), foreach, LINQ con ToList().ForEach(), etc.

🧪 Ejemplo:

List<string> nombres = new() { "Juan", "María", "Ana" };
nombres.ForEach(nombre => Console.WriteLine($"Hola, {nombre}"));
📌 ¿Hay más patrones comunes?
Sí, algunos más muy utilizados:

4. Transformer (Transformador / Map)
Transforma un tipo en otro.

public delegate TResult Transformer<T, TResult>(T item);
👉 Usado en Select() (LINQ).

List<int> cuadrados = numeros.Select(n => n * n).ToList();
5. Reducer (Reductor / Aggregator)
Combina elementos de una colección en un único valor.

public delegate TOutput Reducer<TInput, TOutput>(TOutput acc, TInput next);
👉 Usado en Aggregate() de LINQ.

int suma = numeros.Aggregate(0, (acum, n) => acum + n);
6. Predicate (Condición)
Esto es parte del filter, pero lo verás como tipo delegado por separado. Define una condición booleana.

Predicate<int> esPar = n => n % 2 == 0;
🧠 Resumen visual

Nombre	            Tipo delegado	                Uso principal
Filter	            Predicate<T>	                Filtrar elementos
Comparator	        Comparator<T> personalizado	    Comparar dos valores
Visitor	            Action<T>	                    Hacer algo con cada elemento
Transformer	        Func<T, TResult>	            Transformar de un tipo a otro
Reducer	            Func<TAcc, T, TAcc>	            Combinar todos en uno solo
*/
