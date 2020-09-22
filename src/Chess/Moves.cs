using System;
using System.Collections.Generic;

namespace Chess
{
    public class Moves
    {
        static int positionWK, positionBK;
        public List<long> movesWK = new List<long>();
        public List<long> movesWQ = new List<long>();
        public List<long> movesWR = new List<long>();
        public List<long> movesWB = new List<long>();
        public List<long> movesWN = new List<long>();
        public List<long> movesWP = new List<long>();
        
        public List<long> allMoves = new List<long>();

        public static String possibleMoves(char[,] chessBoard)
        {
            var moves = "";

            for (int i = 0; i < 64; i++)
            {
                switch (chessBoard[i / 8, i % 8])
                {
                    case 'P': moves += pawnMoves(i);;
                        break;
                    case 'K': moves += kingMoves(i, chessBoard);;
                        break;
                    case 'Q': moves += queenMoves(i);;
                        break;
                    case 'R': moves += rookMoves(i);;
                        break;
                    case 'B': moves += bishopMoves(i);;
                        break;
                    case 'N': moves += knightMoves(i);;
                        break;
                    
                }
            }
            Console.WriteLine(moves);
            return moves;
        }

        private static string knightMoves(int i)
        {
            string movesList = "";
            return movesList;
        }

        private static string bishopMoves(int i)
        {
            string movesList = "";
            return movesList;
        }

        private static string rookMoves(int i)
        {
            string movesList = "";
            return movesList;
        }

        private static string queenMoves(int i)
        {
            string movesList = "";
            return movesList;
        }

        private static string kingMoves(int i, char[,] chessBoard)
        {
            
            // ADD CASTLING LATER
            string movesList = "";
            /*
            string capturedPiece = "";

            int rank = i / 8;
            int file = i % 8;
            int newRank;
            int newFile;

            // A king has 9 moves ( the 3x3 square around him )
            for(int j = 0; j < 9; j++)
            {
                // if j == 4, j represents the kings current location
                if (j != 4) 
                {
                    // If king in the corner, handle ignore IndexOutOfRange exception
                    try{

                        newRank = rank - 1 + j / 3;
                        newFile = file - 1 + j % 3;
                            // If lower case letter (black piece) or empty field
                        if (Char.IsLower(chessBoard[newRank, newFile]) | ' '.Equals(chessBoard[newRank, newFile]))
                        {
                            // Store any piece captured, meaning in the new king position
                            capturedPiece = chessBoard[newRank, newFile].ToString();

                            // King moves, field now empty
                            chessBoard[rank, file] = ' ';

                            // King moves to new square
                            chessBoard[newRank, newFile] = 'K';
                            
                            // Store original king position and update king position
                            var tempKingPostion = positionWK;
                            positionWK = i + (j / 3) * 8 + j % 3 - 9;

                            // Check if new location is safe or not, meaning, is the captured piece or empty field covered by opponents pieces
                            if (kingInCheck())
                            {
                                if(" ".Equals(capturedPiece))
                                {
                                    movesList += "K" + fileNames[newFile] + rankNames[newRank]; 
                                }
                                else
                                {
                                    movesList += "Kx" + fileNames[newFile] + rankNames[newRank]; 
                                }
                            }
                            
                            // After storing a potentially valid move, we put the pieces back to their original location
                            chessBoard[rank, file] = 'K';
                            chessBoard[newRank, newFile] = Convert.ToChar(capturedPiece);
                            positionWK = tempKingPostion;
                        }   
                    }
                    catch (Exception e) {}
                }

            }
            */            
            return movesList;

        }
        private static string alternativeKingMoves(int i, char[,] chessBoard)
        {
            // ADD CASTLING LATER
            string movesList = "";
            
            var kingMoves = new List<int>() {9,8,7,1,-1,-7,-8,-9};
            

            return movesList;
        }
        private static bool kingInCheck()
        {
            return true;
        }

        private static string pawnMoves(int i)
        {
            string movesList = "";
            return movesList;
        }

    }
}