using System.Collections.Generic;
using System.IO;

/// <summary>
/// Класс программы для чтения чисел из файла, фильтрации чисел, делящихся на 3, и записи их в другой файл.
/// </summary>
class Program
{
    /// <summary>
    /// Точка входа в программу.
    /// </summary>
    static void Main()
    {
        string inputFile = "f.txt";
        string outputFile = "g.txt";

        try
        {
            // Читаем все строки из файла f
            string[] lines = File.ReadAllLines(inputFile);

            List<string> divisibleByThree = new List<string>();

            foreach (var line in lines)
            {
                // Разделяем строку на компоненты (числа), предполагая, что числа разделены пробелами или табуляцией
                string[] parts = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var part in parts)
                {
                    // Пытаемся преобразовать часть строки в число
                    if (int.TryParse(part, out int number))
                    {
                        // Проверяем, что число положительное и делится на 3 без остатка
                        if (number > 0 && number % 3 == 0)
                        {
                            divisibleByThree.Add(number.ToString());
                        }
                    }
                    else
                    {
                        // Выводим предупреждение, если значение не является числом
                        Console.WriteLine($"Пропущено нечисловое значение: {part}");
                    }
                }
            }

            // Записываем отфильтрованные числа в выходной файл
            File.WriteAllLines(outputFile, divisibleByThree);

            Console.WriteLine($"Записано {divisibleByThree.Count} чисел, делящихся на 3, в файл '{outputFile}'.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Файл '{inputFile}' не найден.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }
}
