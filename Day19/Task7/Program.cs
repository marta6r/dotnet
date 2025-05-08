using System;

class Program
{
    /// <summary>
    /// Лямбда-оператор для сложения двух чисел.
    /// </summary>
    static Func<double, double, double> Add = (x, y) => x + y;

    /// <summary>
    /// Лямбда-оператор для вычитания второго числа из первого.
    /// </summary>
    static Func<double, double, double> Sub = (x, y) => x - y;

    /// <summary>
    /// Лямбда-оператор для умножения двух чисел.
    /// </summary>
    static Func<double, double, double> Mul = (x, y) => x * y;

    /// <summary>
    /// Лямбда-оператор для деления первого числа на второе.
    /// Выбрасывает исключение DivideByZeroException при делении на ноль.
    /// </summary>
    static Func<double, double, double> Div = (x, y) => y != 0 ? x / y : throw new DivideByZeroException();

    /// <summary>
    /// Точка входа в программу.
    /// Запрашивает у пользователя два числа и арифметическую операцию,
    /// выполняет выбранную операцию и выводит результат.
    /// Обрабатывает возможные ошибки ввода и деления на ноль.
    /// </summary>
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
