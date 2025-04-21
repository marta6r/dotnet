class Program
{
    static void Main()
    {
        Console.WriteLine("Введите строку:");
        string input = Console.ReadLine();
        
        var digits = input.Where(char.IsDigit);
        
        if (!digits.Any())
        {
            Console.WriteLine("В строке нет цифр.");
            return;
        }

        var grouped = digits
            .Select((d, index) => new { Digit = d, Index = index })
            .GroupBy(x => x.Digit)
            .OrderByDescending(g => g.Count())
            .ThenBy(g => g.Min(x => x.Index));

        char mostFrequentDigit = grouped.First().Key;

        Console.WriteLine($"Чаще всего встречается цифра: {mostFrequentDigit}");
    }
}