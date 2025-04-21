class Program
{
    static void Main()
    {
        int[] array = { 5, 3, 8, 1, 4, 1 };

        int minValue = array[0];
        int minIndex = 0;

        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < minValue)
            {
                minValue = array[i];
                minIndex = i;
            }
        }

        Console.WriteLine($"Минимальный элемент: {minValue}");
        Console.WriteLine($"Порядковый номер минимального элемента: {minIndex + 1}");
    }
}