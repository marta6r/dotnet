class Program
{
    static void Main()
    {
        Console.Write("Введите размер массива n: ");
        int n = int.Parse(Console.ReadLine());

        int[] arr = new int[n];

        Console.WriteLine($"Введите {n} целых чисел:");
        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }

        int sumPositive = 0;
        int countNegative = 0;
        int countZero = 0;

        foreach (int num in arr)
        {
            if (num > 0)
                sumPositive += num;
            else if (num < 0)
                countNegative++;
            else
                countZero++;
        }

        Console.WriteLine($"\nСумма положительных чисел: {sumPositive}");
        Console.WriteLine($"Количество отрицательных чисел: {countNegative}");
        Console.WriteLine($"Количество нулевых чисел: {countZero}");

        Array.Sort(arr);
        Console.WriteLine("\nОтсортированный массив:");
        Console.WriteLine(string.Join(" ", arr));

        Console.Write("\nВведите число k для поиска: ");
        int k = int.Parse(Console.ReadLine());

        int index = Array.BinarySearch(arr, k);

        if (index >= 0)
            Console.WriteLine($"Число {k} найдено в массиве на позиции {index} (индексация с 0).");
        else
            Console.WriteLine($"Число {k} не найдено в массиве.");
    }
}