using System;
using System.Collections.Generic;

class Automobile
{
    protected string name;

    public Automobile(string name)
    {
        this.name = name;
    }

    public virtual double CalculateFuelConsumption()
    {
        return 0;
    }

    public virtual void PrintResults()
    {
        Console.WriteLine($"Автомобиль: {name}");
        Console.WriteLine($"Расход топлива: {CalculateFuelConsumption():F2} л/100км");
        Console.WriteLine(new string('-', 30));
    }
}

class Truck : Automobile
{
    private double payload;

    public Truck(string name, double payload) : base(name)
    {
        this.payload = payload;
    }

    public override double CalculateFuelConsumption()
    {
        return Math.Sqrt(payload) * 100;
    }

    public override void PrintResults()
    {
        Console.WriteLine($"Грузовой автомобиль: {name}");
        Console.WriteLine($"Грузоподъёмность: {payload} т");
        Console.WriteLine($"Расход топлива: {CalculateFuelConsumption():F2} л/100км");
        Console.WriteLine(new string('-', 30));
    }
}

class Car : Automobile
{
    private double engineVolume;

    public Car(string name, double engineVolume) : base(name)
    {
        this.engineVolume = engineVolume;
    }

    public override double CalculateFuelConsumption()
    {
        return 2.5 * engineVolume;
    }

    public override void PrintResults()
    {
        Console.WriteLine($"Легковой автомобиль: {name}");
        Console.WriteLine($"Объём двигателя: {engineVolume} см³");
        Console.WriteLine($"Расход топлива: {CalculateFuelConsumption():F2} л/100км");
        Console.WriteLine(new string('-', 30));
    }
}

class Program
{
    static void Main()
    {
        // Создаём полиморфный контейнер
        List<Automobile> garage = new List<Automobile>
        {
            new Car("Toyota Camry", 2500),
            new Truck("MAN TGS", 20),
            new Car("Honda Civic", 1800),
            new Truck("Volvo FH16", 25),
            new Car("BMW X5", 3000),
            new Truck("Scania R730", 30)
        };

        // Демонстрация работы виртуальных методов
        Console.WriteLine("=== Отчёт о расходе топлива ===");
        Console.WriteLine(new string('=', 30));
        
        foreach (var vehicle in garage)
        {
            vehicle.PrintResults();
        }

        // Дополнительная проверка полиморфизма
        Console.WriteLine("\nПроверка полиморфизма:");
        Automobile testVehicle = new Car("Test Car", 2000);
        testVehicle.PrintResults();
    }
}