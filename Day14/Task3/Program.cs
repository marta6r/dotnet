using System.Threading;

class Program
{
    static int A, N;
    static readonly object lockObject = new object();

    static void Main()
    {
        Console.Write("Введите A: ");
        A = int.Parse(Console.ReadLine());
        Console.Write("Введите N: ");
        N = int.Parse(Console.ReadLine());

        // Создаем два потока для метода Sum (они выполняются одновременно)
        Thread sumThread1 = new Thread(Sum);
        Thread sumThread2 = new Thread(Sum);
        sumThread1.Start();
        sumThread2.Start();

        // Создаем два потока для метода Mul (но выполняется только один поток одновременно)
        Thread mulThread1 = new Thread(Mul);
        Thread mulThread2 = new Thread(Mul);
        mulThread1.Start();
        mulThread2.Start();

        sumThread1.Join();
        sumThread2.Join();
        mulThread1.Join();
        mulThread2.Join();
    }

    // Метод для суммы (выполняется двумя потоками одновременно)
    static void Sum()
    {
        long sum = 0;
        for (int i = 0; i <= N; i++)
        {
            sum += (long)A * i; // A + A*1 + A*2 + ... + A*N
        }
        Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId}: сумма = {sum}");
    }

    // Метод для произведения (выполняется только одним потоком одновременно)
    static void Mul()
    {
        lock (lockObject)
        {
            long mul = 1;
            for (int i = 0; i <= N; i++)
            {
                mul *= (long)A * i == 0 ? 1 : (long)A * i; // A * A*1 * A*2 * ... * A*N (но если A*i=0, заменяем на 1)
            }
            Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId}: произведение = {mul}");
        }
    }
}