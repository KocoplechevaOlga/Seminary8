//Задайте двумерный массив. Напишите программу, которая 
//заменяет строки на столбцы. В случае, если это невозможно, 
//программа должна вывести сообщение для пользователя.

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

int[,] ReplaceRowsToColums(int [,] matrix)
{
    int [,] replaceMatrix = new int [matrix.GetLength(0), matrix.GetLength(1)];
    for (int i = 0; i < replaceMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < replaceMatrix.GetLength(1); j++)
            {
               replaceMatrix[i, j] = matrix[j, i];
            }
    } 
    return replaceMatrix;
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

if (myMatrix.GetLength(0) != myMatrix.GetLength(1)) Console.WriteLine("Вычисления не возможны");
int [,] newMatrix = ReplaceRowsToColums(myMatrix);
PrintMatrix(newMatrix);