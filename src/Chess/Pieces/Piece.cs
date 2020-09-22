
using System;
using System.Collections.Generic;

namespace Chess
{
    public abstract class Piece
    {
        public abstract List<Moves> generateMoves();
        public bool color;
        public long bb;

    }
}