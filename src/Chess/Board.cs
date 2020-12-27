using System;
using System.Linq;
using System.Text;

namespace Chess
{
    /// <summary>
    /// Main class for initializing chess board.
    /// A chess board contains bitboards from each piece type.
    /// Bitboards are longs. Let a bitboard be a string of bits indexed from 0 to 64, then 
    /// the graphic rep of the board is:
    ///
    /// 07 06 05 04 03 02 01 00  
    /// 15 14 13 12 11 10 09 08
    /// ...
    /// 63 62 61 60 59 58 57 56
    /// </summary>
    public class Board
    {
        public King WK = new King(true, 0L);
        public Queen WQ = new Queen(true, 0L);
        public Rook WR = new Rook(true, 0L);
        public Bishop WB = new Bishop(true, 0L);
        public Knight WN = new Knight(true, 0L);
        public Pawn WP = new Pawn(true, 0L);
        public King BK = new King(false, 0L);
        public Queen BQ = new Queen(false, 0L);
        public Rook BR = new Rook(false, 0L);
        public Bishop BB = new Bishop(false, 0L);
        public Knight BN = new Knight(false, 0L);
        public Pawn BP = new Pawn(false, 0L);
        public static string[,] chessBoard = new string[8,8];
        private static string stringBoard;
        private static int stringLengthDif;

        /// <summary>
        /// Initializes board in starting positions
        /// </summary>
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
            arrayToBitboards(initialChessBoard);

        }

        /// <summary>
        /// <param name="chessBoard"> Array of chars in starting position in graphic representation (as above). Uppercase indicate  white, lowercase black pieces.</param>
        /// Method iterates through char array and adds a piece to the bitboard according to its graphic rep.
        /// </summary>
        public void arrayToBitboards(char[,] chessBoard, King WK, Queen WQ, Rook WR, Knight WN, Bishop WB, Pawn WP, King BK, Queen BQ, Rook BR, Knight BN, Bishop BB, Pawn BP)
        {
            for(int i = 0; i < 64; i++)
            {
                var bin = "0000000000000000000000000000000000000000000000000000000000000000"; 
                bin = bin.Substring(i+1) + "1" + bin.Substring(0, i);

                switch(chessBoard[i / 8, i % 8])
                {
                    case 'r': BR.bb += convertStringToBitboard(bin);
                        break;
                    case 'n': BN.bb += convertStringToBitboard(bin);
                        break;
                    case 'b': BB.bb += convertStringToBitboard(bin);
                        break;
                    case 'q': BQ.bb += convertStringToBitboard(bin);
                        break;
                    case 'k': BK.bb += convertStringToBitboard(bin);
                        break;
                    case 'p': BP.bb += convertStringToBitboard(bin);
                        break;
                    case 'R': WR.bb += convertStringToBitboard(bin);
                        break;
                    case 'N': WN.bb += convertStringToBitboard(bin);
                        break;
                    case 'B': WB.bb += convertStringToBitboard(bin);
                        break;
                    case 'Q': WQ.bb += convertStringToBitboard(bin);
                        break;
                    case 'K': WK.bb += convertStringToBitboard(bin);
                        break;
                    case 'P': WP.bb += convertStringToBitboard(bin);
                        break;
                }
            }
            drawBoardArray(WK, WQ, WR, WN, WB, WP, BK, BQ, BR, BN, BB, BP);
        }

        /// <summary>
        /// <param name="bin"> String of 0s and 1s of length 64.</param>
        /// Returns a long.
        /// </summary>
        private long convertStringToBitboard(string bin)
        {
            return Convert.ToInt64(bin, 2);
        }

        /// <summary>
        /// <param name="chessBoard"> Array of chars in starting position in graphic representation (as above). Uppercase indicate  white, lowercase black pieces.</param>
        /// Takes pieces as params to initialize their bitboards (referred to as bb).
        /// Method iterates through char array and adds a piece to the bitboard according to its graphic rep.
        /// </summary>
        public static void drawBoardArray(King WK, Queen WQ, Rook WR, Knight WN, Bishop WB, Pawn WP, King BK, Queen BQ, Rook BR, Knight BN, Bishop BB, Pawn BP)
        {
            for(int i = 0; i < 64; i++)
            {
                if (((WK.bb>>i)&1)==1) { chessBoard[i / 8, i % 8] = "K"; }
                if (((WQ.bb>>i)&1)==1) { chessBoard[i / 8, i % 8] = "Q"; } 
                if (((WR.bb>>i)&1)==1) { chessBoard[i / 8, i % 8] = "R"; } 
                if (((WN.bb>>i)&1)==1) { chessBoard[i / 8, i % 8] = "N"; } 
                if (((WB.bb>>i)&1)==1) { chessBoard[i / 8, i % 8] = "B"; } 
                if (((WP.bb>>i)&1)==1) { chessBoard[i / 8, i % 8] = "P"; } 
                if (((BK.bb>>i)&1)==1) { chessBoard[i / 8, i % 8] = "k"; } 
                if (((BQ.bb>>i)&1)==1) { chessBoard[i / 8, i % 8] = "q"; } 
                if (((BR.bb>>i)&1)==1) { chessBoard[i / 8, i % 8] = "r"; } 
                if (((BN.bb>>i)&1)==1) { chessBoard[i / 8, i % 8] = "n"; } 
                if (((BB.bb>>i)&1)==1) { chessBoard[i / 8, i % 8] = "b"; } 
                if (((BP.bb>>i)&1)==1) { chessBoard[i / 8, i % 8] = "p"; } 

                if (String.IsNullOrEmpty(chessBoard[i / 8, i % 8])){chessBoard[i / 8, i % 8] = " ";}
            }
            printChessBoard(chessBoard);

            for(int i = 0; i < 64; i++)
            {
                Console.WriteLine("Iteration: " + i.ToString());
                intToBoard(Bishop.movesLookUp[i]);

            }
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

        public static void intToBoard(long bb)
        {
            if(bb < 0)
            {
                stringBoard = Convert.ToString(bb, 2);  
            }
            else
            {
                stringBoard = Convert.ToString(bb, 2);
                
                stringLengthDif = 64 - stringBoard.Length;
                if(stringLengthDif != 0)
                {
                    stringBoard = string.Concat(Enumerable.Repeat("0", stringLengthDif)) + stringBoard;
                }
            }
            
            Console.WriteLine(stringBoard.Length);
            for(int i=0; i<8; i++)
            {
                string str = Reverse(stringBoard.Substring(i*8,8));
                Console.WriteLine(str);
            }
        }

        public static string Reverse( string s )
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse( charArray );
            return new string( charArray );
        }
    }
}