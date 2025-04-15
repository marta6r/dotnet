Console.WriteLine("Введите вещественное число A (-5 <= A <= 5): ");
double A = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Введите целое число N (1 <= N <= 10): ");
int N = Convert.ToInt32(Console.ReadLine());

double total = 1.0;
if (-5.0 <= A && A <= 5.0 && 1 <= N && N <= 10)
{
    for (int i = 1; i <= N; i++)
    {
        total += Math.Pow(A, i);
    }
}

Console.WriteLine($"Сумма = {Math.Round(total, 4)}");