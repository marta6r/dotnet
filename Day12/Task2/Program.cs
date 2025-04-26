class Program
{
    // Лямбда-операторы для арифметических действий
    static Func<double, double, double> Add = (x, y) => x + y;
    static Func<double, double, double> Sub = (x, y) => x - y;
    static Func<double, double, double> Mul = (x, y) => x * y;
    static Func<double, double, double> Div = (x, y) => y != 0 ? x / y : throw new DivideByZeroException();

    static void Main()
    {
        try
        {
            Console.WriteLine("Введите два числа через пробел:");
            double[] numbers = Array.ConvertAll(Console.ReadLine().Split(), double.Parse);
            
            Console.WriteLine("Выберите операцию: +, -, *, /");
            char operation = Console.ReadKey().KeyChar;
            Console.WriteLine();

            double result = operation switch
            {
                '+' => Add(numbers[0], numbers[1]),
                '-' => Sub(numbers[0], numbers[1]),
                '*' => Mul(numbers[0], numbers[1]),
                '/' => Div(numbers[0], numbers[1]),
                _ => throw new InvalidOperationException("Неизвестная операция")
            };

            Console.WriteLine($"Результат: {result:F2}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка ввода чисел!");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Деление на ноль невозможно!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}