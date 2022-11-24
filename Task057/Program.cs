// Составить частотный словарь элементов двумерного массива. 
//Частотный словарь содержит информацию о том, сколько раз встречается элемент входных данных.

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
int [] FillArrayFromMatrix (int [,] matrix)
{
    int [] array = new int[matrix.GetLength(0)*matrix.GetLength(1)];
    int count = 0;
    for (int i = 0; i < matrix.GetLength(0);i++)
    {
        for (int j = 0; j < matrix.GetLength(1);j++)
        {
            array[count] = matrix[i,j];
            count++;
        }
    }
    return array;
}
void QuntutyElem(int [] array)
{
    int elem = array[0];
    int count = 0;
    for (int i = 0; i < array.Length; i++)
    {
        if (elem == array[i]) count ++;
        else 
        {
            Console.WriteLine($"Число {elem} встречается {count} раз");
            elem = array[i];
            count=1;
        }
    }
    Console.WriteLine($"Число {elem} встречается {count} раз");
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

int [] myArray = FillArrayFromMatrix(myMatrix);
Array.Sort(myArray);
PrintArray(myArray);

QuntutyElem(myArray);