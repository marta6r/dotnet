Console.WriteLine("Введите цену за кг: ");
double A = Convert.ToDouble(Console.ReadLine());

if (1 <= A && A <= 100)
{
    for (double i = 0.1; i <= 1.0; i += 0.1)
    {
        Console.WriteLine($"Стоимость {Math.Round(i, 1)} кг = {Math.Round(i, 1) * A}");
    }
}