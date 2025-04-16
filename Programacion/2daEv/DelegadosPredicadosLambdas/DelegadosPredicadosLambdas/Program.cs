namespace DelegadosPredicadosLambdas
{
    public class Program
    {
        // Definición de los delegados
        delegate void ObjetoDelegado();
        delegate void ObjetoStringDelegado(string mensaje);

        static void Main(string[] args)
        {
            string mensaje = "usando el delegado tradicional";
            string mensajeLambda = "usando lambda";

            // 🔸 Estilo 1: Delegado tradicional (usa el tipo adecuado)
            ObjetoStringDelegado delegadoTradicional = MensajeBienvenida.SaludoBienvenida;
            delegadoTradicional(mensaje);

            // 🔸 Estilo 2: Lambda que adapta el método a un delegado sin parámetros
            ObjetoDelegado delegadoLambda = () => MensajeBienvenida.SaludoBienvenida(mensajeLambda);
            delegadoLambda();

            // 🔸 Delegado directo sin parámetros (despedida)
            ObjetoDelegado delegadoDespedida = MensajeDespedida.SaludoDespedida;
            delegadoDespedida();
        }
    }

    class MensajeBienvenida
    {
        public static void SaludoBienvenida(string msj)
        {
            Console.WriteLine("👋 Hola, soy Peter, {0}", msj);
        }
    }

    class MensajeDespedida
    {
        public static void SaludoDespedida()
        {
            Console.WriteLine("👋 Que te den mala pecora");
        }
    }
}

