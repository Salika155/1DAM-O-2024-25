namespace Proyecto2DaEv
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Ejemplo de ref ===");
            RefExample.ProbarRef();

            Console.WriteLine("\n=== Ejemplo de out ===");
            OutExample.ProbarOut();

            Console.WriteLine("\n=== Ejemplo de in ===");
            InExample.ProbarIn();

            Console.WriteLine("\n=== Ejemplo de lambda ===");
            LambdaExample.ProbarLambda();

            Console.WriteLine("\n=== Ejemplo de FilterProfundo ===");
            FilterProfundoExample.ProbarFilterProfundo();

            /*
             * 7. Resumen de casos de uso
               - ref: Útil cuando necesitas modificar una variable dentro de un método.
               - out: Útil cuando necesitas devolver múltiples valores desde un método.
               - in: Útil cuando necesitas pasar parámetros de solo lectura (especialmente para estructuras grandes).
               - Funciones lambda: Útiles para definir funciones anónimas de manera concisa (por ejemplo, en filtros).
               - Filtrado con FilterProfundo: Útil cuando necesitas encadenar múltiples filtros sobre una lista.
             */
        }
    }
}
