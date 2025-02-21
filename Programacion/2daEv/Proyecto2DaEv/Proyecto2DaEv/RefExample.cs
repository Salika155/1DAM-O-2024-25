
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

        public static void ProbarRef()
        {
            int valor = 10;
            Console.WriteLine("Antes de Incrementar: " + valor);

            Incrementar(ref valor); // Pasamos 'valor' por referencia
            Console.WriteLine("Después de Incrementar: " + valor);
        }
            //Explicación:
            //Incrementar(ref int numero) recibe un parámetro por referencia(ref),
            //lo que permite modificar el valor original de valor.

            //Después de llamar a Incrementar, el valor de valor cambia de 10 a 11.
    }
}
