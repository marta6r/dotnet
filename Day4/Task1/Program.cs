class Program
{
    static double CalculateF(double a, double b, double x)
    {
        if (3 * x > 10)
            return a + b * x;
        else if (3 * x > -3)
            return a - b * x;
        else
            return a * b;
    }

    static void BuildTable(double a, double b, double start, double end, double step)
    {
        Console.WriteLine("\n{0,-10} | {1,-15}", "x", "f(x)");
        Console.WriteLine(new string('-', 28));

        for (double x = start; x <= end; x += step)
        {
            double y = CalculateF(a, b, x);
            Console.WriteLine("{0,-10:F2} | {1,-15:F4}", x, y);
        }
    }

    static void Main()
    {
        Console.WriteLine("Введите параметры функции:");
        Console.Write("a = ");
        double a = double.Parse(Console.ReadLine());
        
        Console.Write("b = ");
        double b = double.Parse(Console.ReadLine());
        
        Console.Write("Начало интервала a = ");
        double start = double.Parse(Console.ReadLine());
        
        Console.Write("Конец интервала b = ");
        double end = double.Parse(Console.ReadLine());
        
        Console.Write("Шаг h = ");
        double step = double.Parse(Console.ReadLine());

        BuildTable(a, b, start, end, step);
    }
}