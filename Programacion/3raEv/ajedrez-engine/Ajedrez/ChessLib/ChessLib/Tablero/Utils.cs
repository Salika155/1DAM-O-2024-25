
using ChessLib.Figuras;

namespace ChessLib.Tablero
{
    public class Utils
    {
        internal static int IndexOfCasilla(int x, int y, int width)
        {
            throw new NotImplementedException();
        }

        //private void CrearFiguras(IChessBoard board)
        //{
        //    CrearPeones();
        //    CrearTorres();
        //    CrearAlfiles();
        //    CrearCaballos();
        //    CrearReyes();
        //}

        //private void CrearReyes()
        //{
        //    //reyes blancos
        //    _casillas[3, 0].Figure = new Queen(FigureColor.RED, new Coord(3, 0));
        //    _casillas[4, 0].Figure = new King(FigureColor.RED, new Coord(4, 0));
        //    //reyes negros
        //    _casillas[3, 7].Figure = new Queen(FigureColor.BLACK, new Coord(3, 7));
        //    _casillas[4, 7].Figure = new King(FigureColor.BLACK, new Coord(4, 7));
        //}

        //private void CrearCaballos()
        //{
        //    //caballos blancos
        //    _casillas[1, 0].Figure = new Knight(FigureColor.RED, new Coord(1, 0));
        //    _casillas[6, 0].Figure = new Knight(FigureColor.RED, new Coord(6, 0));
        //    //caballos negros
        //    _casillas[1, 7].Figure = new Knight(FigureColor.BLACK, new Coord(1, 7));
        //    _casillas[6, 7].Figure = new Knight(FigureColor.BLACK, new Coord(6, 7));
        //}

        //private void CrearAlfiles()
        //{
        //    //alfiles blancos
        //    _casillas[2, 0].Figure = new Bishop(FigureColor.RED, new Coord(2, 0));
        //    _casillas[5, 0].Figure = new Bishop(FigureColor.RED, new Coord(5, 0));
        //    //alfiles negros
        //    _casillas[2, 7].Figure = new Bishop(FigureColor.BLACK, new Coord(2, 7));
        //    _casillas[5, 7].Figure = new Bishop(FigureColor.BLACK, new Coord(5, 7));
        //}

        //private void CrearTorres()
        //{
        //    //torres blancas
        //    _casillas[0, 0].Figure = new Tower(FigureColor.RED, new Coord(0, 0));
        //    _casillas[7, 0].Figure = new Tower(FigureColor.RED, new Coord(7, 0));
        //    //torres negras
        //    _casillas[0, 7].Figure = new Tower(FigureColor.BLACK, new Coord(0, 7));
        //    _casillas[7, 7].Figure = new Tower(FigureColor.BLACK, new Coord(7, 7));
        //}

        //private void CrearPeones(IChessBoard board)
        //{
        //    // Piezas blancas
        //    for (int i = 0; i < board.Width; i++)
        //    {
        //        _casillas[i, 1].Figure = new Pawn(FigureColor.RED, new Coord(i, 1));
        //    }

        //    // Piezas negras
        //    for (int i = 0; i < board.Width; i++)
        //    {
        //        _casillas[i, 6].Figure = new Pawn(FigureColor.BLACK, new Coord(i, 6));
        //    }
        //}
    }
}