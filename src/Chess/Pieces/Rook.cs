using System;
using System.Collections.Generic;
using static Chess.Squares;
namespace Chess
{
    public class Rook : Piece
    {
        public new static long[] movesLookUp = generateLookUp();
        public int value;
        private static Int64 startPosition = 0L;
        private static long startRank = 0L;
        private static long startFile = 0L;
        private static long  possibleMoves = 0L;
        private static long  newLocation = 0L;


        public Rook(bool color)
        {
            this.color = color;
            
            if(color == true)
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

            for(int i = 0; i < 64; i++)
            {
                startPosition = 1L<<i;
                startRank = Squares.bitboardToRank(startPosition);
                startFile = Squares.bitboardToFile(startPosition);

                possibleMoves = 0L;
                newLocation = 0L;

                // Any piece can maximum move 7 steps in any direction 
                for(int j = 1; j < 8; j++)
                {
                    // Go left
                    newLocation = startPosition>>j;
                    if(i == 63) { newLocation = -newLocation; }
                    if((newLocation & startRank) != 0L) { possibleMoves += newLocation; }
                    
                    // Go right
                    newLocation = startPosition<<j;
                    if(i == 63) { newLocation = -newLocation; }
                    if((newLocation & startRank) != 0L) { possibleMoves += newLocation; }

                    // Go up
                    newLocation = startPosition<<(j*8);
                    if(i == 63) { newLocation = -newLocation; }
                    possibleMoves += newLocation;

                    // Go down
                    newLocation = startPosition>>(j*8);
                    if(i == 63) { newLocation = -newLocation; }
                    possibleMoves += newLocation;                           
                }   
                rookMoves[i] = possibleMoves;
            }
            return rookMoves;
        }
    }
}