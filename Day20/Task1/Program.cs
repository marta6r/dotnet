using System;

class Task
{
    private int number;

    // Конструктор с параметром
    public Task(int number)
    {
        if (number < 100 || number > 999)
            throw new ArgumentException("Число должно быть трёхзначным.");
        this.number = number;
    }

    // Метод решения задачи
    public int Solve()
    {
        int lastDigit = number % 10;           // Последняя цифра
        int firstTwoDigits = number / 10;      // Первые две цифры
        int result = lastDigit * 100 + firstTwoDigits;
        return result;
    }

    // Метод для вывода результата
    public void PrintResult()
    {
        Console.WriteLine($"Исходное число: {number}, результат: {Solve()}");
    }
}

class Program
{
    static void Main()
    {
        // Вариант 1: создание объекта с помощью оператора new и вызов метода напрямую
        Task task1 = new Task(123);
        int result1 = task1.Solve();
        Console.WriteLine($"Вариант 1: {result1}");  // Ожидается 312

        // Вариант 2: создание объекта и вызов метода через отдельный метод класса Program
        Task task2 = new Task(456);
        PrintTaskResult(task2);

        // Вариант 3: создание объекта через анонимный тип (через лямбда-выражение) и вызов метода
        // В C# нельзя создать объект класса Task без new, но можно использовать делегат или лямбду
        Func<int, int> solveFunc = (num) =>
        {
            Task t = new Task(num);
            return t.Solve();
        };
        int result3 = solveFunc(789);
        Console.WriteLine($"Вариант 3: {result3}");  // Ожидается 978
    }

    static void PrintTaskResult(Task task)
    {
        Console.WriteLine($"Вариант 2: {task.Solve()}");
    }
}
