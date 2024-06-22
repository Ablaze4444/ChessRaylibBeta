using Raylib_cs;
using System.Runtime.CompilerServices;

namespace ChessRaylibBeta;

public static class PieceMovementManager
{
    public static int mouseXPos = 0;
    public static int mouseYPos = 0;
    public static int mouseBoardXPos = 0;
    public static int mouseBoardYPos = 0;
    public static int pieceCurrentlyMoving = 0;
    public static int OriginalPiecePositionX = 0;
    public static int OriginalPiecePositionY = 0;
    public static bool mouseIsOnBoard = false;

    

    public static void MouseUpdatePosition(int BoardScreenXOffset, int BoardScreenYOffset, int CellSize, int BoardXCount, int BoardYCount)
    {
        mouseXPos = Raylib.GetMouseX();
        mouseYPos = Raylib.GetMouseY();
        BoardSquareCoordinate(BoardScreenXOffset, BoardScreenYOffset, CellSize);
        MouseOnGridCheck(BoardScreenXOffset, BoardScreenYOffset, BoardXCount,BoardYCount, CellSize);
        
    }

    public static void BoardSquareCoordinate(int BoardScreenXOffset, int BoardScreenYOffset, int CellSize)
    {
        mouseBoardXPos = (mouseXPos - BoardScreenXOffset) / CellSize;
        mouseBoardYPos = (mouseYPos - BoardScreenYOffset) / CellSize;
        
    }

    public static bool MouseOnGridCheck(int BoardScreenXOffset, int BoardScreenYOffset, int BoardXCount, int BoardYCount, int CellSize)
    {
        mouseIsOnBoard = (mouseXPos >= BoardScreenXOffset && mouseXPos < BoardScreenXOffset + (BoardXCount * CellSize) && mouseYPos >= BoardScreenYOffset && mouseYPos < BoardScreenYOffset + (BoardYCount * CellSize));
        return mouseIsOnBoard;
    }

    public static void PawnPlacer2000(Board board, int pieceSet)
    {
        if (Raylib.IsMouseButtonPressed(MouseButton.Left))
        {
            board.SetCell(mouseBoardXPos, mouseBoardYPos, pieceSet);

        }
    }

    public static void PieceDraggingHandler(Board board)
    {
        
        if (Raylib.IsMouseButtonPressed(MouseButton.Left) && mouseIsOnBoard == true && board.GetCell(mouseBoardXPos, mouseBoardYPos) > 0)
        {
            OriginalPiecePositionX = mouseBoardXPos;
            OriginalPiecePositionY = mouseBoardYPos;
            pieceCurrentlyMoving = board.GetCell(mouseBoardXPos, mouseBoardYPos);
            board.SetCell(OriginalPiecePositionX, OriginalPiecePositionY, 0);
        }
        

        if(Raylib.IsMouseButtonDown(MouseButton.Left) && mouseIsOnBoard == true)
        {

        }

        if (Raylib.IsMouseButtonReleased(MouseButton.Left) && mouseIsOnBoard == true && pieceCurrentlyMoving > 0)
        {
            board.SetCell(mouseBoardXPos, mouseBoardYPos, pieceCurrentlyMoving);
            pieceCurrentlyMoving = 0;

        }
        else if (Raylib.IsMouseButtonReleased(MouseButton.Left) && mouseIsOnBoard == false && pieceCurrentlyMoving > 0)
        {
            board.SetCell(OriginalPiecePositionX, OriginalPiecePositionY, pieceCurrentlyMoving);
            pieceCurrentlyMoving = 0;
        }
    }
}