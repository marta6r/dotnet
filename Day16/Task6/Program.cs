class Program
{
    static void Main()
    {
        string fileName = "words.txt";

        if (!File.Exists(fileName))
        {
            Console.WriteLine($"Файл '{fileName}' не найден. Создайте файл с текстом и запустите программу снова.");
            return;
        }

        // Читаем весь текст из файла
        string text = File.ReadAllText(fileName);

        // Разбиваем текст на слова (разделители: пробелы, табуляция, знаки препинания)
        char[] separators = new char[] { ' ', '\t', '\r', '\n', '.', ',', '!', '?', ':', ';', '-', '\"', '(', ')', '[', ']', '{', '}' };
        string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        if (words.Length == 0)
        {
            Console.WriteLine("Файл пуст или не содержит слов.");
            return;
        }

        // 1. Вывести все слова, которые начинаются на заданную букву
        Console.Write("Введите букву для поиска слов, начинающихся на неё: ");
        char startChar = Console.ReadLine().ToLower()[0];
        var wordsStartingWith = words.Where(w => w.Length > 0 && char.ToLower(w[0]) == startChar);
        Console.WriteLine($"\nСлова, начинающиеся на '{startChar}':");
        foreach (var w in wordsStartingWith)
            Console.WriteLine(w);

        // 2. Вывести все слова, длина которых равна заданному числу
        Console.Write("\nВведите длину слова для поиска: ");
        if (!int.TryParse(Console.ReadLine(), out int length))
        {
            Console.WriteLine("Некорректный ввод длины.");
            return;
        }
        var wordsWithLength = words.Where(w => w.Length == length);
        Console.WriteLine($"\nСлова длиной {length}:");
        foreach (var w in wordsWithLength)
            Console.WriteLine(w);

        // 3. Вывести все слова, которые начинаются и заканчиваются одной буквой
        var wordsSameStartEnd = words.Where(w => w.Length > 0 && char.ToLower(w[0]) == char.ToLower(w[w.Length - 1]));
        Console.WriteLine("\nСлова, начинающиеся и заканчивающиеся одной буквой:");
        foreach (var w in wordsSameStartEnd)
            Console.WriteLine(w);

        // 4. Вывести все слова, которые начинаются на ту же букву, что и последнее слово
        string lastWord = words[words.Length - 1];
        char lastWordFirstChar = char.ToLower(lastWord[0]);
        var wordsSameAsLastStart = words.Where(w => w.Length > 0 && char.ToLower(w[0]) == lastWordFirstChar);
        Console.WriteLine($"\nСлова, начинающиеся на ту же букву, что и последнее слово '{lastWord}':");
        foreach (var w in wordsSameAsLastStart)
            Console.WriteLine(w);
    }
}