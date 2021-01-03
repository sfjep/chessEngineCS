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

  
        /// <summary>
        /// "bishopMoves": An array of bitboard of length 64. Each element represents possible moves from position i.
        /// "piecePosition": Bitboard of possible locations on the board.
        /// "possibleMoves": Bitboard of possible moves from a given location.
        /// "newLocation": Bitboard of the new location after the move from starting location.
        /// 
        /// For each of the 64 possible locations for the bishop, we gather all the squares the bishop can move to
        /// Diagonal moves are found by shifting by an offset of 7 or 9 scaled by a factor from 1-7, as a piece can only move 7 steps in any direction 
        /// For each index, we take modulo 8. This gives us the file number with 0-index. 
        /// Say the queen moves up and to the right. The index of the new location must have a modulo greater than the starting point.
        /// Otherwise, the queen moved off the board, and ended up on the A-file. 
        /// The modulo must be less than the starting point if moving up and left. 
        /// </summary>
        public static long[] generateLookUp()
        {
            long[] bishopMoves = new long[64];
            long piecePosition;
            long possibleMoves;
            long newLocation;
            
            for (int i = 0; i < 64; i++)
            {
                piecePosition = 1L << (63-i);
                possibleMoves = 0L;
               
                // Diagonal moves. Any piece can maximum move 7 steps in any direction 
                for(int factor = 1; factor < 8; factor++)
                {
                    // Go up & right, we shift right by 9
                    newLocation = piecePosition>>(factor*9);  

                    // If we did not move off the board, add new location to possibleMoves       
                    if((i % 8) < ((i + factor * 9) % 8))
                    {                 
                        if(i == 0) { newLocation = -newLocation; }
                        possibleMoves += newLocation; 
                    }

                    // Go up & left, we shift right by 7
                    newLocation = piecePosition>>(factor * 7);            
                    if((i % 8) > ((i + factor * 7) % 8)) 
                    {                 
                        if(i == 0) { newLocation = -newLocation; }
                        possibleMoves += newLocation; 
                    }

                    // Go down & right, we shift left by 7
                    newLocation = piecePosition<<(factor * 7);            
                    if((i % 8) < ((i - factor * 7) % 8)) 
                    {                 
                        if(i == 0) { newLocation = -newLocation; }
                        possibleMoves += newLocation; 
                    }

                    // Go down & left, we shift left by 9
                    newLocation = piecePosition<<(factor * 9);            
                    if((i % 8) > ((i - factor * 9) % 8)) 
                    {                 
                        if(i == 0) { newLocation = -newLocation; }
                        possibleMoves += newLocation; 
                    }
                }
                bishopMoves[i] = possibleMoves;
            }
            return bishopMoves;
        }
    }
}