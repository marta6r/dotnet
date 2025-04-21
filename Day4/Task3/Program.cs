class StringMatrix
{
    private string[,] matrix;
    public int Rows { get; }
    public int Cols { get; }

    // Конструктор по умолчанию (2x2)
    public StringMatrix() : this(2, 2) {}

    // Основной конструктор
    public StringMatrix(int rows, int cols)
    {
        Rows = rows > 0 ? rows : 2;
        Cols = cols > 0 ? cols : 2;
        matrix = new string[Rows, Cols];
    }

    // Индексатор для доступа к элементам
    public string this[int i, int j]
    {
        get => matrix[i, j];
        set => matrix[i, j] = value ?? string.Empty;
    }

    // Перегрузка оператора +
    public static StringMatrix operator +(StringMatrix a, StringMatrix b)
    {
        if (a.Rows != b.Rows)
            throw new ArgumentException("Матрицы должны иметь одинаковое количество строк");

        var result = new StringMatrix(a.Rows, a.Cols + b.Cols);
        
        for (int i = 0; i < a.Rows; i++)
        {
            for (int j = 0; j < a.Cols; j++)
                result[i, j] = a[i, j];
            
            for (int j = 0; j < b.Cols; j++)
                result[i, a.Cols + j] = b[i, j];
        }
        
        return result;
    }

    // Метод вывода матрицы
    public void Print()
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
                Console.Write($"{matrix[i, j],-15}");
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main()
    {
        // Тест конструкторов
        var m1 = new StringMatrix(2, 3);
        m1[0, 0] = "Hello"; m1[0, 1] = "World"; m1[0, 2] = "!";
        m1[1, 0] = "C#";    m1[1, 1] = "Matrix"; m1[1, 2] = "Test";

        var m2 = new StringMatrix(2, 2);
        m2[0, 0] = "Привет"; m2[0, 1] = "Мир";
        m2[1, 0] = "OpenAI"; m2[1, 1] = "GPT";

        Console.WriteLine("Матрица 1:");
        m1.Print();
        Console.WriteLine("\nМатрица 2:");
        m2.Print();

        // Тест операции сложения
        try
        {
            var result = m1 + m2;
            Console.WriteLine("\nРезультат сложения:");
            result.Print();
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"Ошибка: {e.Message}");
        }

        // Тест с разным количеством строк
        var m3 = new StringMatrix(3, 2);
        Console.WriteLine("\nПопытка сложения с матрицей 3x2:");
        try
        {
            var invalid = m1 + m3;
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"Ожидаемая ошибка: {e.Message}");
        }
    }
}