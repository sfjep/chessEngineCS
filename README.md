# chessEngine
Sources of inspiration:
- Logic Crazy Chess videos
- https://www.gamedev.net/tutorials/_/technical/artificial-intelligence/chess-programming-part-i-getting-started-r1014/
- https://www.cs.cornell.edu/boom/2004sp/ProjectArch/Chess/algorithms.html

Notes to self:

Classes for
- Pieces
- Board
- Moves


States:
- Check
- Castles (king/queenside)
- Castles not possible due to check, moved rock, moved king, covered square
- En passant
- Pawn moved, only one-step
- Pawn move two steps from beginning
- Fifty move rule
- 3-fold repitition
- Stalemate

6 + 6 = 12 bitboards needed for any position:
Black: 6
    Pawn
    Knight
    Bishop
    Rook
    Queen
    King
White: 6

Why bitboards:
- Efficient on 64-bit tech
    One array takes more space than 12 bitboards.
- Shifting binaries and math operations on binaries is easy for computers 
    Benefit being possible sample space for moves of chess pieces
