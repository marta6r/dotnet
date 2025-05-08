using System;
using System.IO;
using System.Linq;

/// <summary>
/// Класс программы для работы с текстовыми файлами:
/// создание, чтение, анализ и запись строк в различные файлы.
/// </summary>
class Program
{
    /// <summary>
    /// Точка входа в программу.
    /// Выполняет следующие операции с файлами:
    /// <list type="number">
    /// <item>Создаёт файл с 5 строками различной длины.</item>
    /// <item>Считывает все строки из файла и выводит их на экран.</item>
    /// <item>Подсчитывает количество строк и количество символов в каждой строке.</item>
    /// <item>Удаляет последнюю строку и записывает результат в новый файл.</item>
    /// <item>Выводит на экран строки с заданного по заданный индекс (например, 2 по 4).</item>
    /// <item>Находит длину самой длинной строки и выводит её.</item>
    /// <item>Выводит все строки, начинающиеся с заданной буквы (например, 'П').</item>
    /// <item>Переписывает строки в другой файл в обратном порядке.</item>
    /// </list>
    /// </summary>
    static void Main()
    {
        string inputFile = "input.txt";
        string outputFile = "output.txt";

        // a) Создаем файл с 5 строками различной длины
        string[] linesToWrite = new string[]
        {
            "Первая строка",
            "Вторая строка, длиннее первой",
            "Третья",
            "Четвертая строка самая длинная из всех пяти строк",
            "Пятая"
        };
        File.WriteAllLines(inputFile, linesToWrite);

        // b) Читаем все строки из файла
        string[] lines = File.ReadAllLines(inputFile);

        // a) Вывести весь файл на экран
        Console.WriteLine("Содержимое файла:");
        foreach (var line in lines)
            Console.WriteLine(line);

        // b) Подсчитать количество строк
        Console.WriteLine($"\nКоличество строк: {lines.Length}");

        // c) Подсчитать количество символов в каждой строке
        Console.WriteLine("\nКоличество символов в каждой строке:");
        for (int i = 0; i < lines.Length; i++)
            Console.WriteLine($"Строка {i + 1}: {lines[i].Length} символов");

        // d) Удалить последнюю строку и записать результат в новый файл
        string[] linesWithoutLast = lines.Take(lines.Length - 1).ToArray();
        File.WriteAllLines(outputFile, linesWithoutLast);

        // e) Вывести на экран строки с s1 по s2 (например, 2 по 4)
        int s1 = 2, s2 = 4;
        Console.WriteLine($"\nСтроки с {s1} по {s2}:");
        for (int i = s1 - 1; i < s2 && i < lines.Length; i++)
            Console.WriteLine(lines[i]);

        // f) Найти длину самой длинной строки и вывести ее
        int maxLength = lines.Max(line => line.Length);
        Console.WriteLine($"\nДлина самой длинной строки: {maxLength}");

        // g) Вывести все строки, начинающиеся с заданной буквы (например, 'П')
        char startChar = 'П';
        Console.WriteLine($"\nСтроки, начинающиеся с буквы '{startChar}':");
        foreach (var line in lines.Where(l => l.StartsWith(startChar)))
            Console.WriteLine(line);

        // h) Переписать строки в другой файл в обратном порядке
        string reversedFile = "reversed.txt";
        File.WriteAllLines(reversedFile, lines.Reverse());

        Console.WriteLine($"\nОбратный порядок строк записан в файл '{reversedFile}'.");
    }
}
