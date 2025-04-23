enum Post {programer = 150, ingener = 150, doctor = 150};

class Accauntant
{
    public bool AskForBonus(Post post, int hours)
    {
        int hours_for_month = (int)post;
        if (hours > hours_for_month)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите должность: ");
        string input_post = Console.ReadLine();
        Console.WriteLine("Введите количество отработанных часов: ");
        int input_hours = Convert.ToInt32(Console.ReadLine());

        if (Enum.TryParse(typeof(Post), input_post, true, out Post post))
        {
            Accauntant accauntant = new Accauntant();
            var hasBonus= accauntant.AskForBonus(post, input_hours);
            if (hasBonus){
                Console.WriteLine("Положена премия");
            }
            else{
                Console.WriteLine("Не положена премия");
            }
        }
        else{
            Console.WriteLine("Данной должности нет");
        }

    }
}