
using Raylib_cs;
using static System.Net.Mime.MediaTypeNames;
using System;

namespace ChessRaylibBeta;

class Program
{
    static int ScreenWidth = 1600;
    static int ScreenHeight = 900;
    static int BoardXOffset = 400;
    static int BoardYOffset = 40;
    static int BoardSquareSize = 100;
    static int BoardSquareXCount = 8;
    static int BoardSquareYCount = 8;
    
    static Board MainBoard = new Board();
    public static void Main()
    {
        Raylib.InitWindow(ScreenWidth, ScreenHeight, "Chess Beta");
        BoardRenderer.LoadTextures();

        MainBoard.BoardReset();

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            PieceMovementManager.MouseUpdatePosition(BoardXOffset, BoardYOffset, BoardSquareSize, BoardSquareXCount,BoardSquareYCount);
            
            Raylib.ClearBackground(Color.DarkBlue);

            Console.WriteLine(PieceMovementManager.mouseIsOnBoard);
            Console.WriteLine("Original X Pos " + PieceMovementManager.OriginalPiecePositionX + " Original Y Pos " +PieceMovementManager.OriginalPiecePositionY + " ID " + PieceMovementManager.pieceCurrentlyMoving);

            BoardRenderer.DrawBoard(BoardXOffset,BoardYOffset, MainBoard.BoardGrid, BoardSquareSize);
            PieceMovementManager.PieceDraggingHandler(MainBoard);
            
            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
 
}
