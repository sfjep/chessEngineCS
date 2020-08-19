using System;

namespace Chess
{
    public class Board
    {
        public long WK = 0L, WQ = 0L, WR = 0L, WN = 0L, WB = 0L, WP = 0L, BK = 0L, BQ = 0L, BR = 0L, BN = 0L, BB = 0L, BP = 0L;

        public Board()
        {
            char[,] initialChessBoard = {
                {'r', 'n', 'b', 'q', 'k', 'b', 'n', 'r'},
                {'p', 'p', 'p', 'p', 'p', 'p', 'p', 'p'},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {'P', 'P', 'P', 'P', 'P', 'P', 'P', 'P'},
                {'R', 'N', 'B', 'Q', 'K', 'B', 'N', 'R'}  
            };
        }

        private void arrayToBitboards(char[,] initialChessBoard, long WK, long WQ, long WR, long WN, long WB, long WP, long BK, long BQ, long BR, long BN, long BB, long BP)
        {
            var bin = "000000000000000000000000000000000000000000000000000000000000000";

            for(int i = 0; i < 64; i++)
            {
                switch(initialChessBoard[i / 8, i % 8])
                {
                    case 'r': 
                        break;
                }
            }
        }
    }
}