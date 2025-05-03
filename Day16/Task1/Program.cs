using System.Collections.Generic;
using System.IO;

class Program
{
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
                // Разделяем строку на компоненты (числа), предполагая, что числа разделены пробелами
                string[] parts = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var part in parts)
                {
                    if (int.TryParse(part, out int number))
                    {
                        if (number > 0 && number % 3 == 0)
                        {
                            divisibleByThree.Add(number.ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Пропущено нечисловое значение: {part}");
                    }
                }
            }

            // Записываем отфильтрованные числа в файл g
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