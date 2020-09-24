using System;
using System.Linq;
using System.Text;

namespace Chess
{
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

            // Moves.possibleMoves(initialChessBoard);


        }

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

        private long convertStringToBitboard(string bin)
        {
            return Convert.ToInt64(bin, 2);
        }

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
                Console.WriteLine(i);
                intToBoard(Queen.movesLookUp[i]);

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