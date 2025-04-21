class Program
{
    static void Main()
    {
        const int rows = 23;
        const int seatsPerRow = 40;

        int[,] hall = new int[rows, seatsPerRow];

        Random rnd = new Random();

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < seatsPerRow; j++)
            {
                hall[i, j] = rnd.NextDouble() < 0.7 ? 1 : 0;
            }
        }

        Console.WriteLine("Первый ряд (1 - продано, 0 - свободно):");
        for (int seat = 0; seat < seatsPerRow; seat++)
        {
            Console.Write(hall[0, seat] + " ");
        }
        Console.WriteLine();

        bool freeSeatFound = false;
        for (int seat = 0; seat < seatsPerRow; seat++)
        {
            if (hall[0, seat] == 0)
            {
                freeSeatFound = true;
                break;
            }
        }

        if (freeSeatFound)
            Console.WriteLine("В первом ряду есть свободные места.");
        else
            Console.WriteLine("В первом ряду нет свободных мест.");
    }
}