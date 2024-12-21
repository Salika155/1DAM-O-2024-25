using ChessLib.Figuras;

namespace ChessLib.Tablero
{
    public class ChessBoard : IChessBoard
    {
        private readonly Casilla[ , ] _casillas;
        private readonly int _width;
        private readonly int _height;
        private readonly Figure[] _figures;

        public int Width => _width;
        public int Height => _height;

        public ChessBoard(int width, int height)
        {
            _width = width;
            _height = height;
            _casillas = new Casilla[width, height];
            _figures = new Figure[32];
            CrearCasillas();
            //metodo para iniciar fichas
        }

        public ChessBoard() : this (8, 8)
        {

        }

        IChessBoard b = new ChessBoard();

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public IFigure GetFigureAt(int x, int y)
        {
            throw new NotImplementedException();
        }

        public IFigure GetFigureAt(int index)
        {
            throw new NotImplementedException();
        }

        public int GetFigureCount()
        {
            return _figures.Length - 1;
        }

        public int GetHeight()
        {
            throw new NotImplementedException();
        }

        public int GetWidth()
        {
            throw new NotImplementedException();
        }

        //Metodo para inicializar las casillas
        public void InitBoard()
        {
            throw new NotImplementedException();
        }
        //hara falta metodo para inicializar figuras

        public bool MoveFigure(int x, int y)
        {
            throw new NotImplementedException();
        }

        public void CrearCasillas()
        {
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    var color = (x + y) % 2 == 0 ? CasillaColor.WHITE : CasillaColor.BLACK;

                    _casillas[x, y] = new Casilla(new Coord(x, y));
                }
            }
        }

        
    }
}

//class ChessBoard : IChessBoard
//         *
//{
//         *      IChessBoard b = new ChessBoard();
//         * }