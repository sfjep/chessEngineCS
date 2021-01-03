using System;
using System.Collections.Generic;
using static Chess.Squares;

namespace Chess
{
    public class Bishop : Piece
    {
        public new static long[] movesLookUp = generateLookUp();
        public int value;

        public Bishop(bool color)
        {
            this.color = color;

            // if white
            if (color == true)
            {
                this.bb = (Squares.FILE_C | Squares.FILE_F) & Squares.RANK_1;
            }
            else
            {
                this.bb = (Squares.FILE_C | Squares.FILE_F) & Squares.RANK_8;
            }

            this.value = 3;
        }


        public static long[] generateLookUp()
        {
            long[] bishopMoves = new long[64];
            long piecePosition;
            long possibleMoves;
            long newLocation;

            for (int i = 0; i < 64; i++)
            {
                piecePosition = 1L << (63 - i);
                int leftOffset = i % 8;
                int rightOffset = 7 - leftOffset;
                possibleMoves = 0L;

                for (int j = 1; j <= leftOffset; j++)
                {
                    // Go up left, shift right by 7
                    newLocation = piecePosition >> 7 * j;
                    possibleMoves += newLocation;

                    // Go down left, shift left by 9
                    newLocation = piecePosition << 9 * j;
                    possibleMoves += newLocation;
                }

                for (int j = 1; j <= rightOffset; j++)
                {
                    // Go up right, shift right by 9
                    newLocation = piecePosition >> 7 * j;
                    possibleMoves += newLocation;

                    // Go down right, shift left by 7
                    newLocation = piecePosition << 9 * j;
                    possibleMoves += newLocation;
                }

                bishopMoves[i] = possibleMoves;
            }
            return bishopMoves;
        }
    }
}