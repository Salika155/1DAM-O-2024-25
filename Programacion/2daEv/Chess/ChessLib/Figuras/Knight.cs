﻿
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

        public override List<Coord> GetAvailablePositions(IChessBoard board)
        {
            throw new NotImplementedException();
        }

        protected override Figure CreateNewInstance(Coord newCoords)
        {
            throw new NotImplementedException();
        }
    }
}
