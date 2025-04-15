Console.WriteLine("Введите значение x: ");
double x = Convert.ToDouble(Console.ReadLine());

for (int i = 10; i <= 200; i += 10)
{
    Console.WriteLine($"Стоимость за {i} товара: {i * x}");
}

int count = 10;
while (count <= 200)
{
    Console.WriteLine($"Стоимость за {count} товара: {count * x}");
    count += 10;
}

int count2 = 0;
do
{
    count2 += 10;
    Console.WriteLine($"Стоимость за {count2} товара: {count2 * x}");
}
    while (count2 < 200);