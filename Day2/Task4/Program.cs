Console.WriteLine("Введите значение x: ");
double x = Convert.ToDouble(Console.ReadLine());
if (x > 1)
{
    var y = Math.Log10(2*x) + Math.Sqrt(1+Math.Pow(x,2));
    Console.WriteLine($"y = {y}");
}
else if (x <= 1)
{
    var y = 2*Math.Cos(x) + 3*Math.Pow(x,2); 
    Console.WriteLine($"y = {y}");
}
else
{
    Console.WriteLine("Введено некорректное значение x");
}