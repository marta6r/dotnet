class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Введите значение x (в градусах): ");
            string input = Console.ReadLine();

            if (!double.TryParse(input, out double x))
            {
                throw new FormatException("Введено не число.");
            }

            double xRad = x * Math.PI / 180.0;

            double denominatorA = 4 * x + 8;
            if (Math.Abs(denominatorA) < 1e-15)
                throw new DivideByZeroException("Деление на ноль в выражении a.");

            double y1 = (5 * x - 7) / denominatorA;
            
            if (Math.Abs(x - 1) < 1e-15)
                throw new DivideByZeroException("Деление на ноль во втором слагаемом выражения b.");

            double tanX = Math.Tan(xRad);
            double cosX = Math.Cos(xRad);
            double y2 = tanX + cosX / (x - 1);

            Console.WriteLine($"\nРезультат выражения a: y = {y1:F5}");
            Console.WriteLine($"Результат выражения b: y = {y2:F5}");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Ошибка формата ввода: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }
}