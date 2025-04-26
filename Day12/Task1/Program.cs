// Объявление типа делегата
delegate double CalcFigure(double r);

class Program
{
    // Статические методы вычислений
    public static double Get_Length(double r)
    {
        return 2 * Math.PI * r;
    }

    public static double Get_Area(double r)
    {
        return Math.PI * r * r;
    }

    public static double Get_Volume(double r)
    {
        return (4.0 / 3) * Math.PI * Math.Pow(r, 3);
    }

    static void Main()
    {
        // Создание экземпляра делегата
        CalcFigure CF;
        
        // Ввод радиуса
        Console.Write("Введите радиус R: ");
        double R = double.Parse(Console.ReadLine());

        // Вычисление и вывод длины окружности
        CF = Get_Length;
        Console.WriteLine($"Длина окружности: {CF(R):F2}");

        // Вычисление и вывод площади круга
        CF = Get_Area;
        Console.WriteLine($"Площадь круга: {CF(R):F2}");

        // Вычисление и вывод объема шара
        CF = Get_Volume;
        Console.WriteLine($"Объем шара: {CF(R):F2}");
    }
}