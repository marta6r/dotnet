class Program
{
    // Делегат для методов, возвращающих случайное int
    delegate int RandomIntDelegate();

    static void Main()
    {
        // Создаем массив делегатов
        RandomIntDelegate[] delegates = new RandomIntDelegate[5];
        Random rnd = new Random();

        // Инициализируем делегаты лямбдами
        for (int i = 0; i < delegates.Length; i++)
        {
            delegates[i] = () => rnd.Next(1, 101); // Генерация от 1 до 100
        }

        // Анонимный метод для расчета среднего
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