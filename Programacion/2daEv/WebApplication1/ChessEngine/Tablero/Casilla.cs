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
        //para pintar
        private readonly Coord _coord;
        private readonly CasillaColor _casillaColor;
        //puedo no pasarle ifugure o figure
        private IFigure? _figure;
        //esto no sirve
        private Coord coord;

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
            this.coord = coord;
        }
    }
}

//variables de stack: no necesitan de new: enteros, etc.
//variables de celda al crear clase celda de tipo heap

