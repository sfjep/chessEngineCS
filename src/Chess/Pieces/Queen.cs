using System;
using System.Collections.Generic;

namespace Chess
{
    public class Queen : Piece
    {
        public new static long[] movesLookUp = generateLookUp();
        public int value;

        public Queen(bool color)
        {
            this.color = color;
            
            if(color == true)
            {
                this.bb = Squares.FILE_D & Squares.RANK_1;
            }
            else
            {
                this.bb = Squares.FILE_D & Squares.RANK_8;
            }

            this.value = 9;
        }

        /// <summary>
        /// "queenMoves": An array of bitboard of length 64. Each element represents possible moves from position i.
        /// 
        /// As the queen moves as a combination of a bishop and rook, we add the moves and the rook together to get the queen moves.
        /// </summary>
        public static long[] generateLookUp()
        {
            long[] queenMoves = new long[64];
            
            for(int index = 0; index < 64; index++)
            {
                queenMoves[index] = Bishop.movesLookUp[index] | Rook.movesLookUp[index];
            }
            
            return queenMoves;
        }
    }
}