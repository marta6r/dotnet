Console.WriteLine("Введите значение аргумента x: ");
double x = Convert.ToDouble(Console.ReadLine());
double p = 3.14;
double e = 2.72;
double y = x * Math.Pow(e, Math.Pow(x, 2)) - (Math.Sin(Math.Sqrt(x)) + Math.Pow(Math.Cos(Math.Log10(x)), 2)) / Math.Sqrt(Math.Abs(1 - p*x));
Console.WriteLine(y);