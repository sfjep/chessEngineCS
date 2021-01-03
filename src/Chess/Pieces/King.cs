using System;
using System.Collections.Generic;
using static Chess.Squares;

namespace Chess
{
    public class King : Piece
    {
        public bool checkmate;
        public bool notMoved;
        public bool notInCheck;
        public bool queensideRookNotMoved;
        public bool kingsideRookNotMoved;

        static King() { movesLookUp = generateLookUp(); }

        public King(bool color)
        {
            this.color = color;

            if (color == true)
            {
                this.bb = Squares.FILE_E & Squares.RANK_1;
            }
            else
            {
                this.bb = Squares.FILE_E & Squares.RANK_8;
            }

            this.checkmate = false;
            this.notMoved = true;
            this.notInCheck = true;
            this.queensideRookNotMoved = true;
            this.kingsideRookNotMoved = true;
        }

        public static long[] generateLookUp()
        {
            return movesLookUp;
        }

        public long moveGeneration()
        {
            if (this.checkmate == false)
            {
                // queenside possible?
                if (castlePossible(true))
                {

                }
                // kingside possible?
                if (castlePossible(false))
                {

                }
            }

            return 0L;
        }
        private bool castlePossible(bool queenside)
        {
            // King not moved, not in check, rook not moved, castling squares not occupied or attacked
            if (this.notMoved && this.notInCheck && rookNotMoved(queenside) && castlingSquaresNotOccupied(queenside) && castlingSquaresNotCoveredByOpponent(queenside))
            {
                return true;
            }
            return false;
        }

        private bool castlingSquaresNotOccupied(bool queenside)
        {
            if (queenside)
            {
                // is the squares NOT occupied on the queenside
                return true;
            }
            else if (!queenside)
            {
                return true;
            }
            return false;
        }

        private bool castlingSquaresNotCoveredByOpponent(bool queenside)
        {
            if (queenside)
            {
                // is the squares NOT covered by opponent on the queenside
                return true;
            }
            else if (!queenside)
            {
                return true;
            }
            return false;
        }

        private bool rookNotMoved(bool queenside)
        {
            // update if any rook has moved
            checkBoardForRookMoves();

            if (queenside && this.queensideRookNotMoved)
            {
                return true;
            }
            else if (!queenside && this.kingsideRookNotMoved)
            {
                return true;
            }
            return false;
        }

        private void checkBoardForRookMoves()
        {
            if (this.queensideRookNotMoved)
            {
                if (Board.charBoard[7, 0] != "R" && this.color == true)
                {
                    this.queensideRookNotMoved = false;
                }
                if (Board.charBoard[0, 0] != "r" && this.color == false)
                {
                    this.queensideRookNotMoved = false;
                }
            }

            if (this.kingsideRookNotMoved)
            {
                if (Board.charBoard[7, 7] != "R" && this.color == true)
                {
                    this.kingsideRookNotMoved = false;
                }

                if (Board.charBoard[0, 7] != "r" && this.color == false)
                {
                    this.kingsideRookNotMoved = false;
                }
            }
        }
    }
}