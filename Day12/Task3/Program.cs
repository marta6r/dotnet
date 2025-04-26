// Объявляем делегат
delegate void StringProcessor(string input);

class StringOperations
{
    // Метод 1: Вывод длины строки
    public static void PrintLength(string str)
    {
        Console.WriteLine($"Длина строки: {str.Length} символов");
    }

    // Метод 2: Вывод строки в верхнем регистре
    public static void PrintUppercase(string str)
    {
        Console.WriteLine($"Верхний регистр: {str.ToUpper()}");
    }

    // Метод 3: Проверка на палиндром
    public static void CheckPalindrome(string str)
    {
        string cleanStr = new string(str.ToLower().ToCharArray())
                            .Replace(" ", "");
        char[] arr = cleanStr.ToCharArray();
        Array.Reverse(arr);
        string reversed = new string(arr);
        
        bool isPalindrome = cleanStr == reversed;
        Console.WriteLine($"Палиндром: {isPalindrome}");
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Введите строку: ");
        string input = Console.ReadLine();

        // Создаем экземпляр делегата и добавляем методы
        StringProcessor processor = StringOperations.PrintLength;
        processor += StringOperations.PrintUppercase;
        processor += StringOperations.CheckPalindrome;

        // Вызываем все методы через делегат
        processor(input);
    }
}