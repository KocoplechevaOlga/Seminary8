// Задайтедвумерный массив из целых чисел.
//Напишите программу, которая удалит строку и столбец, 
//на пересечении которых расположен наименьший элемент массива.

int[,] FillMatrixRnd(int rows, int colums, int min, int max)
{
    int[,] matrix = new int[rows, colums];
    Random rnd  = new Random();
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i,j] = rnd.Next(min, max);
            }
    } 
    return matrix;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        Console.Write("|");
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (j < matrix.GetLength(1) - 1) Console.Write($"{matrix[i,j], 5} |");
            else Console.Write($"{matrix[i,j], 5}");
        }
        Console.WriteLine("|");
    }
}

int [] FindMinMatrix (int [,] matrix)
{
    int min = matrix[0,0];
    int [] indexMinElem = new int [2];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i,j] <= min)
            {
                min = matrix[i,j];
                indexMinElem [0] = i;
                indexMinElem [1] = j;
            }
        }
    }
    return indexMinElem;
}
void PrintArray(int[] arr)
{
    int j = 0;
    Console.Write("[");
    for (j = 0; j < (arr.Length-1); j++)
    {
        Console.Write(arr[j] + ", ");
    }
    Console.Write(arr[j]);
    Console.Write("]");
}
int[,] FillArrayWithotRowColum (int [,] matrix, int m, int n)
{
    int [,] newMatrix = new int[matrix.GetLength(0)-1,matrix.GetLength(1)-1];
    int posRow = m;
    int posCol = n;
    int findPosRow = 0;
    int findPosCol = 0;
    for (int i = 0; i < newMatrix.GetLength(0);i++)
    {
        if (findPosRow == posRow) findPosRow++;
        for (int j = 0; j < newMatrix.GetLength(1);j++)
        {
            if (findPosCol == posCol) findPosCol++;
            {
                newMatrix[i,j] = matrix[findPosRow,findPosCol];
            }
            findPosCol++;
        }
        findPosCol = 0;
        findPosRow++;
    }
    return newMatrix;
}

Console.WriteLine("Введите количество строк:");
int matrixRows = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите количество столбцов:");
int matrixColums = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите минимальное ограничение массива:");
int a = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите максимальное ограничение массива:");
int b = Convert.ToInt32(Console.ReadLine())+1;
int [,] myMatrix = FillMatrixRnd(matrixRows, matrixColums, a, b);
PrintMatrix(myMatrix);
Console.WriteLine(" ");

int [] minIndex = FindMinMatrix(myMatrix);
PrintArray(minIndex);
Console.WriteLine(" ");

int [,] newMatrix= FillArrayWithotRowColum(myMatrix, minIndex[0], minIndex[1]);
PrintMatrix(newMatrix);