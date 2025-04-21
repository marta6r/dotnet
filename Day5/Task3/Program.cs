using System;

class InvalidRectangleException : Exception
{
    public InvalidRectangleException(string message) : base(message) { }
}

class Program
{
    static void RectPS(double x1, double y1, double x2, double y2, out double P, out double S)
    {
        double length = Math.Abs(x2 - x1);
        double width = Math.Abs(y2 - y1);

        if (length == 0 || width == 0)
            throw new InvalidRectangleException("Длина или ширина прямоугольника равна нулю.");

        P = 2 * (length + width);
        S = length * width;
    }

    static void Main()
    {
        try
        {
            double[,] rectangles = new double[3, 4]
            {
                {1, 1, 4, 5},
                {0, 0, 3, 3},
                {2, 3, 2, 7} 
            };

            for (int i = 0; i < 3; i++)
            {
                double x1 = rectangles[i, 0];
                double y1 = rectangles[i, 1];
                double x2 = rectangles[i, 2];
                double y2 = rectangles[i, 3];

                RectPS(x1, y1, x2, y2, out double perimeter, out double area);

                Console.WriteLine($"Прямоугольник {i + 1}:");
                Console.WriteLine($"Координаты: ({x1}, {y1}), ({x2}, {y2})");
                Console.WriteLine($"Периметр = {perimeter:F2}");
                Console.WriteLine($"Площадь = {area:F2}\n");
            }
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"Ошибка деления на ноль: {ex.Message}");
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Ошибка формата ввода: {ex.Message}");
        }
        catch (InvalidRectangleException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }
}