using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        List<int> values = new List<int> { 11, 12, 15, 68 };
        long sumThreshold = 535;
        long productThreshold = 535;

        long totalSum = 0;
        long totalProduct = 1; // Начинаем с 1 для произведения

        object lockObject = new object(); // Объект для синхронизации доступа к общим переменным
        bool shouldStop = false; // Флаг для остановки цикла

        ParallelOptions parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount };

        Parallel.ForEach(values, parallelOptions, (value, loopState) =>
        {
            if (shouldStop)
            {
                loopState.Stop();
                return;
            }

            long localSum = 0;
            long localProduct = 1;

            for (int i = 1; i <= value; i++)
            {
                localSum += i;
                localProduct *= i;
            }

            lock (lockObject)
            {
                // Обновляем общие значения суммы и произведения под блокировкой
                if (!shouldStop)
                {
                    totalSum += localSum;
                    totalProduct *= localProduct;

                    // Проверяем условие остановки
                    if (totalSum > sumThreshold || totalProduct > productThreshold)
                    {
                        Console.WriteLine($"Условие остановки достигнуто. Сумма: {totalSum}, Произведение: {totalProduct}");
                        shouldStop = true;
                        loopState.Stop();
                    }
                    else
                    {
                        Console.WriteLine($"Вычислено для значения: {value}, Сумма: {totalSum}, Произведение: {totalProduct}");
                    }
                }
            }
        });

        Console.WriteLine($"\nИтоговая сумма: {totalSum}");
        Console.WriteLine($"Итоговое произведение: {totalProduct}");
    }
}
