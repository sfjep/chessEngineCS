using System.Collections.Generic;

namespace Chess
{
    public class Pawn : Piece
    {
        List<Moves> pawnMoves = new List<Moves>();
        public int value;

        public Pawn(bool color, long bb)
        {
            this.color = color;
            this.bb = bb;
            this.value = 1;
        }

        public override List<Moves> generateMoves()
        {
            return pawnMoves;
        }
    }
}