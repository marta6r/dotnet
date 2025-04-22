using System;
using System.Text.RegularExpressions;

class HtmlValidator
{
    static bool IsHtml(string text)
    {
        string pattern = @"<(html|form|h1)(\s|>)|</(html|form|h1)>";
        return Regex.IsMatch(text, pattern, RegexOptions.IgnoreCase);
    }

    static void Main()
    {
        Console.WriteLine("Введите текст для проверки:");
        string input = Console.ReadLine();

        if (IsHtml(input))
            Console.WriteLine("Текст содержит HTML-теги <html>, <form> или <h1>");
        else
            Console.WriteLine("Текст НЕ содержит указанные HTML-теги");
    }
}
