using System;
using System.Collections.Generic;

namespace Chess
{
    public class Bishop : Piece
    {
        public new static long[] movesLookUp = generateLookUp();
        public int value;
        private static Int64 startPosition = 0L;
        private static long possibleMoves = 0L;
        private static long newLocation = 0L;
        private static bool offBoardUpLeft = false;
        private static bool offBoardDownLeft = false;
        private static bool offBoardUpRight = false;
        private static bool offBoardDownRight = false;

        public Bishop(bool color, long bb)
        {
            this.color = color;
            this.bb = bb;
            this.value = 3;
        }

        public static long[] generateLookUp()
        {
            long[] bishopMoves = new long[64];

            for (int i = 0; i < 64; i++)
            {
                startPosition = 1L << i;
                possibleMoves = 0L;
                newLocation = 0L;

                offBoardUpLeft = false;
                offBoardDownLeft = false;
                offBoardUpRight = false;
                offBoardDownRight = false;

                // Any piece can maximum move 7 steps in any direction 
                for (int j = 1; j < 8; j++)
                {
                    // Go up & right
                    newLocation = startPosition << (j * 9);
                    if (i == 63) { newLocation = -newLocation; }
                    if (((newLocation & File.FILE_A) == 0L) && !offBoardUpRight) { possibleMoves += newLocation; }
                    else { offBoardUpRight = true; }
                    if ((newLocation & File.FILE_H) != 0L) { offBoardUpRight = true; }

                    // Go up & left
                    newLocation = startPosition << (j * 7);
                    if (i == 63) { newLocation = -newLocation; }
                    if (((newLocation & File.FILE_H) == 0L) && !offBoardUpLeft) { possibleMoves += newLocation; }
                    else { offBoardUpLeft = true; }
                    if ((newLocation & File.FILE_A) != 0L) { offBoardUpLeft = true; }

                    // Go down & right
                    newLocation = startPosition >> (j * 7);
                    if (i == 63) { newLocation = -newLocation; }
                    if (((newLocation & File.FILE_A) == 0L) && !offBoardDownRight) { possibleMoves += newLocation; }
                    else { offBoardDownRight = true; }
                    if ((newLocation & File.FILE_H) != 0L) { offBoardDownRight = true; }

                    // Go down & left
                    newLocation = startPosition >> (j * 9);
                    if (i == 63) { newLocation = -newLocation; }
                    if (((newLocation & File.FILE_H) == 0L) && !offBoardDownLeft) { possibleMoves += newLocation; }
                    else { offBoardDownLeft = true; }
                    if ((newLocation & File.FILE_A) != 0L) { offBoardDownLeft = true; }
                }
                bishopMoves[i] = possibleMoves;
            }
            return bishopMoves;
        }
    }
}