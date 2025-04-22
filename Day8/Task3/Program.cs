using System.Text.RegularExpressions;

Console.WriteLine("Введите текст: ");
string txt = Console.ReadLine();

bool containsDigits = Regex.IsMatch(txt, @"\d");

Console.WriteLine(containsDigits 
    ? "Текст содержит цифры" 
    : "Текст не содержит цифр");
