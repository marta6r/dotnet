class Program
{
    static void DigitCountSum(int K, out int C, out int S)
    {
        C = 0;
        S = 0;
        
        while (K > 0)
        {
            int digit = K % 10;
            S += digit;
            C++;
            K /= 10;
        }
    }

    static void Main()
    {
        Console.WriteLine("Введите 5 целых положительных чисел:");
        
        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Число {i+1}: ");
            int number = int.Parse(Console.ReadLine());
            
            DigitCountSum(number, out int count, out int sum);
            
            Console.WriteLine($"Количество цифр: {count}, Сумма цифр: {sum}");
            Console.WriteLine(new string('-', 30));
        }
    }
}