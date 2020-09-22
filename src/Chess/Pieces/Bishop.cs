using System.Collections.Generic;

namespace Chess
{
    public class Bishop : Piece
    {
        List<Moves> bishopMoves = new List<Moves>();
        public int value;

        public Bishop(bool color, long bb)
        {
            this.color = color;
            this.bb = bb;
            this.value = 3;
        }

        public override List<Moves> generateMoves()
        {
            return bishopMoves;
        }
    }
}