using System;

/// <summary>
/// Класс, представляющий матрицу строк с возможностью конкатенации по столбцам.
/// </summary>
class StringMatrix
{
    private string[,] matrix;

    /// <summary>
    /// Количество строк в матрице.
    /// </summary>
    public int Rows { get; }

    /// <summary>
    /// Количество столбцов в матрице.
    /// </summary>
    public int Cols { get; }

    /// <summary>
    /// Конструктор по умолчанию, создаёт матрицу размером 2x2.
    /// </summary>
    public StringMatrix() : this(2, 2) {}

    /// <summary>
    /// Основной конструктор, создаёт матрицу заданного размера.
    /// Если переданы некорректные значения (меньше или равны 0), размеры по умолчанию 2x2.
    /// </summary>
    /// <param name="rows">Количество строк матрицы.</param>
    /// <param name="cols">Количество столбцов матрицы.</param>
    public StringMatrix(int rows, int cols)
    {
        Rows = rows > 0 ? rows : 2;
        Cols = cols > 0 ? cols : 2;
        matrix = new string[Rows, Cols];
    }

    /// <summary>
    /// Индексатор для доступа к элементам матрицы по индексам строки и столбца.
    /// При присваивании значения null элементу, он заменяется на пустую строку.
    /// </summary>
    /// <param name="i">Индекс строки.</param>
    /// <param name="j">Индекс столбца.</param>
    /// <returns>Элемент матрицы типа string.</returns>
    public string this[int i, int j]
    {
        get => matrix[i, j];
        set => matrix[i, j] = value ?? string.Empty;
    }

    /// <summary>
    /// Перегрузка оператора сложения, которая объединяет две матрицы по столбцам.
    /// Количество строк матриц должно совпадать, иначе выбрасывается исключение.
    /// </summary>
    /// <param name="a">Первая матрица.</param>
    /// <param name="b">Вторая матрица.</param>
    /// <returns>Новая матрица, состоящая из столбцов матриц a и b.</returns>
    /// <exception cref="ArgumentException">Выбрасывается, если количество строк матриц не совпадает.</exception>
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

    /// <summary>
    /// Выводит содержимое матрицы в консоль в табличном виде.
    /// </summary>
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

/// <summary>
/// Класс с точкой входа в программу для тестирования класса StringMatrix.
/// </summary>
class Program
{
    /// <summary>
    /// Точка входа в программу.
    /// Создаёт несколько матриц, демонстрирует работу конструкторов, индексатора,
    /// оператора сложения и метода вывода.
    /// </summary>
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
