using System;
using System.Collections.Generic;
using static Chess.Squares;
namespace Chess
{
    public class Rook : Piece
    {
        static Rook() { movesLookUp = generateLookUp(); }

        public Rook(bool color)
        {
            this.color = color;

            if (color == true)
            {
                this.bb = (Squares.FILE_A | Squares.FILE_H) & Squares.RANK_1;
            }
            else
            {
                this.bb = (Squares.FILE_A | Squares.FILE_H) & Squares.RANK_8;
            }

            this.value = 5;
        }

        public static long[] generateLookUp()
        {
            long[] rookMoves = new long[64];

            long piecePosition;
            long pieceRank;
            long pieceFile;
            long possibleMoves;
            long newLocation;

            for (int index = 0; index < 64; index++)
            {
                piecePosition = 1L << index;
                pieceRank = Squares.bitboardToRank(piecePosition);
                pieceFile = Squares.bitboardToFile(piecePosition);

                possibleMoves = 0L;
                newLocation = 0L;

                // All horizontal and vertical moves
                newLocation = (piecePosition ^ pieceRank) | (piecePosition ^ pieceFile);

                // Add bitboard to possible moves
                possibleMoves += newLocation;

                // As the index of A1 is 0, we assign to the list in decreasing order
                rookMoves[63 - index] = possibleMoves;
            }
            return rookMoves;
        }
    }
}