Console.WriteLine("Введите целое число: ");
int num = Convert.ToInt32(Console.ReadLine());
string num_st = Convert.ToString(num);
if (num % 2 != 0 && num_st.Length == 3)
{
    Console.WriteLine($"Число {num} является нечётным и трёхзначным");
}
else
{
    Console.WriteLine($"Чтсло не удовлетворяет условию");
}