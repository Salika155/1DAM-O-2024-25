using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessLib.Tablero;

namespace ChessLib.Figuras
{
    public enum FigureColor
    {
        BLACK,
        WHITE
    }

    public enum FigureType
    {
        BASE,
        PAWN,
        TOWER,
        KING,
        QUEEN,
        KNIGHT,
        BISHOP
    }

    public abstract class Figure : IFigure
    {
        private readonly FigureColor _colorFigure;
        private readonly FigureType _typeFigure;
        private readonly Coord _coords;

        public Coord Coords => _coords;
        public FigureType Type => _typeFigure;
        public FigureColor Color => _colorFigure;

        

        public Figure(FigureColor color, Coord coords, FigureType type)
        {
            _colorFigure = color;
            _coords = coords;
            _typeFigure = type;
        }
        public abstract Coord[] GetAvailablePosition(IChessBoard board);
    }
}

//class Figure : IFigure
//         *
//{
//         *      public abstract Coords[] GetAvailablePosition(IChessBoard board);
//         * 
//         * }