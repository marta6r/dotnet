struct WORKER
{
    public string name;
    public string post;
    public int year;

    public override string ToString()
    {
        return $"Name: {name}, Post: {post}, Year: {year}";
    }

    public int Experience()
    {
        return 2025 - year;
    }
}

class Program
{
    static void Main()
    {

    WORKER[] workers = new WORKER[10];
    for (int i = 0; i < workers.Length; i++)
    {    
            Console.WriteLine("Введите фамилию и инициалы: ");
            workers[i].name = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Введите должность: ");
            workers[i].post = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Введите год поступления на работу: ");
            workers[i].year = Convert.ToInt32(Console.ReadLine());
    }

    Array.Sort(workers, (x, y) => string.Compare(x.name, y.name));

    foreach (WORKER worker in workers)
    {
        Console.WriteLine(worker);
    }

    Console.WriteLine("Введите стаж: ");
    int input_experience = Convert.ToInt32(Console.ReadLine());

    foreach (WORKER worker in workers)
    {
        if (worker.Experience() >= input_experience)
        {
            Console.WriteLine(worker.name);
        }
    }
    }
}
