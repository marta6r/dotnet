using System;

/// <summary>
/// Класс, представляющий матрицу с элементами типа double и поддерживающий базовые операции.
/// </summary>
public class RealMatrix
{
    private double[,] data;

    /// <summary>
    /// Количество строк матрицы.
    /// </summary>
    public int Rows { get; }

    /// <summary>
    /// Количество столбцов матрицы.
    /// </summary>
    public int Cols { get; }

    /// <summary>
    /// Конструктор, создающий матрицу заданного размера.
    /// </summary>
    /// <param name="rows">Количество строк матрицы (должно быть положительным).</param>
    /// <param name="cols">Количество столбцов матрицы (должно быть положительным).</param>
    /// <exception cref="ArgumentException">Выбрасывается, если размеры матрицы не положительные.</exception>
    public RealMatrix(int rows, int cols)
    {
        if (rows <= 0 || cols <= 0)
            throw new ArgumentException("Размеры матрицы должны быть положительными");
        
        Rows = rows;
        Cols = cols;
        data = new double[Rows, Cols];
    }

    /// <summary>
    /// Конструктор, создающий квадратную матрицу заданного размера.
    /// </summary>
    /// <param name="size">Размер квадратной матрицы (число строк и столбцов).</param>
    public RealMatrix(int size) : this(size, size) { }
    
    /// <summary>
    /// Конструктор, создающий матрицу на основе двумерного массива.
    /// </summary>
    /// <param name="initialData">Двумерный массив с начальными значениями матрицы.</param>
    /// <exception cref="ArgumentNullException">Выбрасывается, если initialData равен null.</exception>
    public RealMatrix(double[,] initialData)
    {
        if (initialData == null)
            throw new ArgumentNullException(nameof(initialData));
            
        Rows = initialData.GetLength(0);
        Cols = initialData.GetLength(1);
        data = (double[,])initialData.Clone();
    }

    /// <summary>
    /// Индексатор для доступа к элементам матрицы по индексам строки и столбца.
    /// </summary>
    /// <param name="row">Индекс строки (от 0 до Rows-1).</param>
    /// <param name="col">Индекс столбца (от 0 до Cols-1).</param>
    /// <returns>Значение элемента матрицы.</returns>
    /// <exception cref="IndexOutOfRangeException">Выбрасывается при выходе индексов за границы матрицы.</exception>
    public double this[int row, int col]
    {
        get
        {
            CheckIndices(row, col);
            return data[row, col];
        }
        set
        {
            CheckIndices(row, col);
            data[row, col] = value;
        }
    }

    /// <summary>
    /// Проверяет корректность индексов строки и столбца.
    /// </summary>
    /// <param name="row">Индекс строки.</param>
    /// <param name="col">Индекс столбца.</param>
    /// <exception cref="IndexOutOfRangeException">Выбрасывается, если индексы выходят за границы матрицы.</exception>
    private void CheckIndices(int row, int col)
    {
        if (row < 0 || row >= Rows || col < 0 || col >= Cols)
            throw new IndexOutOfRangeException("Неверные индексы матрицы");
    }

    /// <summary>
    /// Оператор сложения двух матриц одинакового размера.
    /// </summary>
    /// <param name="a">Первая матрица.</param>
    /// <param name="b">Вторая матрица.</param>
    /// <returns>Новая матрица, являющаяся суммой матриц a и b.</returns>
    /// <exception cref="ArgumentException">Выбрасывается, если размеры матриц не совпадают.</exception>
    public static RealMatrix operator +(RealMatrix a, RealMatrix b)
    {
        CheckSameDimensions(a, b);
        RealMatrix result = new RealMatrix(a.Rows, a.Cols);
        
        for (int i = 0; i < a.Rows; i++)
            for (int j = 0; j < a.Cols; j++)
                result[i, j] = a[i, j] + b[i, j];
                
        return result;
    }

    /// <summary>
    /// Оператор вычитания двух матриц одинакового размера.
    /// </summary>
    /// <param name="a">Первая матрица.</param>
    /// <param name="b">Вторая матрица.</param>
    /// <returns>Новая матрица, являющаяся разностью матриц a и b.</returns>
    /// <exception cref="ArgumentException">Выбрасывается, если размеры матриц не совпадают.</exception>
    public static RealMatrix operator -(RealMatrix a, RealMatrix b)
    {
        CheckSameDimensions(a, b);
        RealMatrix result = new RealMatrix(a.Rows, a.Cols);
        
        for (int i = 0; i < a.Rows; i++)
            for (int j = 0; j < a.Cols; j++)
                result[i, j] = a[i, j] - b[i, j];
                
        return result;
    }

    /// <summary>
    /// Оператор сложения матрицы с числом (прибавляет число ко всем элементам матрицы).
    /// </summary>
    /// <param name="m">Матрица.</param>
    /// <param name="num">Число для сложения.</param>
    /// <returns>Новая матрица с обновлёнными элементами.</returns>
    public static RealMatrix operator +(RealMatrix m, double num)
    {
        RealMatrix result = new RealMatrix(m.Rows, m.Cols);
        
        for (int i = 0; i < m.Rows; i++)
            for (int j = 0; j < m.Cols; j++)
                result[i, j] = m[i, j] + num;
                
        return result;
    }

    /// <summary>
    /// Оператор вычитания числа из матрицы (вычитает число из каждого элемента матрицы).
    /// </summary>
    /// <param name="m">Матрица.</param>
    /// <param name="num">Число для вычитания.</param>
    /// <returns>Новая матрица с обновлёнными элементами.</returns>
    public static RealMatrix operator -(RealMatrix m, double num)
    {
        return m + (-num);
    }

    /// <summary>
    /// Оператор сравнения матриц на равенство.
    /// </summary>
    /// <param name="a">Первая матрица.</param>
    /// <param name="b">Вторая матрица.</param>
    /// <returns>true, если матрицы имеют одинаковые размеры и все элементы равны с точностью до 1e-10; иначе false.</returns>
    public static bool operator ==(RealMatrix a, RealMatrix b)
    {
        if (ReferenceEquals(a, b)) return true;
        if (a is null || b is null) return false;
        if (a.Rows != b.Rows || a.Cols != b.Cols) return false;
        
        for (int i = 0; i < a.Rows; i++)
            for (int j = 0; j < a.Cols; j++)
                if (Math.Abs(a[i, j] - b[i, j]) > 1e-10)
                    return false;
                    
        return true;
    }

    /// <summary>
    /// Оператор сравнения матриц на неравенство.
    /// </summary>
    /// <param name="a">Первая матрица.</param>
    /// <param name="b">Вторая матрица.</param>
    /// <returns>true, если матрицы не равны; иначе false.</returns>
    public static bool operator !=(RealMatrix a, RealMatrix b) => !(a == b);

    /// <summary>
    /// Проверяет, что две матрицы имеют одинаковые размеры.
    /// </summary>
    /// <param name="a">Первая матрица.</param>
    /// <param name="b">Вторая матрица.</param>
    /// <exception cref="ArgumentException">Выбрасывается, если размеры матриц не совпадают.</exception>
    private static void CheckSameDimensions(RealMatrix a, RealMatrix b)
    {
        if (a.Rows != b.Rows || a.Cols != b.Cols)
            throw new ArgumentException("Матрицы должны иметь одинаковые размеры");
    }

    /// <inheritdoc/>
    public override bool Equals(object obj) => obj is RealMatrix m && this == m;

    /// <inheritdoc/>
    public override int GetHashCode() => data.GetHashCode();

    /// <summary>
    /// Выводит матрицу в консоль в табличном формате с двумя знаками после запятой.
    /// </summary>
    public void Print()
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
                Console.Write($"{this[i, j],10:F2}");
            Console.WriteLine();
        }
    }
}

/// <summary>
/// Класс с точкой входа в программу для демонстрации возможностей класса RealMatrix.
/// </summary>
class Program
{
    /// <summary>
    /// Точка входа в программу.
    /// Демонстрирует создание матриц, операции над ними, сравнение и обработку ошибок.
    /// </summary>
    static void Main()
    {
        Console.WriteLine("Демонстрация класса RealMatrix\n");

        // Тест конструкторов
        Console.WriteLine("1. Создание матриц:");
        RealMatrix m1 = new RealMatrix(new double[,] { { 1.1, 2.2 }, { 3.3, 4.4 } });
        RealMatrix m2 = new RealMatrix(2, 2);
        m2[0, 0] = 0.5; m2[0, 1] = 1.5;
        m2[1, 0] = 2.5; m2[1, 1] = 3.5;

        Console.WriteLine("Матрица 1:");
        m1.Print();
        Console.WriteLine("\nМатрица 2:");
        m2.Print();

        // Тест операций
        Console.WriteLine("\n2. Тест операций:");
        Console.WriteLine("Сложение матриц:");
        (m1 + m2).Print();

        Console.WriteLine("\nВычитание матриц:");
        (m1 - m2).Print();

        Console.WriteLine("\nСложение с числом:");
        (m1 + 1.5).Print();

        Console.WriteLine("\nВычитание числа:");
        (m1 - 0.5).Print();

        // Тест комбинированных операций
        Console.WriteLine("\n3. Комбинированные операции:");
        Console.WriteLine("До += :");
        m1.Print();
        m1 += m2;
        Console.WriteLine("\nПосле += :");
        m1.Print();

        // Тест сравнения
        Console.WriteLine("\n4. Сравнение матриц:");
        RealMatrix m3 = new RealMatrix(new double[,] { { 1.1, 2.2 }, { 3.3, 4.4 } });
        Console.WriteLine($"m1 == m3: {m1 == m3}");
        Console.WriteLine($"m2 != m3: {m2 != m3}");

        // Тест индексатора
        Console.WriteLine("\n5. Тест индексатора:");
        Console.WriteLine($"m3[1,1] = {m3[1, 1]:F2}");
        m3[1, 1] = 9.9;
        Console.WriteLine("После изменения:");
        m3.Print();

        // Тест обработки ошибок
        Console.WriteLine("\n6. Тест обработки ошибок:");
        try
        {
            RealMatrix invalid = new RealMatrix(0, 5);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка: {e.Message}");
        }

        try
        {
            Console.WriteLine(m1 + new RealMatrix(3, 3));
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка: {e.Message}");
        }
    }
}
