using System.Diagnostics;
using System.Threading;

class Program
{
    static void Main()
    {
        // Создаем два потока
        Thread thread1 = new Thread(SumNumbers);
        Thread thread2 = new Thread(SumNumbers);

        // Запускаем потоки
        thread1.Start();
        thread2.Start();

        // Ожидаем завершения потоков
        thread1.Join();
        thread2.Join();
    }

    static void SumNumbers()
    {
        // Засекаем время начала выполнения
        Stopwatch stopwatch = Stopwatch.StartNew();

        int sum = 0;
        for (int i = 1; i <= 10; i++)
        {
            sum += i;
        }

        // Останавливаем таймер
        stopwatch.Stop();

        // Выводим результат и время выполнения
        Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId}: сумма = {sum}, время = {stopwatch.ElapsedMilliseconds} мс");
    }
}