using System;
using System.IO;
using System.Linq;

/// <summary>
/// Класс программы для работы с бинарными файлами, содержащими целые числа.
/// Выполняет операции поиска, сравнения и проверки последовательностей чисел.
/// </summary>
class Program
{
    /// <summary>
    /// Точка входа в программу.
    /// Создаёт два бинарных файла с целыми числами, выполняет анализ данных:
    /// <list type="number">
    /// <item>Находит число, наиболее близкое к минимальному в файле f2.dat.</item>
    /// <item>Сравнивает количество положительных, отрицательных и нулевых значений в двух файлах.</item>
    /// <item>Проверяет, упорядочены ли числа в f1.dat по возрастанию.</item>
    /// <item>Проверяет, образуют ли числа в f1.dat знакопеременную последовательность.</item>
    /// </list>
    /// </summary>
    static void Main()
    {
        string file1 = "f1.dat";
        string file2 = "f2.dat";

        // Создаём файлы с целыми числами
        CreateFile(file1, new int[] { -5, 0, 3, 7, 2, 8 });
        CreateFile(file2, new int[] { 4, -1, 0, 3, 9, 2, 1 });

        int[] f1Numbers = ReadNumbers(file1);
        int[] f2Numbers = ReadNumbers(file2);

        // 1. Найти в f2.dat число, наиболее близкое к минимальному значению в f2.dat
        int minF2 = f2Numbers.Min();
        int closestToMin = FindClosestNumber(f2Numbers, minF2);
        Console.WriteLine($"Минимальное число в {file2}: {minF2}");
        Console.WriteLine($"Число, наиболее близкое к минимальному в {file2}: {closestToMin}");

        // 2. Определить, в каком файле больше положительных, отрицательных и нулевых значений
        CompareCounts(f1Numbers, f2Numbers);

        // 3. Проверить, упорядочены ли числа в f1.dat по возрастанию
        bool isAscending = IsAscending(f1Numbers);
        Console.WriteLine($"Числа в {file1} упорядочены по возрастанию: {isAscending}");

        // 4. Проверить, образуют ли числа в f1.dat знакопеременную последовательность
        bool isAlternating = IsAlternating(f1Numbers);
        Console.WriteLine($"Числа в {file1} образуют знакопеременную последовательность: {isAlternating}");
    }

    /// <summary>
    /// Создаёт бинарный файл с заданным именем и записывает в него массив целых чисел.
    /// </summary>
    /// <param name="filename">Имя создаваемого файла.</param>
    /// <param name="numbers">Массив целых чисел для записи в файл.</param>
    static void CreateFile(string filename, int[] numbers)
    {
        using (BinaryWriter writer = new BinaryWriter(File.Open(filename, FileMode.Create)))
        {
            foreach (int num in numbers)
                writer.Write(num);
        }
    }

    /// <summary>
    /// Считывает все целые числа из бинарного файла и возвращает их в виде массива.
    /// </summary>
    /// <param name="filename">Имя файла для чтения.</param>
    /// <returns>Массив целых чисел, считанных из файла.</returns>
    static int[] ReadNumbers(string filename)
    {
        using (BinaryReader reader = new BinaryReader(File.Open(filename, FileMode.Open)))
        {
            long length = reader.BaseStream.Length;
            int count = (int)(length / sizeof(int));
            int[] numbers = new int[count];
            for (int i = 0; i < count; i++)
                numbers[i] = reader.ReadInt32();
            return numbers;
        }
    }

    /// <summary>
    /// Находит в массиве число, наиболее близкое к заданному значению, исключая само это значение.
    /// </summary>
    /// <param name="array">Массив чисел для поиска.</param>
    /// <param name="target">Целевое число, к которому ищется ближайшее.</param>
    /// <returns>Число из массива, наиболее близкое к <paramref name="target"/>, но не равное ему.</returns>
    static int FindClosestNumber(int[] array, int target)
    {
        int closest = array[0];
        int minDiff = Math.Abs(array[0] - target);
        foreach (int num in array)
        {
            int diff = Math.Abs(num - target);
            if (diff != 0 && diff < minDiff)
            {
                minDiff = diff;
                closest = num;
            }
        }
        return closest;
    }

    /// <summary>
    /// Сравнивает количество положительных, отрицательных и нулевых значений в двух массивах и выводит результаты.
    /// </summary>
    /// <param name="arr1">Первый массив чисел.</param>
    /// <param name="arr2">Второй массив чисел.</param>
    static void CompareCounts(int[] arr1, int[] arr2)
    {
        int pos1 = arr1.Count(x => x > 0);
        int neg1 = arr1.Count(x => x < 0);
        int zero1 = arr1.Count(x => x == 0);

        int pos2 = arr2.Count(x => x > 0);
        int neg2 = arr2.Count(x => x < 0);
        int zero2 = arr2.Count(x => x == 0);

        Console.WriteLine("\nСравнение количества значений:");
        Console.WriteLine($"Положительных: f1.dat={pos1}, f2.dat={pos2}, больше в {(pos1 > pos2 ? "f1.dat" : (pos1 < pos2 ? "f2.dat" : "оба равны"))}");
        Console.WriteLine($"Отрицательных: f1.dat={neg1}, f2.dat={neg2}, больше в {(neg1 > neg2 ? "f1.dat" : (neg1 < neg2 ? "f2.dat" : "оба равны"))}");
        Console.WriteLine($"Нулевых: f1.dat={zero1}, f2.dat={zero2}, больше в {(zero1 > zero2 ? "f1.dat" : (zero1 < zero2 ? "f2.dat" : "оба равны"))}");
    }

    /// <summary>
    /// Проверяет, упорядочены ли числа в массиве по возрастанию.
    /// </summary>
    /// <param name="array">Массив чисел для проверки.</param>
    /// <returns><c>true</c>, если массив упорядочен по возрастанию; иначе <c>false</c>.</returns>
    static bool IsAscending(int[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < array[i - 1])
                return false;
        }
        return true;
    }

    /// <summary>
    /// Проверяет, образуют ли числа в массиве знакопеременную последовательность.
    /// Нули не считаются знакопеременными.
    /// </summary>
    /// <param name="array">Массив чисел для проверки.</param>
    /// <returns><c>true</c>, если числа образуют знакопеременную последовательность; иначе <c>false</c>.</returns>
    static bool IsAlternating(int[] array)
    {
        if (array.Length < 2)
            return true;

        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] == 0 || array[i - 1] == 0)
                return false; // нули не считаем знакопеременными

            if (Math.Sign(array[i]) == Math.Sign(array[i - 1]))
                return false;
        }
        return true;
    }
}
