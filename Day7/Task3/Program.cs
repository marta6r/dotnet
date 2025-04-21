class Program
{
    static void Main()
    {
        Console.WriteLine("Введите предложение:");
        string input = Console.ReadLine();

        string[] words = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

        if (words.Length < 3)
        {
            Console.WriteLine("ОШИБКА: В предложении должно быть минимум 3 слова!");
            return;
        }

        string originalThirdWord = words[2];

        (words[0], words[^1]) = (words[^1], words[0]);
        Console.WriteLine($"\n1. После замены первого и последнего слов: {string.Join(" ", words)}");

        words[1] = words[1] + words[2];
        words = words.Where((w, i) => i != 2).ToArray();
        Console.WriteLine($"2. После склейки второго и третьего слов: {string.Join(" ", words)}");

        Console.WriteLine($"3. Третье слово в обратном порядке: {new string(originalThirdWord.Reverse().ToArray())}");

        string firstWordModified = words[0].Length > 2 ? words[0][2..] : "[Слово короче 2 символов]";
        Console.WriteLine($"4. Первое слово без первых двух букв: {firstWordModified}");
    }
}