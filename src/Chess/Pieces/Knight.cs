using System;
using System.Collections.Generic;

namespace Chess
{
    public class Knight : Piece
    {
        
        public new static long[] movesLookUp = generateLookUp();

        public Knight(bool color)
        {
            this.color = color;
            
            if(color == true)
            {
                this.bb = (Squares.FILE_B | Squares.FILE_G) & Squares.RANK_1;
            }
            else
            {
                this.bb = (Squares.FILE_B | Squares.FILE_G) & Squares.RANK_8;
            }
            
            this.value = 3;
        }

        public static long[] generateLookUp()
        {
            long piecePosition;
            long possibleMoves;

            long[] knightMoves = new long[64];
            List<int> knigthShifts_A_File = new List<int>() { -15, -6, 10, 17 };
            List<int> knigthShifts_B_File = new List<int>() { 15, 17, 10, -6, -15, -17 };
            List<int> knigthShifts_G_File = new List<int>() { -10, -15, -17, 6, 15, 17 };
            List<int> knigthShifts_H_File = new List<int>() { 6, 15, -10, -17 };
            List<int> knigthShifts_CDEF = new List<int>() { 6, 10, 15, 17, -6, -10, -15, -17 };

            for (int i = 0; i < 64; i++)
            {
                piecePosition = 1L << (63-i);
                possibleMoves = 0L;

                if ((piecePosition & Squares.FILE_A) != 0L) { possibleMoves = getMovesFromFile(piecePosition, knigthShifts_A_File, i, possibleMoves); }
                else if ((piecePosition & Squares.FILE_B) != 0L) { possibleMoves = getMovesFromFile(piecePosition, knigthShifts_B_File, i, possibleMoves); }
                else if ((piecePosition & Squares.FILE_G) != 0L) { possibleMoves = getMovesFromFile(piecePosition, knigthShifts_G_File, i, possibleMoves); }
                else if ((piecePosition & Squares.FILE_H) != 0L) { possibleMoves = getMovesFromFile(piecePosition, knigthShifts_H_File, i, possibleMoves); }
                else { possibleMoves = getMovesFromFile(piecePosition, knigthShifts_CDEF, i, possibleMoves); }
                knightMoves[i] = possibleMoves;
            }
            return knightMoves;
        }

        private static long getMovesFromFile(long piecePosition, List<int> knigthShifts, int i, long possibleMoves)
        {
            foreach ( int shift in knigthShifts )
            {
                if ( shift < 0 )
                {
                    possibleMoves += piecePosition << -shift;
                }
                else
                {
                    if ( i == 0 ) { possibleMoves += -( piecePosition >> shift ); }
                    else{ possibleMoves += piecePosition >> shift; }
                }
            }

            return possibleMoves;
        }


    }
}