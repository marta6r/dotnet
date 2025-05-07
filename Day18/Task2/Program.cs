using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите путь к текстовому файлу:");
        string filePath = Console.ReadLine();

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл не найден.");
            return;
        }

        Queue<char> nonDigits = new Queue<char>();
        Queue<char> digits = new Queue<char>();

        // Читаем файл посимвольно за один проход
        using (StreamReader reader = new StreamReader(filePath))
        {
            int ch;
            while ((ch = reader.Read()) != -1)
            {
                char c = (char)ch;
                if (char.IsDigit(c))
                    digits.Enqueue(c);
                else
                    nonDigits.Enqueue(c);
            }
        }

        Console.WriteLine("Символы, отличные от цифр:");
        while (nonDigits.Count > 0)
        {
            Console.Write(nonDigits.Dequeue());
        }

        Console.WriteLine("\nЦифры:");
        while (digits.Count > 0)
        {
            Console.Write(digits.Dequeue());
        }

        Console.WriteLine();
    }
}