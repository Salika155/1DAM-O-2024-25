using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessLib.Tablero;

namespace ChessLib.Figuras
{
    public class Knight : Figure
    {
        public Knight(FigureColor color, FigureType type, Coord coords) : base(color, coords, FigureType.KNIGHT)
        {
        }

        public override Coord[] GetAvailablePosition(IChessBoard board)
        {
            throw new NotImplementedException();
        }
    }
}
