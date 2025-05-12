using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    // Вычисление функции z1
    static double CalculateZ1(double a)
    {
        Thread.Sleep(2000); // Задержка 2 секунды
        double numerator1 = Math.Sin(4 * a);
        double denominator1 = 1 + Math.Cos(4 * a);
        double numerator2 = Math.Cos(2 * a);
        double denominator2 = 1 + Math.Cos(2 * a);

        double z1 = (numerator1 / denominator1) * (numerator2 / denominator2);
        return z1;
    }

    // Вычисление функции z2 = ctg(3/2 * π - a)
    static double CalculateZ2(double a)
    {
        Thread.Sleep(3000); // Задержка 3 секунды
        double angle = (3.0 / 2.0) * Math.PI - a;
        double tanValue = Math.Tan(angle);

        if (Math.Abs(tanValue) < 1e-10)
            throw new ArgumentException("Значение тангенса близко к нулю, вычисление котангенса невозможно.");

        double z2 = 1.0 / tanValue;
        return z2;
    }

    static void Main()
    {
        double a = Math.PI / 4; // Пример значения a (45 градусов)

        // Создаём массив из 2 задач
        Task<double>[] tasks = new Task<double>[2];

        tasks[0] = Task.Run(() =>
        {
            Console.WriteLine("Задача 1 (z1) началась");
            double result = CalculateZ1(a);
            Console.WriteLine("Задача 1 (z1) завершена");
            return result;
        });

        tasks[1] = Task.Run(() =>
        {
            Console.WriteLine("Задача 2 (z2) началась");
            double result = CalculateZ2(a);
            Console.WriteLine("Задача 2 (z2) завершена");
            return result;
        });

        // 1. Дождаться выполнения всех задач
        Console.WriteLine("Ожидание завершения всех задач...");
        Task.WaitAll(tasks);
        Console.WriteLine("Все задачи завершены.");
        Console.WriteLine($"Результаты:\n z1 = {tasks[0].Result:F6}\n z2 = {tasks[1].Result:F6}");

        // 2. Дождаться выполнения хотя бы одной задачи
        // Для демонстрации создадим две новые задачи с разной задержкой
        Task<double> taskA = Task.Run(() =>
        {
            Console.WriteLine("Задача A (z1) началась");
            Thread.Sleep(4000); // 4 секунды
            double r = CalculateZ1(a);
            Console.WriteLine("Задача A (z1) завершена");
            return r;
        });

        Task<double> taskB = Task.Run(() =>
        {
            Console.WriteLine("Задача B (z2) началась");
            Thread.Sleep(1000); // 1 секунда
            double r = CalculateZ2(a);
            Console.WriteLine("Задача B (z2) завершена");
            return r;
        });

        Task[] newTasks = { taskA, taskB };

        Console.WriteLine("Ожидание завершения хотя бы одной из задач A или B...");
        int completedIndex = Task.WaitAny(newTasks);
        Console.WriteLine($"Задача {(completedIndex == 0 ? "A (z1)" : "B (z2)")} завершилась первой.");

        double firstResult = ((Task<double>)newTasks[completedIndex]).Result;
        Console.WriteLine($"Результат первой завершившейся задачи: {firstResult:F6}");
    }
}
