using System.Collections.Generic;

namespace Chess
{
    public class Rook : Piece
    {
        public new static long[] movesLookUp = generateLookUp();
        public int value;


        public Rook(bool color, long bb)
        {
            this.color = color;
            this.bb = bb;
            this.value = 5;
        }

        public static long[] generateLookUp()
        {
            return movesLookUp;
        }
    }
}