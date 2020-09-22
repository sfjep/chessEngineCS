using System.Collections.Generic;

namespace Chess
{
    public class Rook : Piece
    {
        List<Moves> rookMoves = new List<Moves>();
        public int value;


        public Rook(bool color, long bb)
        {
            this.color = color;
            this.bb = bb;
            this.value = 5;
        }

        public override List<Moves> generateMoves()
        {
            return rookMoves;
        }
    }
}