
using Raylib_cs;
using static System.Net.Mime.MediaTypeNames;
using System;
using System.Numerics;

namespace ChessRaylibBeta;

class Program
{
    static Board MainBoard = new Board();
    public static void Main()
    {
        Raylib.InitWindow(1600, 900, "Chess Beta");
        BoardRenderer.LoadTextures();

        MainBoard.BoardReset();

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.DarkBlue);

            BoardRenderer.DrawBoard(400,40, MainBoard.BoardGrid);
           
            

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
 
}

public static class BoardRenderer
{
    public static Texture2D ChessPieceTexture;
    public static void LoadTextures()
    {
        ChessPieceTexture = Raylib.LoadTexture("..//..//..//images/Pieces.png");
        Raylib.SetTextureFilter(ChessPieceTexture,TextureFilter.Bilinear);
    }
    
    public static void DrawBoard( int XOffset, int YOffset, int[,] BoardState)
    {
        int colour = 1;
        for (int YPos = 0; YPos < 8; YPos++)
        {
            if(colour == 1)
            {
                colour = 0;
            }
            else
            {
                colour = 1;
            }
            for (int XPos = 0; XPos < 8; XPos++)
            {
                Color squareColor;
                Color textColor;
                if (colour == 0)
                {
                    squareColor = Color.Lime;
                    textColor = Color.DarkGreen;
                    colour = 1;
                }
                else
                {
                    squareColor = Color.DarkGreen;
                    textColor = Color.Lime;
                    colour = 0;
                }

                Raylib.DrawRectangle(XPos * 100 + XOffset, YPos * 100 + YOffset, 100, 100, squareColor);
                if (XPos == 7)
                {
                    Raylib.DrawText((8 - YPos).ToString(), (XPos + 1) * 100 + XOffset - 15, (YPos) * 100 + YOffset + 2, 20, textColor);
                }

                if (YPos == 7)
                {
                    char letter = (char)('A' + XPos);
                    Raylib.DrawText(letter.ToString(), (XPos) * 100 + XOffset + 5, (YPos + 1) * 100 + YOffset - 18, 20, textColor);
                }

                if (BoardState[XPos, YPos] != 0)
                {
                    DrawPiece(BoardState[XPos, YPos], XPos, YPos, XOffset, YOffset);
                }
                
            }
        }
    }

    public static void DrawPiece(int PieceID, int XPos, int YPos, int XOffset, int YOffset)
    {
        Rectangle SourceRectangle = CalculateSourceRectangle(PieceID);
        Rectangle DestinationRectangle = new Rectangle(XPos * 100 + XOffset, YPos * 100 + YOffset, 100, 100);
        Raylib.DrawTexturePro(ChessPieceTexture, SourceRectangle, DestinationRectangle, Vector2.Zero, 0, Color.White);
    }

    public static Rectangle CalculateSourceRectangle(int PieceID)
    {
        Rectangle SRec = new Rectangle();
        if(PieceID <= 6)
        {
            SRec.Y = 0;
            SRec.X = (PieceID - 1) * ChessPieceTexture.Width / 6;
        }
        else
        {
            SRec.Y = ChessPieceTexture.Height / 2;
            SRec.X = (PieceID - 7) * ChessPieceTexture.Width / 6;
        }
        SRec.Width = ChessPieceTexture.Width / 6;
        SRec.Height = ChessPieceTexture.Height / 2;

        return SRec;
    }
}

public class Board
{
    public int[,] BoardGrid = new int[8,8];
    
    public void BoardReset()
    {
        BoardGrid = new int[8,8]
        {
            {11,12,0,0,0,0,6,5 },
            {10,12,0,0,0,0,6,4 },
            {9,12,0,0,0,0,6,3 },
            {8,12,0,0,0,0,6,2 },
            {7,12,0,0,0,0,6,1 },
            {9,12,0,0,0,0,6,3 },
            {10,12,0,0,0,0,6,4 },
            {11,12,0,0,0,0,6,5 }
        };



    }
}

public class PieceData()
{
    
}