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
            if(color == true)
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

            for (int index = 0; index < 64; index++)
            {
                piecePosition = 1L << index;
                possibleMoves = 0L;
                newLocation = 0L;
                
                // Diagonal moves. Any piece can maximum move 7 steps in any direction 
                for(int factor = 1; factor < 8; factor++)
                {
                    // Go up & right, we shift right by 9
                    newLocation = piecePosition<<(factor*9);  

                    // If we did not move off the board, add new location to possibleMoves       
                    if((index % 8) < ((index + factor * 9) % 8))
                    {                 
                        // if(index == 63) { newLocation = -newLocation; }
                        possibleMoves += newLocation; 
                    }

                    // Go up & left, we shift right by 7
                    newLocation = piecePosition<<(factor * 7);            
                    if((index % 8) > ((index + factor * 7) % 8)) 
                    {                 
                        // if(index == 63) { newLocation = -newLocation; }
                        possibleMoves += newLocation; 
                    }

                    // Go down & right, we shift left by 7
                    newLocation = piecePosition>>(factor * 7);            
                    if((index % 8) < ((index + factor * 7) % 8)) 
                    {                 
                        // if(index == 63) { newLocation = -newLocation; }
                        possibleMoves += newLocation; 
                    }

                    // Go down & left, we shift left by 9
                    newLocation = piecePosition>>(factor * 9);            
                    if((index % 8) > ((index + factor * 9) % 8)) 
                    {                 
                        // if(index == 63) { newLocation = -newLocation; }
                        possibleMoves += newLocation; 
                    }
                }
                bishopMoves[63 - index] = possibleMoves;
            }
            return bishopMoves;
        }
    }
}