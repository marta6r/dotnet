class A{
    public int a;
    public int b;

    public A(int a, int b)
    {
        this.a = a;
        this.b = b;
    }

    public int Average(int a, int b)
    {
        return (a + b) / 2;
    }

    public double SumExpresion(int a, int b)
    {
        return Math.Pow(b, 3)+Math.Sqrt(a);
        ;
    }
}

class Program{
    static void Main()
    {
        A a = new A(4, 6);

        Console.WriteLine($"Среднее арифметическое a и b = {a.Average(4, 6)}");
        Console.WriteLine($"b^3+sqrt(a) = {a.SumExpresion(4, 6)}");
    }
}