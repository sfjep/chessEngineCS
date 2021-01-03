
using System;
using System.Collections.Generic;

namespace Chess
{
    public abstract class Piece
    {
        /// <summary>
        /// movesLookUp is an array of bitboards
        /// </summary>
        public static long[] movesLookUp;
        public bool color;
        public long bb;
        public int value;
    }
}