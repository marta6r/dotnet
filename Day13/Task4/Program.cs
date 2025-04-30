// Класс-источник события
class EventPublisher
{
    public delegate void EventHandler(string message);
    public event EventHandler? EventOccurred;

    public void RaiseEvent(string msg)
    {
        EventOccurred?.Invoke(msg);
    }
}

// Первый класс-наблюдатель
class ObserverA
{
    public void HandleEvent(string message)
    {
        Console.WriteLine($"ObserverA: {message}");
    }
}

// Второй класс-наблюдатель
class ObserverB
{
    public void HandleEvent(string message)
    {
        Console.WriteLine($"ObserverB: {message}");
    }
}

class Program
{
    static void Main()
    {
        // Создаем объекты
        var publisher = new EventPublisher();
        var obsA1 = new ObserverA();
        var obsA2 = new ObserverA();
        var obsB = new ObserverB();

        // Добавляем обработчики
        publisher.EventOccurred += obsA1.HandleEvent;
        publisher.EventOccurred += obsA2.HandleEvent;
        publisher.EventOccurred += obsB.HandleEvent;

        Console.WriteLine("Все обработчики:");
        publisher.RaiseEvent("Первое событие");

        // Удаляем один обработчик
        publisher.EventOccurred -= obsA1.HandleEvent;

        Console.WriteLine("\nПосле удаления обработчика ObserverA:");
        publisher.RaiseEvent("Второе событие");
    }
}