class Program
{
    static void Main()
    {
        int N;
        do
        {
            Console.Write("Введите размер квадратной матрицы N (N < 10): ");
            N = int.Parse(Console.ReadLine());
        } while (N <= 0 || N >= 10);

        Console.Write("Введите нижнюю границу диапазона a: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Введите верхнюю границу диапазона b (b >= a): ");
        int b;
        do
        {
            b = int.Parse(Console.ReadLine());
            if (b < a)
                Console.WriteLine("Верхняя граница должна быть не меньше нижней. Попробуйте снова.");
        } while (b < a);

        int[,] matrix = new int[N, N];
        Random rnd = new Random();

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                matrix[i, j] = rnd.Next(a, b + 1);
            }
        }

        Console.WriteLine("\nИсходная матрица:");
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }

        Console.Write("\nВведите число D: ");
        int D = int.Parse(Console.ReadLine());

        int countLessThanD = 0;
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (matrix[i, j] < D)
                    countLessThanD++;
            }
        }
        Console.WriteLine($"\nКоличество элементов матрицы, меньших {D}: {countLessThanD}");

        Console.WriteLine("\nСреднее арифметическое элементов каждого столбца:");
        for (int j = 0; j < N; j++)
        {
            double sumColumn = 0;
            for (int i = 0; i < N; i++)
            {
                sumColumn += matrix[i, j];
            }
            double average = sumColumn / N;
            Console.WriteLine($"Столбец {j + 1}: {average:F2}");
        }
    }
}