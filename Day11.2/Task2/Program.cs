using System;
using System.Collections.Generic;

abstract class Furniture
{
    protected string name;
    protected double price;

    public Furniture(string name, double price)
    {
        this.name = name;
        this.price = price;
    }

    public abstract void PrintInfo();
    public double GetPrice() => price;
}

class Wardrobe : Furniture
{
    private double height;

    public Wardrobe(string name, double price, double height) 
        : base(name, price)
    {
        this.height = height;
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"Шкаф: {name}");
        Console.WriteLine($"Высота: {height} м");
        Console.WriteLine($"Цена: {price} руб");
        Console.WriteLine(new string('-', 30));
    }
}

class Sofa : Furniture
{
    private int seats;

    public Sofa(string name, double price, int seats) 
        : base(name, price)
    {
        this.seats = seats;
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"Диван: {name}");
        Console.WriteLine($"Количество мест: {seats}");
        Console.WriteLine($"Цена: {price} руб");
        Console.WriteLine(new string('-', 30));
    }
}

class Program
{
    static void Main()
    {
        List<Furniture> furnitureStore = new List<Furniture>
        {
            new Wardrobe("Престиж", 15000, 2.1),
            new Sofa("Европа", 32500, 3),
            new Wardrobe("Эконом", 8990, 1.8),
            new Sofa("Премиум", 41700, 4),
            new Wardrobe("Люкс", 28900, 2.4),
            new Sofa("Компакт", 18500, 2)
        };

        Console.WriteLine("=== Ассортимент мебели ===");
        foreach (var item in furnitureStore)
        {
            item.PrintInfo();
        }

        CalculateAverages(furnitureStore);
    }

    static void CalculateAverages(List<Furniture> items)
    {
        double wardrobeTotal = 0;
        double sofaTotal = 0;
        int wardrobeCount = 0;
        int sofaCount = 0;

        foreach (var item in items)
        {
            if (item is Wardrobe)
            {
                wardrobeTotal += item.GetPrice();
                wardrobeCount++;
            }
            else if (item is Sofa)
            {
                sofaTotal += item.GetPrice();
                sofaCount++;
            }
        }

        Console.WriteLine("\n=== Средние цены ===");
        Console.WriteLine($"Шкафы: {wardrobeTotal/wardrobeCount:F2} руб");
        Console.WriteLine($"Диваны: {sofaTotal/sofaCount:F2} руб");
    }
}