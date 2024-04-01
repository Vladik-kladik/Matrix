using System.Text;

namespace Matrix.BL;

public class Matrix
{
    public int[,] DataMatrix;
    public int Height { get; }
    public int Width { get; }
    public int Trace { get; private set; }
    
    private Random _rand = new Random();

    public Matrix(int[,] dataMatrix)
    {
        DataMatrix = (int[,])dataMatrix.Clone();
        Height = DataMatrix.GetLength(0);
        Width = DataMatrix.GetLength(1);
    }
    public Matrix(int height, int width)
    {
        Height = height;
        Width = width;
        DataMatrix = new int[height, width];
    }

    public void FillWithRandomNumbers()
    {
        Random rand = new Random();
        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                DataMatrix[i, j] = rand.Next(0, 101);
            }
        }
    }

    public void CalculateTrace()
    {
        Trace = 0;
        int sizeTrace = Math.Min(Height, Width);
        
        for (int i = 0; i < sizeTrace; i++)
        {
            Trace += DataMatrix[i, i];
        }
    }

    public void PrintMatrix()
    {
        for (int h = 0; h < Height; h++)
        {
            for (int w = 0; w < Width; w++)
            {
                if (h == w)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.Write(DataMatrix[h, w].ToString().PadLeft(4) + " ");
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }

    public int[] GetSnail()
    {
        int top = 0,
            bottom = Height - 1, 
            left = 0, 
            right = Width - 1;
        int[,] snailMatrix = (int[,])DataMatrix.Clone();
        int size = Width * Height;
        int[] snailArray = new int[size];
        int index = 0;

        while (index < size)
        {
            for (int i = left; i <= right && index < size; i++)
                snailArray[index++] = snailMatrix[top, i];
            top++;

            for (int i = top; i <= bottom && index < size; i++)
                snailArray[index++] = snailMatrix[i, right];
            right--;

            for (int i = right; i >= left && index < size; i--)
                snailArray[index++] = snailMatrix[bottom, i];
            bottom--;

            for (int i = bottom; i >= top && index < size; i--)
                snailArray[index++] = snailMatrix[i, left];
            left++;
        }
        return snailArray;
    }

    public void PrintSnail()
    {
        int[] snailArray = GetSnail();
        foreach (var item in snailArray)
        {
            Console.WriteLine(item + ", ");
        }
    }
}