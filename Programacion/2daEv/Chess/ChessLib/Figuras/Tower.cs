﻿
using ChessLib.Tablero;

namespace ChessLib.Figuras
{
    public class Tower : Figure
    {
        public Tower(FigureColor color, FigureType type, Coord coords) : base(color, coords, FigureType.TOWER)
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
