using System;

/// <summary>
/// Класс с точкой входа в программу, демонстрирующий работу с делегатами и анонимными методами.
/// </summary>
class Program
{
    /// <summary>
    /// Делегат для методов, возвращающих случайное целое число типа int.
    /// </summary>
    /// <returns>Случайное целое число.</returns>
    delegate int RandomIntDelegate();

    /// <summary>
    /// Точка входа в программу.
    /// Создаёт массив делегатов, каждый из которых генерирует случайное число от 1 до 100,
    /// затем вычисляет и выводит среднее арифметическое этих чисел.
    /// </summary>
    static void Main()
    {
        // Создаем массив делегатов
        RandomIntDelegate[] delegates = new RandomIntDelegate[5];
        Random rnd = new Random();

        // Инициализируем делегаты лямбда-выражениями, генерирующими случайные числа от 1 до 100
        for (int i = 0; i < delegates.Length; i++)
        {
            delegates[i] = () => rnd.Next(1, 101);
        }

        /// <summary>
        /// Анонимный метод для расчёта среднего арифметического значений, возвращаемых массивом делегатов.
        /// </summary>
        /// <param name="delArray">Массив делегатов, возвращающих случайные числа.</param>
        /// <returns>Среднее арифметическое значений.</returns>
        Func<RandomIntDelegate[], double> averageCalculator = delegate(RandomIntDelegate[] delArray)
        {
            int sum = 0;
            foreach (var del in delArray)
            {
                sum += del();
            }
            return (double)sum / delArray.Length;
        };

        // Расчет и вывод результата
        double average = averageCalculator(delegates);
        Console.WriteLine($"Среднее арифметическое: {average:F2}");
    }
}
