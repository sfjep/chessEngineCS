using System.Collections.Generic;

namespace Chess
{
    public class Queen : Piece
    {
        List<Moves> queenMoves = new List<Moves>();
        public int value;

        public Queen(bool color, long bb)
        {
            this.color = color;
            this.bb = bb;
            this.value = 9;
        }

        public override List<Moves> generateMoves()
        {
            return queenMoves;
        }
    }
}