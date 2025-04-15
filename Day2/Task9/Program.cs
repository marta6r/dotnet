Console.WriteLine("Введите значение х: ");
double x = Convert.ToDouble(Console.ReadLine());

double H = ((Math.PI / 2) - (Math.PI / 4))/ 15;

for (double i = Math.PI/4; i <= Math.PI/2; i += 0.1)
{
    var y = 1 / Math.Tan(x);
    Console.WriteLine(y);
    x += H;
}
