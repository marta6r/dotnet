using System.Linq;
using System.Threading;

class Program
{
    static int[] arr;
    static int threadCount;
    static int[] partialSums;

    static void Main()
    {
        Console.Write("Введите количество элементов массива: ");
        int n = int.Parse(Console.ReadLine());
        arr = new int[n];

        // Заполняем массив, например, случайными числами от 1 до 100
        Random rnd = new Random();
        for (int i = 0; i < n; i++)
        {
            arr[i] = rnd.Next(1, 101);
        }

        Console.WriteLine("Массив: " + string.Join(", ", arr));

        Console.Write("Введите количество потоков: ");
        threadCount = int.Parse(Console.ReadLine());
        partialSums = new int[threadCount];

        // Создаём и запускаем потоки
        Thread[] threads = new Thread[threadCount];
        for (int i = 0; i < threadCount; i++)
        {
            int threadId = i;
            threads[i] = new Thread(() => partialSums[threadId] = SumEvenInRange(threadId));
            threads[i].Start();
        }

        // Ожидаем завершения всех потоков
        foreach (var t in threads)
        {
            t.Join();
        }

        // Суммируем частичные суммы
        int totalSum = partialSums.Sum();

        Console.WriteLine("Сумма чётных элементов: " + totalSum);
    }

    // Метод для вычисления суммы чётных элементов в своей части массива
    static int SumEvenInRange(int threadId)
    {
        int start = threadId * (arr.Length / threadCount);
        int end = (threadId == threadCount - 1) ? arr.Length : (threadId + 1) * (arr.Length / threadCount);

        int sum = 0;
        for (int i = start; i < end; i++)
        {
            if (arr[i] % 2 == 0)
            {
                sum += arr[i];
            }
        }
        return sum;
    }
}