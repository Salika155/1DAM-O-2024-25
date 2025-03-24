using ChessLib.Figuras;
using ChessLib.Tablero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    public class GameController
    {
        private ChessBoard? _tablero;
        private FigureColor _turnoActual;
        //private Coord? _piezaSeleccionada;
        //private List<Coord>? _movimientosValidos;

        public GameController()
        {
            _tablero = new ChessBoard(8, 8);
            _tablero.InitBoard();
            //empiezan los rojos
            _turnoActual = FigureColor.RED;
        }

    }
}
