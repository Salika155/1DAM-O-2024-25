// Copyright - Superyo - JMM
namespace TestPantalla
{
    internal class Program
    {
        static int CursorX = 0;
        static int CursorY = 0;
        static bool Selected = false;

        static void Main()
        {
            Console.CursorVisible = false;
            UI ui = new UI(20, 10);

            while (true)
            {
                ProcesarEntrada(ui);

                ui.Clear();
                FillChess(ui);
                FillFigures(ui);
                FillAvailablePositions(ui);
                ui[CursorX, CursorY] = new Cell('O', ConsoleColor.Red, ConsoleColor.Blue);
                ui.PrintString(0, 9, "Muevete ...", ConsoleColor.Black, ConsoleColor.White);

                ui.Show();
                Thread.Sleep(50);
            }
        }

        public static void FillChess(UI ui)
        {
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if ((x + y) % 2 == 0)
                        ui[x, y] = new Cell(' ', ConsoleColor.Black);
                    else
                        ui[x, y] = new Cell(' ', ConsoleColor.White);
                }
            }
        }

        public static void FillFigures(UI ui)
        {
            ui[3, 3] = new Cell('R', ConsoleColor.Blue);
            ui[4, 4] = new Cell('K', ConsoleColor.Red);
            ui[5, 5] = new Cell('P', ConsoleColor.Red);
            ui[6, 6] = new Cell('T', ConsoleColor.Red);
            ui[7, 7] = new Cell('C', ConsoleColor.Red);
        }

        public static void FillAvailablePositions(UI ui)
        {
            if (Selected)
            {
                for (int x = CursorX - 2; x <= CursorX + 2; x++)
                {
                    var cell = ui[x, CursorY];
                    cell.BackgroundColor = ConsoleColor.Green;
                    ui[x, CursorY] = cell;
                }
                for (int y = CursorY - 2; y <= CursorY + 2; y++)
                {
                    var cell = ui[CursorX, y];
                    cell.BackgroundColor = ConsoleColor.Green;
                    ui[CursorX, y] = cell;
                }

            }
        }

        static void ProcesarEntrada(UI ui)
        {
            if (!Console.KeyAvailable) 
                return;

            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.Spacebar:
                    Selected = !Selected;
                    break;
                case ConsoleKey.LeftArrow:
                    if (CursorX > 0)
                        CursorX--;
                    break;
                case ConsoleKey.RightArrow:
                    if (CursorX < ui.Width - 1)
                        CursorX++;
                    break;
                case ConsoleKey.UpArrow:
                    if (CursorY > 0)
                        CursorY--;
                    break;
                case ConsoleKey.DownArrow:
                    if (CursorY < ui.Height - 1)
                        CursorY++;
                    break;
            }
        }

    }
}


