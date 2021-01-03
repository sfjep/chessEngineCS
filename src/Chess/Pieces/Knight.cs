using System;
using System.Collections.Generic;

namespace Chess
{
    public class Knight : Piece
    {
        public new static long[] movesLookUp = generateLookUp();
        public int value;
        private static long startPosition = 0L;
        private static long  possibleMoves = 0L;

        public Knight(bool color, long bb)
        {
            this.color = color;
            this.bb = bb;
            this.value = 3;
        }

        public static long[] generateLookUp()
        {
            long[] knightMoves = new long[64];
            List<int> knigthShifts_A_File = new List<int>() {-15, -6, 10, 17};
            List<int> knigthShifts_B_File = new List<int>() {15, 17, 10, -6, -15, -17};
            List<int> knigthShifts_G_File = new List<int>() {-10, -15, -17, 6, 15, 17};
            List<int> knigthShifts_H_File = new List<int>() {6, 15, -10, -17};
            List<int> knigthShifts_CDEF = new List<int>() {6, 10, 15, 17, -6, -10, -15, -17};
            
            for(int i = 0; i < 64; i++)
            {
                startPosition = 1L<<i;
                possibleMoves = 0L;
                
                if((startPosition & Squares.FILE_A)!=0L) { getMovesFromFile(startPosition, knigthShifts_A_File, i); }
                else if((startPosition & Squares.FILE_B)!=0L) { getMovesFromFile(startPosition, knigthShifts_B_File, i); }
                else if((startPosition & Squares.FILE_G)!=0L) { getMovesFromFile(startPosition, knigthShifts_G_File, i); }
                else if((startPosition & Squares.FILE_H)!=0L) { getMovesFromFile(startPosition, knigthShifts_H_File, i); }
                else { getMovesFromFile(startPosition, knigthShifts_CDEF, i); }
                knightMoves[i] = possibleMoves;
            }
            return knightMoves;
        }
        
        private static void getMovesFromFile(long startPosition, List<int> knigthShifts, int i)
        {
            foreach(int shift in knigthShifts)
            {
                if(shift < 0)
                {
                    if(i == 63) { possibleMoves += -(startPosition>>-shift); }
                    else{ possibleMoves += startPosition>>-shift; }

                }
                else
                {
                    possibleMoves += startPosition<<shift;
                }
            }
        }


    }
}