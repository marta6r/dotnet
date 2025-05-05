namespace Task1Lib;

// Базовый класс для всех фигур
public abstract class Figure
{
    public abstract double CalculatePerimeter();
    public abstract double CalculateArea();
}

// Класс Треугольник
public class Triangle : Figure
{
    public double SideA { get; set; }
    public double SideB { get; set; }
    public double SideC { get; set; }

    public void InputSides(double a, double b, double c)
    {
        SideA = a;
        SideB = b;
        SideC = c;
    }

    public bool CheckExistence()
    {
        return SideA + SideB > SideC &&
               SideA + SideC > SideB &&
               SideB + SideC > SideA;
    }

    public EnumTryangleType DetermineType()
    {
        if (SideA == SideB && SideB == SideC)
            return EnumTryangleType.Type11;
        else if (SideA == SideB || SideA == SideC || SideB == SideC)
            return EnumTryangleType.Type2;
        else
            return EnumTryangleType.Type3;
    }

    public override double CalculatePerimeter()
    {
        return SideA + SideB + SideC;
    }

    public override double CalculateArea()
    {
        double p = CalculatePerimeter() / 2;
        return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
    }
}

// Класс Прямоугольник
public class Rectangle : Figure
{
    public double Length { get; set; }
    public double Width { get; set; }

    public void InputSides(double length, double width)
    {
        Length = length;
        Width = width;
    }

    public override double CalculatePerimeter()
    {
        return 2 * (Length + Width);
    }

    public override double CalculateArea()
    {
        return Length * Width;
    }
}
