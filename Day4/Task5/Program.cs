using System;

public class RealMatrix
{
    private double[,] data;
    public int Rows { get; }
    public int Cols { get; }

    // Конструкторы
    public RealMatrix(int rows, int cols)
    {
        if (rows <= 0 || cols <= 0)
            throw new ArgumentException("Размеры матрицы должны быть положительными");
        
        Rows = rows;
        Cols = cols;
        data = new double[Rows, Cols];
    }

    public RealMatrix(int size) : this(size, size) { }
    
    public RealMatrix(double[,] initialData)
    {
        if (initialData == null)
            throw new ArgumentNullException(nameof(initialData));
            
        Rows = initialData.GetLength(0);
        Cols = initialData.GetLength(1);
        data = (double[,])initialData.Clone();
    }

    // Индексатор
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

    private void CheckIndices(int row, int col)
    {
        if (row < 0 || row >= Rows || col < 0 || col >= Cols)
            throw new IndexOutOfRangeException("Неверные индексы матрицы");
    }

    // Операции с матрицами
    public static RealMatrix operator +(RealMatrix a, RealMatrix b)
    {
        CheckSameDimensions(a, b);
        RealMatrix result = new RealMatrix(a.Rows, a.Cols);
        
        for (int i = 0; i < a.Rows; i++)
            for (int j = 0; j < a.Cols; j++)
                result[i, j] = a[i, j] + b[i, j];
                
        return result;
    }

    public static RealMatrix operator -(RealMatrix a, RealMatrix b)
    {
        CheckSameDimensions(a, b);
        RealMatrix result = new RealMatrix(a.Rows, a.Cols);
        
        for (int i = 0; i < a.Rows; i++)
            for (int j = 0; j < a.Cols; j++)
                result[i, j] = a[i, j] - b[i, j];
                
        return result;
    }

    // Операции с числом
    public static RealMatrix operator +(RealMatrix m, double num)
    {
        RealMatrix result = new RealMatrix(m.Rows, m.Cols);
        
        for (int i = 0; i < m.Rows; i++)
            for (int j = 0; j < m.Cols; j++)
                result[i, j] = m[i, j] + num;
                
        return result;
    }

    public static RealMatrix operator -(RealMatrix m, double num)
    {
        return m + (-num);
    }

    // Комбинированные операции
    public static RealMatrix operator +(RealMatrix a, RealMatrix b)
    {
        return a + b; // Этот метод уже реализован выше
    }

    public static RealMatrix operator -(RealMatrix a, RealMatrix b)
    {
        return a - b; // Этот метод уже реализован выше
    }

    // Операции сравнения
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

    public static bool operator !=(RealMatrix a, RealMatrix b) => !(a == b);

    // Вспомогательные методы
    private static void CheckSameDimensions(RealMatrix a, RealMatrix b)
    {
        if (a.Rows != b.Rows || a.Cols != b.Cols)
            throw new ArgumentException("Матрицы должны иметь одинаковые размеры");
    }

    public override bool Equals(object obj) => obj is RealMatrix m && this == m;
    public override int GetHashCode() => data.GetHashCode();

    // Метод вывода матрицы
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

class Program
{
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

        

