using System.Collections.Generic;

namespace Chess
{
    public class Bishop : Piece
    {
        public new static long[] movesLookUp = generateLookUp();
        public int value;

        public Bishop(bool color, long bb)
        {
            this.color = color;
            this.bb = bb;
            this.value = 3;
        }

        public static long[] generateLookUp()
        {
            return movesLookUp;
        }
    }
}