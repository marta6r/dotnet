class OutOfRangeException : Exception
{
    public OutOfRangeException(string message) : base(message) { }
}

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Введите вещественное число x (x > -4): ");
            string input = Console.ReadLine();

            if (!double.TryParse(input, out double x))
                throw new FormatException("Введено не число.");

            if (x <= -4)
                throw new OutOfRangeException("Значение x выходит за допустимый диапазон (x > -4).");

            double f;

            if (x > -4 && x < 1)
            {
                if (Math.Abs(x - 2) < 1e-15)
                    throw new DivideByZeroException("Деление на ноль при вычислении функции f.");

                f = (3 * x) / (x - 2);
            }
            else 
            {
                f = 3;
            }

            Console.WriteLine($"Значение функции f при x = {x} равно {f:F5}");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"Ошибка деления на ноль: {ex.Message}");
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Ошибка формата ввода: {ex.Message}");
        }
        catch (OutOfRangeException ex)
        {
            Console.WriteLine($"Ошибка диапазона: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }
}