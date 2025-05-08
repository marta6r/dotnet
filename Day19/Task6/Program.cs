using System;

/// <summary>
/// Делегат для вычисления значений по радиусу.
/// </summary>
/// <param name="r">Радиус фигуры.</param>
/// <returns>Вычисленное значение (длина, площадь или объем).</returns>
delegate double CalcFigure(double r);

class Program
{
    /// <summary>
    /// Вычисляет длину окружности по радиусу.
    /// </summary>
    /// <param name="r">Радиус окружности.</param>
    /// <returns>Длина окружности.</returns>
    public static double Get_Length(double r)
    {
        return 2 * Math.PI * r;
    }

    /// <summary>
    /// Вычисляет площадь круга по радиусу.
    /// </summary>
    /// <param name="r">Радиус круга.</param>
    /// <returns>Площадь круга.</returns>
    public static double Get_Area(double r)
    {
        return Math.PI * r * r;
    }

    /// <summary>
    /// Вычисляет объем шара по радиусу.
    /// </summary>
    /// <param name="r">Радиус шара.</param>
    /// <returns>Объем шара.</returns>
    public static double Get_Volume(double r)
    {
        return (4.0 / 3) * Math.PI * Math.Pow(r, 3);
    }
}
    /// <summary>
