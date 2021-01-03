using System;
using System.Collections.Generic;

namespace Chess
{
    public class Pawn : Piece
    {
        private static Int64 startPosition = 0L;
        private static long startRank = 0L;
        private static long startFile = 0L;
        private static long possibleMoves = 0L;
        private static long newLocation = 0L;
        private static bool offBoardUpLeft = false;
        private static bool offBoardUpRight = false;

        static Pawn() { movesLookUp = generateLookUp(); }

        public Pawn(bool color)
        {
            this.color = color;

            if (color == true)
            {
                this.bb = Squares.RANK_2;
            }
            else
            {
                this.bb = Squares.RANK_7;
            }


            this.value = 1;
        }

        public static long[] generateLookUp()
        {
            long[] pawnMoves = new long[64];

            for (int i = 0; i < 64; i++)
            {
                startPosition = 1L << i;
                startRank = Squares.bitboardToRank(startPosition);
                startFile = Squares.bitboardToFile(startPosition);

                possibleMoves = 0L;
                newLocation = 0L;

                // A pawn can at maximum move two steps ahead

                // If white
                /*
                if(this.color == true)
                {
                    if (startRank == 2)
                    {
                        for (int j = 1; j < 3; j++)
                        {
                            newLocation = startPosition << (j * 8);
                            possibleMoves += newLocation;
                        }
                    }
                    else
                    {
                        //Promotions 
                        newLocation = startPosition << 8;
                        possibleMoves += newLocation;
                    }

                    // Captures and en pasant
                }

                if (i == 63) { newLocation = -newLocation; }
                possibleMoves += newLocation;
            */
            }
            return movesLookUp;
        }
    }
}