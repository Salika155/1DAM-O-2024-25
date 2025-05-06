using ChessLib.Figuras;
using ChessLib.Tablero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    public class GameLoop
    {
        private ChessBoard? _tablero;
        private FigureColor _turnoActual;
        //private Coord? _piezaSeleccionada;
        //private List<Coord>? _movimientosValidos;

        public GameLoop()
        {
            _tablero = new ChessBoard(8, 8);
            _tablero.InitBoard();
            //empiezan los rojos
            _turnoActual = FigureColor.RED;
        }

        public void InitGame()
        {
            while (true)
            {
                Console.Clear();
                _tablero.PrintBoard();
                Console.WriteLine($"Turno de: {(_turnoActual == FigureColor.RED ? "ROJAS" : "NEGRAS")}");

                //var origen = SeleccionarYMostrarMovimientos();
                //if (origen == null)
                //    continue;


            }
                

        }

    }
}
