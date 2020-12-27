using System;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            Board.printBitBoard(board.WP.bb);
        }
    }
}
