using System;

class Program
{
    /// <summary>
    /// Вычисляет сумму двух вещественных чисел.
    /// </summary>
    /// <param name="a">Первое число.</param>
    /// <param name="b">Второе число.</param>
    /// <returns>Сумма чисел a и b.</returns>
    static double Sum(double a, double b)
    {
        return a + b;
    }

    /// <summary>
    /// Вычисляет сумму трёх вещественных чисел.
    /// </summary>
    /// <param name="a">Первое число.</param>
    /// <param name="b">Второе число.</param>
    /// <param name="c">Третье число.</param>
    /// <returns>Сумма чисел a, b и c.</returns>
    static double Sum(double a, double b, double c)
    {
        return a + b + c;
    }

    /// <summary>
    /// Точка входа в программу.
    /// Запрашивает у пользователя пять вещественных чисел, вычисляет сумму двух первых и сумму трёх следующих,
    /// затем выводит их сумму.
    /// </summary>
    static void Main()
    {
        Console.WriteLine("Введите пять вещественных чисел:");
        
        Console.Write("a1 = ");
        double a1 = double.Parse(Console.ReadLine());
        
        Console.Write("b1 = ");
        double b1 = double.Parse(Console.ReadLine());
        
        Console.Write("a2 = ");
        double a2 = double.Parse(Console.ReadLine());
        
        Console.Write("b2 = ");
        double b2 = double.Parse(Console.ReadLine());
        
        Console.Write("c2 = ");
        double c2 = double.Parse(Console.ReadLine());

        // Вычисление результата
        double result = Sum(a1, b1) + Sum(a2, b2, c2);
        
        Console.WriteLine($"\nSum(a1, b1) + Sum(a2, b2, c2) = {result:F2}");
    }
}
