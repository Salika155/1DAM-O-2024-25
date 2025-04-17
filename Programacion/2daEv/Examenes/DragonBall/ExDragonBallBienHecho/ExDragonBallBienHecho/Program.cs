namespace ExDragonBallBienHecho
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Crear la instancia de la interfaz ITorneo
            ITorneo torneo = new Torneo();

            // Agregar participantes al torneo (concretamente, instancias de la clase Humano)
            torneo.AddParticipantes(Humano.CrearHumano("Satan", 100, 0.6));
            torneo.AddParticipantes(Supersaiyajin.CreateSuperSaiyajin("Vegeta", 90, 0.5));
            torneo.AddParticipantes(GuerreroEspacio.CreateGuerreroEspacio("Piccolo", 80, 0.7));
            torneo.AddParticipantes(Humano.CrearHumano("Freeza", 95, 0.6));

            // Filtro ejemplo: solo los que tienen energía mayor a 85
            FilterDelegate filtro = p => p.Energia > 85;
            FilterDelegate filtro2 = p => p.Name is "Goku";

            // Filtrar participantes antes de iniciar el torneo
            List<Persona> participantesFiltrados = torneo.FiltrarListaParticipantes(filtro);
            List<Persona> participantesFiltrados2 = torneo.FiltrarListaParticipantes(filtro2);

            // Mostrar los participantes filtrados
            Console.WriteLine("Participantes filtrados:");
            foreach (var participante in participantesFiltrados)
            {
                Console.WriteLine($"- {participante.Name}");
            }

            // Ejecutar las rondas del torneo
            torneo.Init();

            // Obtener al ganador
            Persona ganador = torneo.GetWinner();

            // Mostrar el ganador
            Console.WriteLine($"El ganador del torneo es: {ganador.Name}");
        }
    }
}
