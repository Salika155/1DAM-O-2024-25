using System;

class Ajedrez
{
    static char[,] tablero = new char[8, 8];

    static void Main()
    {
        InicializarTablero();

        while (true)
        {
            Console.Clear();
            DibujarTablero();

            Console.Write("\nMover pieza (ej. 'a2 a4'): ");
            string movimiento = Console.ReadLine().ToLower().Trim();

            if (movimiento.Length != 5 || movimiento[2] != ' ')
            {
                Console.WriteLine("¡Formato incorrecto! Presiona una tecla...");
                Console.ReadKey();
                continue;
            }

            try
            {
                int x1 = movimiento[0] - 'a';
                int y1 = movimiento[1] - '1';
                int x2 = movimiento[3] - 'a';
                int y2 = movimiento[4] - '1';

                tablero[x2, y2] = tablero[x1, y1];
                tablero[x1, y1] = ' ';
            }
            catch
            {
                Console.WriteLine("¡Coordenadas inválidas! Presiona una tecla...");
                Console.ReadKey();
            }
        }
    }

    static void InicializarTablero()
    {
        // Peones blancos
        for (int i = 0; i < 8; i++)
            tablero[i, 1] = 'P';

        // Peones negros
        for (int i = 0; i < 8; i++)
            tablero[i, 6] = 'p';
    }

    static void DibujarTablero()
    {
        Console.WriteLine("  a b c d e f g h");
        for (int y = 7; y >= 0; y--)
        {
            Console.Write($"{y + 1} ");
            for (int x = 0; x < 8; x++)
            {
                Console.Write(tablero[x, y] == 0 ? ". " : $"{tablero[x, y]} ");
            }
            Console.WriteLine($"{y + 1}");
        }
        Console.WriteLine("  a b c d e f g h");
    }
}