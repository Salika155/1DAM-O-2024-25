namespace AjedrezPARATONTOS
{
    class Program
    {
        static void Main()
        {
            var board = new ChessBoard();
            while (true)
            {
                Console.Clear();
                board.Draw();
                Console.WriteLine("\nPresiona cualquier tecla para salir...");
                if (Console.KeyAvailable)
                    break;
                Thread.Sleep(100);
            }
        }
    }
}
