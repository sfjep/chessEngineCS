using System;
using System.Runtime.InteropServices;
using System.Linq;

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
            arrayToBitboards(initialChessBoard, WK, WQ, WR, WN, WB, WP, BK, BQ, BR, BN, BB, BP);
        }

        public void arrayToBitboards(char[,] chessBoard, long WK, long WQ, long WR, long WN, long WB, long WP, long BK, long BQ, long BR, long BN, long BB, long BP)
        {
            for(int i = 0; i < 64; i++)
            {
                var bin = "0000000000000000000000000000000000000000000000000000000000000000"; 
                bin = bin.Substring(i+1) + "1" + bin.Substring(0, i);

                switch(chessBoard[i / 8, i % 8])
                {
                    case 'r': BR += convertStringToBitboard(bin);
                        break;
                    case 'n': BN += convertStringToBitboard(bin);
                        break;
                    case 'b': BB += convertStringToBitboard(bin);
                        break;
                    case 'q': BQ += convertStringToBitboard(bin);
                        break;
                    case 'k': BK += convertStringToBitboard(bin);
                        break;
                    case 'p': BP += convertStringToBitboard(bin);
                        break;
                    case 'R': WR += convertStringToBitboard(bin);
                        break;
                    case 'N': WN += convertStringToBitboard(bin);
                        break;
                    case 'B': WB += convertStringToBitboard(bin);
                        break;
                    case 'Q': WQ += convertStringToBitboard(bin);
                        break;
                    case 'K': WK += convertStringToBitboard(bin);
                        break;
                    case 'P': WP += convertStringToBitboard(bin);
                        break;
                   
                }
            }
            drawBoardArray(WK, WQ, WR, WN, WB, WP, BK, BQ, BR, BN, BB, BP);
        }

        private long convertStringToBitboard(string bin)
        {
            return Convert.ToInt64(bin, 2);
        }

        public static void drawBoardArray(long WK, long WQ, long WR, long WN, long WB, long WP, long BK, long BQ, long BR, long BN, long BB, long BP)
        {
            string[,] chessBoard = new string[8,8];

            for(int i = 0; i < 64; i++)
            {
                if (((WK>>i)&1)==1) { chessBoard[i / 8, i % 8] = "K"; }
                if (((WQ>>i)&1)==1) { chessBoard[i / 8, i % 8] = "Q"; } 
                if (((WR>>i)&1)==1) { chessBoard[i / 8, i % 8] = "R"; } 
                if (((WN>>i)&1)==1) { chessBoard[i / 8, i % 8] = "N"; } 
                if (((WB>>i)&1)==1) { chessBoard[i / 8, i % 8] = "B"; } 
                if (((WP>>i)&1)==1) { chessBoard[i / 8, i % 8] = "P"; } 
                if (((BK>>i)&1)==1) { chessBoard[i / 8, i % 8] = "k"; } 
                if (((BQ>>i)&1)==1) { chessBoard[i / 8, i % 8] = "q"; } 
                if (((BR>>i)&1)==1) { chessBoard[i / 8, i % 8] = "r"; } 
                if (((BN>>i)&1)==1) { chessBoard[i / 8, i % 8] = "n"; } 
                if (((BB>>i)&1)==1) { chessBoard[i / 8, i % 8] = "b"; } 
                if (((BP>>i)&1)==1) { chessBoard[i / 8, i % 8] = "p"; } 
                
                if (String.IsNullOrEmpty(chessBoard[i / 8, i % 8])){chessBoard[i / 8, i % 8] = " ";}
            }

            printChessBoard(chessBoard);

        }
        public static void printChessBoard<T>(T[,] chessBoard)
        {
            for (int i = 0; i < chessBoard.GetLength(0); i++)
            {
                for (int j = 0; j < chessBoard.GetLength(1); j++)
                {
                    Console.Write(chessBoard[i,j] + ",");
                }
                Console.WriteLine();
            }
        }
    }
}