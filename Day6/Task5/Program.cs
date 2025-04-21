class Program
{
    static long Factorial(int x)
    {
        if (x <= 1)
            return 1;
        else
            return x * Factorial(x - 1);
    }

    static void Main()
    {
        Console.Write("Введите натуральное число n (n >= 2): ");
        int n = int.Parse(Console.ReadLine());

        if (n < 2)
        {
            Console.WriteLine("Число n должно быть не меньше 2.");
            return;
        }

        long factorial_n_minus_1 = Factorial(n - 1);
        long factorial_n_minus_2 = Factorial(n - 2);

        double f = (double)factorial_n_minus_1 / factorial_n_minus_2;

        Console.WriteLine($"f({n}) = (n-1)! / (n-2)! = {factorial_n_minus_1} / {factorial_n_minus_2} = {f}");
    }
}