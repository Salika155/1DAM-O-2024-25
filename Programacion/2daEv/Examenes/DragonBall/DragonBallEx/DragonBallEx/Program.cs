namespace DragonBallEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("¡Bienvenido al Torneo de Artes Marciales de Dragon Ball!");

            // 1. Crear una instancia del torneo
            Torneo torneo = new Torneo();

            // 2. Inicializar el torneo con 16 participantes
            torneo.Init();

            // 3. Mostrar los participantes del torneo
            Console.WriteLine("\nParticipantes del torneo:");
            torneo.Visit(p => Console.WriteLine($"{p.Name} ({p.Raza}) - Energía: {p.Energia}"));

            // 4. Ejecutar el torneo y obtener los resultados
            Console.WriteLine("\n¡Comienza el torneo!");
            List<string> resultados = torneo.Execute();

            // 5. Mostrar los resultados de cada combate
            Console.WriteLine("\nResultados de los combates:");
            foreach (var resultado in resultados)
            {
                Console.WriteLine(resultado);
            }

            Console.WriteLine("\n¡El torneo ha terminado!");
        }
    }
}
