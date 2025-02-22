
namespace Proyecto2DaEv
{
    public class RefExample
    {
        //1. Ejemplo de ref
        //Caso de uso:
        //Cuando necesitas modificar el valor de una variable dentro de un método y
        //que ese cambio se refleje fuera del método.
        // Método que usa 'ref' para modificar el valor de una variable
        public static void Incrementar(ref int numero)
        {
            numero++; // Modifica el valor original de la variable
        }

        // Método que incrementa un número usando 'ref'
        public static void Incrementar1(ref int numero)
        {
            numero += 5; // Modificamos el valor original de 'numero'
        }

        public static void ProbarRef()
        {
            int valor = 10;
            Console.WriteLine("Antes de Incrementar: " + valor);

            Incrementar(ref valor); // Pasamos 'valor' por referencia
            Console.WriteLine("Después de Incrementar: " + valor);
        }

        public static void ProbarRef1()
        {
            int valorOriginal = 10;
            Console.WriteLine($"Antes: {valorOriginal}"); // Antes: 10

            Incrementar1(ref valorOriginal); // Pasamos 'valorOriginal' por referencia
            Console.WriteLine($"Después: {valorOriginal}"); // Después: 15
        }
        //Explicación:
        //Incrementar(ref int numero) Recibe la variable por referencia (puede modificar su valor).
        // numero += 5 → Modifica la variable original.
        // Incrementar(ref valorOriginal) → Pasamos la variable por referencia.
        //lo que permite modificar el valor original de valor.

        //Después de llamar a Incrementar, el valor de valor cambia de 10 a 11.
    }
}
