using System.Collections.Generic;

namespace Chess
{
    public class Knight : Piece
    {
        List<Moves> knightMoves = new List<Moves>();
        public int value;

        public Knight(bool color, long bb)
        {
            this.color = color;
            this.bb = bb;
            this.value = 3;
        }

        public override List<Moves> generateMoves()
        {
            return knightMoves;   
        }
    }
}