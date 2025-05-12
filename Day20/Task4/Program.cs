using System;
using System.Threading.Tasks;

class Program
{
    // Метод вычисления котангенса с обработкой особых случаев
    static double Cot(double x)
    {
        double tan = Math.Tan(x);
        if (Math.Abs(tan) < 1e-10)
            throw new ArgumentException($"Котангенс не определён для x = {x} (тангенс близок к нулю).");
        return 1.0 / tan;
    }

    static void Main()
    {
        double A = -6.0;
        double B = 4.0;
        int steps = 100; // Количество точек вычисления
        double stepSize = (B - A) / (steps - 1);

        double[] results = new double[steps];
        double[] xs = new double[steps];

        Parallel.For(0, steps, i =>
        {
            double x = A + i * stepSize;
            xs[i] = x;
            try
            {
                results[i] = Cot(x);
            }
            catch (ArgumentException)
            {
                results[i] = double.NaN; // Если котангенс не определён, записываем NaN
            }
        });

        // Вывод результатов
        Console.WriteLine($"Вычисление cot(x) на отрезке [{A}, {B}] с {steps} точками:");
        for (int i = 0; i < steps; i++)
        {
            if (double.IsNaN(results[i]))
                Console.WriteLine($"x = {xs[i]:F4}, cot(x) не определён");
            else
                Console.WriteLine($"x = {xs[i]:F4}, cot(x) = {results[i]:F6}");
        }
    }
}
