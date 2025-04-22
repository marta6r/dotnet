using System.Text.RegularExpressions;

Console.WriteLine("Введите текст: ");
string txt = Convert.ToString(Console.ReadLine());

string pattern = @"\b\w+(?:-\w+)+\b";

Regex r = new Regex(pattern);

MatchCollection words = r.Matches(txt);

Console.WriteLine("Найденные слова с дефисом: ");

foreach (Match word in words)
{
    Console.WriteLine(word.Value);
}