using System;
using System.Linq;
using System.Text;

namespace Chess
{
    /// <summary>
    /// Main class for initializing chess board.
    /// A chess board contains bitboards from each piece type.
    /// Bitboards are longs. Let a bitboard be a string of bits indexed from 0 to 63, then 
    /// the graphic rep of the board is:
    ///
    /// 00 01 02 03 04 05 06 07  
    /// 08 09 10 11 12 13 14 15
    /// ...
    /// 56 57 58 59 60 61 62 63
    ///
    /// 00 is square A8, 63 is square H1
    /// </summary>
    public class Board
    {
        /// <summary>
        /// Instanciate pieces 
        /// </summary>
        public King WK = new King(true);
        public Queen WQ = new Queen(true);
        public Rook WR = new Rook(true);
        public Bishop WB = new Bishop(true);
        public Knight WN = new Knight(true);
        public Pawn WP = new Pawn(true);
        public King BK = new King(false);
        public Queen BQ = new Queen(false);
        public Rook BR = new Rook(false);
        public Bishop BB = new Bishop(false);
        public Knight BN = new Knight(false);
        public Pawn BP = new Pawn(false);

        public static string[,] charBoard = new string[8, 8];
        private static int stringLengthDif;

        /// <summary>
        /// Initializes board in starting positions
        /// </summary>
        public Board()
        {            
            
        }

        /// <summary>
        /// <param name="bin"> String of 0s and 1s of length 64.</param>
        /// Returns a long.
        /// </summary>
        private static long convertStringToBitboard(string bin)
        {
            return Convert.ToInt64(bin, 2);
        }

        /// <summary>
        /// Converts a board (set of bitboards) into an array of chars for graphical rep
        /// </summary>
        public void drawBoardArray()
        {
            for (int i = 0; i < 64; i++)
            {
                if (((WK.bb >> i) & 1) == 1) { charBoard[i / 8, i % 8] = "K"; }
                if (((WQ.bb >> i) & 1) == 1) { charBoard[i / 8, i % 8] = "Q"; }
                if (((WR.bb >> i) & 1) == 1) { charBoard[i / 8, i % 8] = "R"; }
                if (((WN.bb >> i) & 1) == 1) { charBoard[i / 8, i % 8] = "N"; }
                if (((WB.bb >> i) & 1) == 1) { charBoard[i / 8, i % 8] = "B"; }
                if (((WP.bb >> i) & 1) == 1) { charBoard[i / 8, i % 8] = "P"; }
                if (((BK.bb >> i) & 1) == 1) { charBoard[i / 8, i % 8] = "k"; }
                if (((BQ.bb >> i) & 1) == 1) { charBoard[i / 8, i % 8] = "q"; }
                if (((BR.bb >> i) & 1) == 1) { charBoard[i / 8, i % 8] = "r"; }
                if (((BN.bb >> i) & 1) == 1) { charBoard[i / 8, i % 8] = "n"; }
                if (((BB.bb >> i) & 1) == 1) { charBoard[i / 8, i % 8] = "b"; }
                if (((BP.bb >> i) & 1) == 1) { charBoard[i / 8, i % 8] = "p"; }

                if (String.IsNullOrEmpty(charBoard[i / 8, i % 8])) { charBoard[i / 8, i % 8] = " "; }
            }
            printCharBoard();

            
        }

        /// <summary>
        /// Prints graphical rep of the board in the console
        /// </summary>
        public void printCharBoard()
        {
            for (int i = 0; i < charBoard.GetLength(0); i++)
            {
                for (int j = 0; j < charBoard.GetLength(1); j++)
                {
                    Console.Write(charBoard[i, j] + ",");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Prints graphical rep of a bitboard in the console
        /// </summary>
        public static void printBitBoard(long bb)
        {
            String stringBoard;
            if (bb < 0)
            {
                stringBoard = Convert.ToString(bb, 2);
            }
            else
            {
                stringBoard = Convert.ToString(bb, 2);

                stringLengthDif = 64 - stringBoard.Length;
                if (stringLengthDif != 0)
                {
                    stringBoard = string.Concat(Enumerable.Repeat("0", stringLengthDif)) + stringBoard;
                }

            }

            for (int i = 0; i < 8; i++)
            {
                int length = stringBoard.Length;
                string str = stringBoard.Substring(56-(i * 8), 8);
                Console.WriteLine(str);
            }
        }            
    }
}