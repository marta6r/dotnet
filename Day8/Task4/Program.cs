using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите текст:");
        string text = Console.ReadLine();

        Regex regex = new Regex(@"\b[аеёиоуыэюяaeiouyАЕЁИОУЫЭЮЯAEIOUY]\w*\b", RegexOptions.IgnoreCase);
        
        MatchCollection matches = regex.Matches(text);
        
        Console.WriteLine("\nСлова, начинающиеся с гласной буквы:");
        foreach (Match match in matches)
        {
            Console.WriteLine(match.Value);
        }
    }
}