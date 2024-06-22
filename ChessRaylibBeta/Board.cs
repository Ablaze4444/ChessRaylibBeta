namespace ChessRaylibBeta;

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

    public void SetCell(int x, int y, int val)
    {
        BoardGrid[x,y] = val;
    }

    public int GetCell(int x , int y)
    {
        return BoardGrid[x,y];
    }


}
