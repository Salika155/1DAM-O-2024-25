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

        

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public IFigure? GetFigureAt(int x, int y)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height)
                return null; // Fuera del tablero.
            return _casillas[x, y].Figure;
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
            return _height;
        }

        public int GetWidth()
        {
            return _width;
        }

        //Metodo para inicializar las casillas
        public void InitBoard()
        {
            // Piezas blancas
            _casillas[0, 0].Figure = new Tower(FigureColor.WHITE, new Coord(0, 0), FigureType.TOWER);
            _casillas[7, 0].Figure = new Tower(FigureColor.WHITE, new Coord(7, 0), FigureType.TOWER);
            _casillas[1, 0].Figure = new Knight(FigureColor.WHITE, new Coord(1, 0), FigureType.KNIGHT);
            _casillas[6, 0].Figure = new Knight(FigureColor.WHITE, new Coord(6, 0), FigureType.KNIGHT);
            _casillas[2, 0].Figure = new Bishop(FigureColor.WHITE, new Coord(2, 0), FigureType.BISHOP);
            _casillas[5, 0].Figure = new Bishop(FigureColor.WHITE, new Coord(5, 0), FigureType.BISHOP);
            _casillas[3, 0].Figure = new Queen(FigureColor.WHITE, new Coord(3, 0), FigureType.QUEEN);
            _casillas[4, 0].Figure = new King(FigureColor.WHITE, new Coord(4, 0), FigureType.KING);

            for (int i = 0; i < _width; i++)
            {
                _casillas[i, 1].Figure = new Pawn(FigureColor.WHITE, new Coord(i, 1), FigureType.PAWN);
            }

            // Piezas negras
            _casillas[0, 7].Figure = new Tower(FigureColor.BLACK, new Coord(0, 7), FigureType.TOWER);
            _casillas[7, 7].Figure = new Tower(FigureColor.BLACK, new Coord(7, 7), FigureType.TOWER);
            _casillas[1, 7].Figure = new Knight(FigureColor.BLACK, new Coord(1, 7), FigureType.KNIGHT);
            _casillas[6, 7].Figure = new Knight(FigureColor.BLACK, new Coord(6, 7), FigureType.KNIGHT);
            _casillas[2, 7].Figure = new Bishop(FigureColor.BLACK, new Coord(2, 7), FigureType.BISHOP);
            _casillas[5, 7].Figure = new Bishop(FigureColor.BLACK, new Coord(5, 7), FigureType.BISHOP);
            _casillas[3, 7].Figure = new Queen(FigureColor.BLACK, new Coord(3, 7), FigureType.QUEEN);
            _casillas[4, 7].Figure = new King(FigureColor.BLACK, new Coord(4, 7), FigureType.KING);

            for (int i = 0; i < _width; i++)
            {
                _casillas[i, 6].Figure = new Pawn(FigureColor.BLACK, new Coord(i, 6), FigureType.PAWN);
            }
        }
        //hara falta metodo para inicializar figuras

        public bool MoveFigure(int fromX, int fromY, int toX, int toY)
        {
            var origin = _casillas[fromX, fromY];
            var destination = _casillas[toX, toY];

            if (origin.Figure == null)
                return false; // No hay figura en la casilla de origen

            var figure = origin.Figure;

            // Comprobar si el movimiento es válido según la lógica de la figura
            var targetCoord = new Coord(toX, toY);
            if (!figure.ValidateMove(targetCoord, this))
                return false;

            // Realizar el movimiento
            destination.Figure = figure;
            origin.Figure = null;

            // Actualizar la posición de la figura
            //figure.GetCoord() = targetCoord;
            //figure.SumMovements();

            return true;
        }

        public void RemoveFigureAt(int x, int y)
        {
            if (x >= 0 && x < _width && y >= 0 && y < _height)
                _casillas[x, y].Figure = null;
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

        public bool MoveFigure(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}

//class ChessBoard : IChessBoard
//         *
//{
//         *      IChessBoard b = new ChessBoard();
//         * }