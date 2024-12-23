using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessLib.Tablero;

namespace ChessLib.Figuras
{
    public class King : Figure
    {
        public King(FigureColor color, FigureType type, Coord coords) : base(color, coords, type)
        {
        }

        public override Coord[] GetAvailablePosition(IChessBoard board)
        {
            throw new NotImplementedException();
        }
    }
}