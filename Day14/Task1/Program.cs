using System.Threading;

class Program
{
    private static readonly object lockObject = new object();
    private static int currentThreadId = 1; // 1 - первый, 2 - второй, 3 - третий

    static void Main()
    {
        Thread thread1 = new Thread(PrintNumbers1);
        Thread thread2 = new Thread(PrintNumbers2);
        Thread thread3 = new Thread(PrintNumbers3);

        // Можно изменить приоритеты (пример)
        thread1.Priority = ThreadPriority.Normal;
        thread2.Priority = ThreadPriority.Normal;
        thread3.Priority = ThreadPriority.Normal;

        // Запускаем потоки
        thread1.Start();
        thread2.Start();
        thread3.Start();

        thread1.Join();
        thread2.Join();
        thread3.Join();
    }

    static void PrintNumbers(int start, int end, int threadId)
    {
        for (int i = start; i <= end; i++)
        {
            lock (lockObject)
            {
                while (currentThreadId != threadId)
                {
                    Monitor.Wait(lockObject);
                }

                Console.WriteLine($"Поток {threadId}: {i}");
                currentThreadId = (currentThreadId % 3) + 1;
                Monitor.PulseAll(lockObject);
                Thread.Sleep(50); // Задержка для наглядности
            }
        }
    }

    static void PrintNumbers1()
    {
        PrintNumbers(0, 9, 1);
    }

    static void PrintNumbers2()
    {
        PrintNumbers(10, 19, 2);
    }

    static void PrintNumbers3()
    {
        PrintNumbers(20, 29, 3);
    }
}