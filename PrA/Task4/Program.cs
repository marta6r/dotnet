Console.WriteLine("Введите значение R1: ");
int R1 = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите значение R2: ");
int R2 = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите значение R3: ");
int R3 = Convert.ToInt32(Console.ReadLine());

double R = 1 / (1/R1 + 1/R2 + 1/R3);
Console.WriteLine(R);