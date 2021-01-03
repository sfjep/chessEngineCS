using System;
using System.Collections.Generic;

namespace Chess
{
    public class Pawn : Piece
    {
        public new static long[] movesLookUp = generateLookUp();
        public int value;
        private static Int64 startPosition = 0L;
        private static long startRank = 0L;
        private static long startFile = 0L;
        private static long  possibleMoves = 0L;
        private static long  newLocation = 0L;
        private static bool offBoardUpLeft = false;
        private static bool offBoardUpRight = false;

        public Pawn(bool color, long bb)
        {
            this.color = color;
            this.bb = bb;
            this.value = 1;
        }

        public static long[] generateLookUp()
        {
            long[] pawnMoves = new long[64];

            for(int i = 0; i < 64; i++)
            {
                startPosition = 1L<<i;
                startRank = Rank.bbRank(startPosition);
                startFile = File.bbFile(startPosition);

                possibleMoves = 0L;
                newLocation = 0L;

                // A pawn can at maximum move two steps ahead
                              
                // If white
                if(this.color == true)
                {
                    if(startRank == 2)
                    {
                        for(int j = 1; j < 3; j++)
                        {
                            newLocation = startPosition<<(j*8);
                            possibleMoves += newLocation;
                        }
                    }
                    else
                    {
                        //Promotions 
                        newLocation = startPosition<<8;
                        possibleMoves += newLocation;
                    }

                    // Captures and en pasant
                }


                    // If white and pawn still on second rank, two moves forward is possible
                    if(j == 2 && startRank == 2 && this.color == true)
                    {
                        newLocation = startPosition<<(j*8);
                        possibleMoves += newLocation;
                    }
                    // If black and the pawn is still on the 7th rank
                    else if(j == 2 && startRank == 7 && this.color == false)
                    {
                        newLocation = startPosition>>(j*8);
                        possibleMoves += newLocation;
                    }
                    

                    newLocation = startPosition<<(j*8);
                    if(i == 63) { newLocation = -newLocation; }
                    possibleMoves += newLocation;
            }
            return movesLookUp;
        }
    }
}