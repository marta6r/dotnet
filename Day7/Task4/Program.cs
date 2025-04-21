class Program
{
    static int GetLetterValue(char c)
    {       
        return char.ToLower(c) - 'а' + 1; 
    }

    static int CalculateDigitSum(int number)
    {
        while (number > 9)
        {
            int sum = 0;
            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }
            number = sum;
        }
        return number;
    }

    static void Main()
    {
        Console.WriteLine("Введите фамилию, имя и отчество через пробел:");
        string[] parts = Console.ReadLine().Split(' ');

        if (parts.Length < 3)
        {
            Console.WriteLine("Ошибка: требуется ввести фамилию, имя и отчество!");
            return;
        }

        string fullName = string.Concat(parts[0], parts[1], parts[2]).ToLower();
        int totalSum = 0;

        foreach (char c in fullName)
        {
            if (c >= 'а' && c <= 'я')
            {
                totalSum += GetLetterValue(c);
            }
        }

        int code = CalculateDigitSum(totalSum);
        Console.WriteLine($"Код личности: {code}");
    }
}