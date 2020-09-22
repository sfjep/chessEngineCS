using System;
using System.Collections.Generic;

namespace Chess
{
    public class King : Piece
    {
        List<Moves> kingMoves = new List<Moves>();
        public bool checkmate;
        public bool notMoved;
        public bool notInCheck;
        public bool queensideRookNotMoved;
        public bool kingsideRookNotMoved;

        public King(bool color, long bb)
        {
            this.color = color;
            this.bb = bb;
            this.checkmate = false;
            this.notMoved = true;
            this.notInCheck = true;
            this.queensideRookNotMoved = true;
            this.kingsideRookNotMoved = true;
        }

        public override List<Moves> generateMoves()
        {
            if(this.checkmate == false)
            {
                // queenside possible?
                if(castlePossible(true))
                {
                    
                }
                // kingside possible?
                if(castlePossible(false))
                {
                    
                }
            }
            return kingMoves;
        }

        private bool castlePossible(bool queenside)
        {
            // King not moved, not in check, rook not moved, castling squares not occupied or attacked
            if(this.notMoved && this.notInCheck && rookNotMoved(queenside) && castlingSquaresNotOccupied(queenside) && castlingSquaresNotCoveredByOpponent(queenside))
            {
                return true;
            }
            return false;
        }

        private bool castlingSquaresNotOccupied(bool queenside)
        {
            if(queenside)
            {
                // is the squares NOT occupied on the queenside
                return true;
            }
            else if(!queenside)
            {
                return true;
            }
            return false;
        }

        private bool castlingSquaresNotCoveredByOpponent(bool queenside)
        {
            if(queenside)
            {
                // is the squares NOT covered by opponent on the queenside
                return true;
            }
            else if(!queenside)
            {
                return true;
            }
            return false;
        }

        private bool rookNotMoved(bool queenside)
        {
            // update if any rook has moved
            checkBoardForRookMoves();

            if(queenside && this.queensideRookNotMoved)
            {
                return true;
            }
            else if(!queenside && this.kingsideRookNotMoved)
            {
                return true;
            }
            return false;
        }

        private void checkBoardForRookMoves()
        {
            if(this.queensideRookNotMoved)
            {
                if(Board.chessBoard[7,0] != "R" && this.color == true)
                {
                    this.queensideRookNotMoved = false; 
                }
                if(Board.chessBoard[0,0] != "r" && this.color == false)
                {
                    this.queensideRookNotMoved = false; 
                }
            }

            if(this.kingsideRookNotMoved)
            {
                if(Board.chessBoard[7,7] != "R" && this.color == true)
                {
                    this.kingsideRookNotMoved = false; 
                }

                if(Board.chessBoard[0,7] != "r" && this.color == false)
                {
                    this.kingsideRookNotMoved = false; 
                }
            }
        }
    }
}