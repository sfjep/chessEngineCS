using System.Collections.Generic;

namespace Chess
{
    public class Queen : Piece
    {
        public new static long[] movesLookUp = generateLookUp();
        public int value;

        public Queen(bool color, long bb)
        {
            this.color = color;
            this.bb = bb;
            this.value = 9;
        }

        public static long[] generateLookUp()
        {
            long[] queenMoves = new long[64];
            var startShift = 0;

            for(int i = 0; i < 64; i++)
            {
                var startPosition = 1L<<startShift;
                var possibleMoves = 0L;
                var newLocation = 0L;
                var offBoardUpLeft = false;
                var offBoardDownLeft = false;
                var offBoardUpRight = false;
                var offBoardDownRight = false;
                
                // Any piece can maximum move 7 steps in any direction 
                for(int j = 1; j < 8; j++)
                {
                    // Go left
                    newLocation = startPosition>>j;
                    possibleMoves += newLocation;

                    // Go right
                    newLocation = startPosition<<j;
                    possibleMoves += newLocation;

                    // Go up
                    newLocation = startPosition<<(j*8);
                    possibleMoves += newLocation;

                    // Go down
                    newLocation = startPosition>>(j*8);
                    possibleMoves += newLocation;

                    // Go up & right
                    newLocation = startPosition<<(j*9);
                    if(((newLocation & File.FILE_A) == 0L) && !offBoardUpRight) { possibleMoves += newLocation; }
                    else{ offBoardUpRight = true; }

                    // Go up & left
                    newLocation = startPosition<<(j*7);
                    if(((newLocation & File.FILE_H) == 0L) && !offBoardUpLeft) { possibleMoves += newLocation; }
                    else{ offBoardUpLeft = true; }

                    // Go down & right
                    newLocation = startPosition>>(j*7);
                    if(((newLocation & File.FILE_H) == 0L) && !offBoardDownRight) { possibleMoves += newLocation; }
                    else{ offBoardDownRight = true; }
                    
                    // Go down & left
                    newLocation = startPosition>>(j*9);
                    if(((newLocation & File.FILE_A) == 0L) && !offBoardDownLeft) { possibleMoves += newLocation; }     
                    else{ offBoardDownLeft = true; }           
                }
                queenMoves[i] = possibleMoves;
                startShift++;
            }
            return queenMoves;
        }
    }
}