
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

        public bool EqualsToCoord(int x, int y)
        {
            return X == _x && Y == _y;
        }

        public bool EstaDentroDeLimitesTablero()
        {
            return X >= 0 && X < 8 && Y >= 0 && Y < 8;
        }

        public override string ToString()
        {
            return X.ToString() + " , " + Y.ToString();
        }
    }
}

//struct coords(inmutable)
//         * {
//    *x
//    * y
//    *  private readonly

//    * }
