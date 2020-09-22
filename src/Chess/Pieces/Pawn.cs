using System.Collections.Generic;

namespace Chess
{
    public class Pawn : Piece
    {
        public new static long[] movesLookUp = generateLookUp();
        public int value;

        public Pawn(bool color, long bb)
        {
            this.color = color;
            this.bb = bb;
            this.value = 1;
        }

        public static long[] generateLookUp()
        {
            return movesLookUp;
        }
    }
}