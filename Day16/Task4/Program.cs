class Program
{
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