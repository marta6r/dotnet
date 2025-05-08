using System;

/// <summary>
/// Делегат для обработки строк.
/// </summary>
/// <param name="input">Входная строка для обработки.</param>
delegate void StringProcessor(string input);

/// <summary>
/// Класс, содержащий методы для различных операций со строками.
/// </summary>
class StringOperations
{
    /// <summary>
    /// Выводит длину переданной строки.
    /// </summary>
    /// <param name="str">Строка для обработки.</param>
    public static void PrintLength(string str)
    {
        Console.WriteLine($"Длина строки: {str.Length} символов");
    }

    /// <summary>
    /// Выводит переданную строку в верхнем регистре.
    /// </summary>
    /// <param name="str">Строка для обработки.</param>
    public static void PrintUppercase(string str)
    {
        Console.WriteLine($"Верхний регистр: {str.ToUpper()}");
    }

    /// <summary>
    /// Проверяет, является ли переданная строка палиндромом (игнорируя пробелы и регистр).
    /// </summary>
    /// <param name="str">Строка для проверки.</param>
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

/// <summary>
/// Класс с точкой входа в программу.
/// </summary>
class Program
{
    /// <summary>
    /// Точка входа в программу.
    /// Запрашивает строку у пользователя, создает делегат с методами обработки строки,
    /// и вызывает их последовательно.
    /// </summary>
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
