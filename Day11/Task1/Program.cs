// Базовый класс
class Field
{
    private string name;
    private double r; // Вес семян на единицу площади

    public Field(string name, double r)
    {
        this.name = name;
        this.r = r;
    }

    // Методы доступа
    public string Name => name;
    public double SeedWeight => r;

    // Вывод информации
    public virtual void PrintInfo()
    {
        Console.WriteLine($"Поле: {name}");
        Console.WriteLine($"Норма высева: {r} кг/га");
    }

    // Расчет урожая
    public virtual double CalculateHarvest(double k)
    {
        return k * r;
    }
}

// Производный класс
class PotatoField : Field
{
    private double S; // Площадь поля

    public PotatoField(string name, double r, double S) : base(name, r)
    {
        this.S = S;
    }

    // Новый метод доступа
    public double Area => S;

    // Измененный вывод
    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Площадь картофельного поля: {S} га");
    }

    // Новый расчет урожая
    public override double CalculateHarvest(double k)
    {
        return base.CalculateHarvest(k) * S;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Тестирование базового класса ===");
        Field wheat = new Field("Пшеничное поле", 120);
        wheat.PrintInfo();
        Console.WriteLine($"Урожай с 1 га (k=2.5): {wheat.CalculateHarvest(2.5):F1} кг\n");

        Console.WriteLine("=== Тестирование производного класса ===");
        PotatoField farm = new PotatoField("Картофельная ферма", 80, 15);
        farm.PrintInfo();
        Console.WriteLine($"Урожай со всего поля (k=3.2): {farm.CalculateHarvest(3.2):F1} кг\n");

        Console.WriteLine("=== Сравнение методов ===");
        Console.WriteLine($"Метод базового класса: {wheat.CalculateHarvest(2.5):F1} кг");
        Console.WriteLine($"Метод потомка: {farm.CalculateHarvest(3.2):F1} кг");
    }
}