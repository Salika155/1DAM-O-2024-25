using ChessLib.Figuras;

namespace ChessLib.Tablero
{
    public enum CasillaColor
    {
        BLACK,
        WHITE
    }

    public class Casilla
    {
        private readonly Coord _coord;
        private readonly CasillaColor _casillaColor;
        private IFigure? _figure;
        //private Coord coord;

        public Coord Coords => _coord;
        public CasillaColor Color => _casillaColor;
        public IFigure? Figure
        {
            get => _figure;
            set => _figure = value;
        }
        
        public Casilla(Coord coord, CasillaColor type)
        {
            _coord = coord;
            _casillaColor = type;
            _figure = null;
        }

        //public Casilla(Coord coord)
        //{
        //    this._coord = coord;
        //}
    }
}
