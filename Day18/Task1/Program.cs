using System;
using System.Collections.Generic;

class Program
{
    static string ProcessString(string input)
    {
        Stack<char> stack = new Stack<char>();

        foreach (char ch in input)
        {
            if (ch == '#')
            {
                if (stack.Count > 0)
                {
                    stack.Pop(); // Удаляем последний добавленный символ
                }
            }
            else
            {
                stack.Push(ch); // Добавляем символ в стек
            }
        }

        // Стек хранит символы в обратном порядке, поэтому нужно перевернуть
        char[] result = stack.ToArray();
        Array.Reverse(result);
        return new string(result);
    }

    static void Main()
    {
        Console.WriteLine("Введите строку с символами '#':");
        string input = Console.ReadLine();

        string output = ProcessString(input);
        Console.WriteLine("Результат после обработки:");
        Console.WriteLine(output);
    }
}