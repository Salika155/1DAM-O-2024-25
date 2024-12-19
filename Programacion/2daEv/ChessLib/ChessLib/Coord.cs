
namespace ChessLib
{
    public readonly struct Coord
    {
        private readonly int _x;
        private readonly int _y;

        public readonly int X => _x;
        public readonly int Y => _y;

        public Coord(int x, int y)
        {
            _x = x;
            _y = y;
        }
    }
}

//struct coords(inmutable)
//         * {
//    *x
//    * y
//    *  private readonly

//    * }
