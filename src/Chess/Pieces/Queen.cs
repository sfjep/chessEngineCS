using System;
using System.Collections.Generic;

namespace Chess
{
    public class Queen : Piece
    {
        public new static long[] movesLookUp = generateLookUp();
        public int value;

        public Queen(bool color)
        {
            this.color = color;
            
            if(color == true)
            {
                this.bb = Squares.FILE_D & Squares.RANK_1;
            }
            else
            {
                this.bb = Squares.FILE_D & Squares.RANK_8;
            }

            this.value = 9;
        }

        /// <summary>
        /// "queenMoves": An array of bitboard of length 64. Each element represents possible moves from position i.
        /// "piecePosition": Bitboard of possible locations on the board.
        /// "pieceRank": Bitboard of the rank of the piece location.
        /// "pieceFile": Bitboard of filee of the piece location.
        /// "possibleMoves": Bitboard of possible moves from a given location.
        /// "newLocation": Bitboard of the new location after the move from starting location.
        /// 
        /// For each of the 64 possible locations for the queen, we gather all the squares the queen can move to
        /// Horizontal and vertical moves are found using pieceRank and pieceFile
        /// Diagonal moves are found by shifting by an offset of 7 or 9 scaled by a factor from 1-7, as a piece can only move 7 steps in any direction 
        /// For each index, we take modulo 8. This gives us the file number with 0-index. 
        /// Say the queen moves up and to the right. The index of the new location must have a modulo greater than the starting point.
        /// Otherwise, the queen moved off the board, and ended up on the A-file. 
        /// The modulo must be less than the starting point if moving up and left. 
        /// </summary>
        public static long[] generateLookUp()
        {
            long[] queenMoves = new long[64];
            long piecePosition;
            long pieceRank;
            long pieceFile;
            long possibleMoves;
            long newLocation;
            
            for(int index = 0; index < 64; index++)
            {
                piecePosition = 1L<<index;
                pieceRank = Squares.bitboardToRank(piecePosition);
                pieceFile = Squares.bitboardToFile(piecePosition);

                possibleMoves = 0L;
                newLocation = 0L;
                
                // All horizontal and vertical moves
                newLocation = (piecePosition ^ pieceRank) | (piecePosition ^ pieceFile);
                
                // If last iteration, wrong sign - change to positive
                // if(index == 63) { newLocation = -newLocation; }

                // Add bitboard to possible moves
                possibleMoves += newLocation;

                // Diagonal moves. Any piece can maximum move 7 steps in any direction 
                for(int factor = 1; factor < 8; factor++)
                {
                    // Go up & right, we shift right by 9
                    newLocation = piecePosition>>(factor*9);  

                    // If we did not move off the board, add new location to possibleMoves       
                    if((index % 8) > ((index + factor * 9) % 8))
                    {                 
                        // if(index == 63) { newLocation = -newLocation; }
                        possibleMoves += newLocation; 
                    }

                    // Go up & left, we shift right by 7
                    newLocation = piecePosition>>(factor * 7);            
                    if((index % 8) < ((index + factor * 7) % 8)) 
                    {                 
                        // if(index == 63) { newLocation = -newLocation; }
                        possibleMoves += newLocation; 
                    }

                    // Go down & right, we shift left by 7
                    newLocation = piecePosition<<(factor * 7);            
                    if((index % 8) < ((index + factor * 7) % 8)) 
                    {                 
                        // if(index == 63) { newLocation = -newLocation; }
                        possibleMoves += newLocation; 
                    }

                    // Go down & left, we shift left by 9
                    newLocation = piecePosition<<(factor * 9);            
                    if((index % 8) < ((index + factor * 9) % 8)) 
                    {                 
                        // if(index == 63) { newLocation = -newLocation; }
                        possibleMoves += newLocation; 
                    }           
                }  
                queenMoves[63-index] = possibleMoves;
            }
            
            return queenMoves;
        }
    }
}