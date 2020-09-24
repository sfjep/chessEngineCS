
using System;
using System.Collections.Generic;

namespace Chess
{
    public abstract class Piece
    {
        public long[] movesLookUp;
        public bool color;
        public long bb;
    }
}