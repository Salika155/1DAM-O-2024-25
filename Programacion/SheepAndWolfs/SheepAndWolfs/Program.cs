namespace SheepAndWolfs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Mundo mundo = new(40, 30);
            //Utils.GenerateRandomWorld(mundo);


            //mundo.CreateWolfs(5);
            //mundo.CreateSheeps(5);

            //Utils.DrawWorld(mundo);
            //Lobo lobo = new Lobo("lobo1");
            //Oveja oveja = new Oveja();

            //Animal l = oveja;

            //prueba casilla
            //Mundo mundo = new Mundo(3, 3);
            //mundo.CrearCasillas();
            //Console.WriteLine("Casillas creadas exitosamente.");

            //Mundo mundo = new Mundo(5, 5); // Un mundo pequeño para probar
            
            //mundo.AddAnimal(new Lobo("Lobo1"),0, 0); // Añadir un lobo en la posición 0,0
            //mundo.AddAnimal(new Oveja("Oveja1"), 4, 4); // Añadir una oveja en la posición 4,4
            //Utils.DrawWorld(mundo);      // Imprimir el tablero

            Mundo mundo = new Mundo(25, 25);
            mundo.CreateWolfs(Utils.GetRandomNumber(5, 15));
            mundo.CreateSheeps(Utils.GetRandomNumber(5, 15));
            


            Utils.DrawWorld(mundo);


        }
    }
}
