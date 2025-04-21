class Program
{
    static void Main()
    {
        Console.WriteLine("Введите текст (слова через пробелы):");
        string input = Console.ReadLine();

        string[] words = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
 
        Array.Reverse(words);
        
        string result = string.Join(" ", words);
        
        Console.WriteLine("\nРезультат:");
        Console.WriteLine(result);
    }
}