
using Raylib_cs;
using System.Numerics;

namespace ChessRaylibBeta;

public static class BoardRenderer
{
    public static Texture2D ChessPieceTexture;
    public static void LoadTextures()
    {
        ChessPieceTexture = Raylib.LoadTexture("..//..//..//images/Pieces.png");
        Raylib.SetTextureFilter(ChessPieceTexture,TextureFilter.Bilinear);
    }
    
    public static void DrawBoard( int XOffset, int YOffset, int[,] BoardState, int SquarePixelSize)
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


                Raylib.DrawRectangle(XPos * SquarePixelSize + XOffset, YPos * SquarePixelSize + YOffset, SquarePixelSize, SquarePixelSize, squareColor);


                if (XPos == PieceMovementManager.mouseBoardXPos && YPos == PieceMovementManager.mouseBoardYPos && PieceMovementManager.MouseOnGridCheck(XOffset, YOffset, BoardState.GetLength(0), BoardState.GetLength(1), SquarePixelSize) == true)
                {
                    Raylib.DrawRectangle(PieceMovementManager.mouseBoardXPos * SquarePixelSize + XOffset, PieceMovementManager.mouseBoardYPos * SquarePixelSize + YOffset, SquarePixelSize, SquarePixelSize, Color.Red);
                }

                if (XPos == 7)
                {
                    Raylib.DrawText((8 - YPos).ToString(), (XPos + 1) * SquarePixelSize + XOffset - 15, (YPos) * SquarePixelSize + YOffset + 2, 20, textColor);
                }

                if (YPos == 7)
                {
                    char letter = (char)('A' + XPos);
                    Raylib.DrawText(letter.ToString(), (XPos) * SquarePixelSize + XOffset + 5, (YPos + 1) * SquarePixelSize + YOffset - 18, 20, textColor);
                }


                if (BoardState[XPos, YPos] != 0)
                {
                    DrawPiece(BoardState[XPos, YPos], XPos, YPos, XOffset, YOffset, SquarePixelSize);
                }

                
                
                
            }
        }

    }

    public static void DrawPiece(int PieceID, int XPos, int YPos, int XOffset, int YOffset, int SquarePixelSize)
    {
        Rectangle SourceRectangle = CalculateSourceRectangle(PieceID);
        Rectangle DestinationRectangle = new Rectangle(XPos * SquarePixelSize + XOffset, YPos * SquarePixelSize + YOffset, SquarePixelSize, SquarePixelSize);
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

    public static void RedDotMouse(int MouseXPos, int MouseYPos)
    {
        Raylib.DrawCircle(MouseXPos, MouseYPos, 4, Color.Red);
    }
}
