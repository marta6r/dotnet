using System;
using System.Linq;

class Train : IComparable<Train>
{
    private string destination;
    private string trainNumber;
    private DateTime departureTime;

    public Train(string destination, string trainNumber, DateTime departureTime)
    {
        this.destination = destination;
        this.trainNumber = trainNumber;
        this.departureTime = departureTime;
    }

    // Свойства
    public string Destination => destination;
    public string TrainNumber => trainNumber;
    public DateTime DepartureTime => departureTime;

    // Реализация IComparable
    public int CompareTo(Train other) => departureTime.CompareTo(other.departureTime);

    // Перегрузка операторов
    public static bool operator >(Train t1, Train t2) => t1.departureTime > t2.departureTime;
    public static bool operator <(Train t1, Train t2) => t1.departureTime < t2.departureTime;
    public static bool operator >=(Train t1, Train t2) => t1.departureTime >= t2.departureTime;
    public static bool operator <=(Train t1, Train t2) => t1.departureTime <= t2.departureTime;

    public override string ToString() => 
        $"Поезд #{trainNumber} до {destination}, отправление: {departureTime:HH:mm}";
}

class RailwayStation
{
    private Train[] trains;

    public RailwayStation(Train[] trains)
    {
        this.trains = trains;
        Array.Sort(this.trains); // Сортировка при инициализации
    }

    // Индексатор
    public string this[string number]
    {
        get
        {
            var train = trains.FirstOrDefault(t => t.TrainNumber == number);
            return train?.ToString() ?? "Поезд не найден";
        }
    }

    // Поиск по времени
    public void ShowAfterTime(DateTime time)
    {
        var result = trains.Where(t => t.DepartureTime.TimeOfDay > time.TimeOfDay)
                          .OrderBy(t => t.DepartureTime);
        
        Console.WriteLine($"\nПоезда после {time:HH:mm}:");
        foreach (var t in result) Console.WriteLine(t);
    }

    // Поиск по пункту назначения
    public void ShowDestinationTrains(string destination)
    {
        var result = trains.Where(t => t.Destination.Equals(destination, StringComparison.OrdinalIgnoreCase))
                          .OrderBy(t => t.DepartureTime);
        
        Console.WriteLine($"\nПоезда до {destination}:");
        foreach (var t in result) Console.WriteLine(t);
    }
}

class Program
{
    static void Main()
    {
        // Создаем массив поездов
        Train[] trains = {
            new Train("Москва", "145A", new DateTime(2023, 1, 1, 14, 30, 0)),
            new Train("Санкт-Петербург", "78Б", new DateTime(2023, 1, 1, 9, 15, 0)),
            new Train("Москва", "КН2023", new DateTime(2023, 1, 1, 18, 45, 0)),
            new Train("Новосибирск", "ЭКСПРЕСС", new DateTime(2023, 1, 1, 6, 0, 0))
        };

        RailwayStation station = new RailwayStation(trains);

        // Демонстрация возможностей
        Console.WriteLine("Поиск по номерам:");
        Console.WriteLine(station["145A"]);
        Console.WriteLine(station["НЕСУЩЕСТВУЕТ"]);

        Console.WriteLine("\nСравнение поездов:");
        Console.WriteLine($"Поезд 1 > Поезд 2: {trains[0] > trains[1]}");
        Console.WriteLine($"Поезд 2 < Поезд 3: {trains[1] < trains[2]}");

        station.ShowAfterTime(new DateTime(2023, 1, 1, 12, 0, 0));
        station.ShowDestinationTrains("Москва");
    }
}