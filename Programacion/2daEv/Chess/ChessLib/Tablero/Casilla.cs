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


        public Coord Coords => _coord;
        public IFigure? Figure
        {
            get => _figure;
            set
            {
                _figure = value;
            }
        }

        public CasillaColor Color => _casillaColor;
        public Casilla(Coord coord, CasillaColor type)
        {
            _coord = coord;
            _casillaColor = type;
            Figure = null;
        }

        public Casilla(Coord coord)
        {
            this._coord = coord;
        }
    }
}
