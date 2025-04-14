Console.WriteLine("Введите трёхзначное число: ");
int number = Convert.ToInt32(Console.ReadLine());

int last_num = number % 10;
int first_second_num = number / 10;

string last_num_str = Convert.ToString(last_num);
string first_second_num_str = Convert.ToString(first_second_num);

string rez_str = last_num_str + first_second_num_str;
int rez = Convert.ToInt32(rez_str);
Console.WriteLine(rez);
