using System;
using System.IO;

/// <summary>
/// Класс программы для инвертирования символов '0' и '1' в строках текстового файла.
/// </summary>
class Program
{
    /// <summary>
    /// Точка входа в программу.
    /// Считывает строки из входного файла, заменяет все '0' на '1' и все '1' на '0',
    /// затем записывает изменённые строки в выходной файл.
    /// </summary>
    static void Main()
    {
        string inputFile = "input.txt";   // исходный файл
        string outputFile = "output.txt"; // файл для записи результата

        try
        {
            // Читаем все строки из входного файла
            string[] lines = File.ReadAllLines(inputFile);

            for (int i = 0; i < lines.Length; i++)
            {
                char[] chars = lines[i].ToCharArray();

                for (int j = 0; j < chars.Length; j++)
                {
                    if (chars[j] == '0')
                        chars[j] = '1';
                    else if (chars[j] == '1')
                        chars[j] = '0';
                }

                lines[i] = new string(chars);
            }

            // Записываем изменённые строки в выходной файл
            File.WriteAllLines(outputFile, lines);

            Console.WriteLine($"Обработка завершена. Результат записан в файл '{outputFile}'.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Файл '{inputFile}' не найден.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}
