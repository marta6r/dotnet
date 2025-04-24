interface Ix
{
    void IxF0(string w);
    void IxF1();
}

interface Iy
{
    void F0(string w);
    void F1();
}

interface Iz
{
    void F0(string w);
    void F1();
}

class TestClass : Ix, Iy, Iz
{
    public string w;

    // Ix методы
    public void IxF0(string w)
    {
        this.w = w;
        if (w.Length > 2) 
            this.w = w.Substring(0, w.Length - 2);
        Console.WriteLine($"Ix.F0: {this.w}");
    }

    public void IxF1()
    {
        if (w.Length > 2) 
            w = w.Substring(0, w.Length - 2);
        Console.WriteLine($"Ix.F1: {w}");
    }

    // Общая неявная реализация Iy и Iz
    public void F0(string w)
    {
        this.w = w;
        if (w.Length > 2) 
            this.w = w.Substring(2);
        Console.WriteLine($"Iy/Iz.F0 (неявно): {this.w}");
    }

    public void F1()
    {
        if (w.Length > 2) 
            w = w.Substring(2);
        Console.WriteLine($"Iy/Iz.F1 (неявно): {w}");
    }

    // Явная реализация Iz
    void Iz.F0(string w)
    {
        this.w = w;
        if (w.Length > 0)
            this.w = "-" + (w.Length > 1 ? w.Substring(1) : "");
        Console.WriteLine($"Iz.F0 (явно): {this.w}");
    }

    void Iz.F1()
    {
        if (w.Length > 0)
            w = "-" + (w.Length > 1 ? w.Substring(1) : "");
        Console.WriteLine($"Iz.F1 (явно): {w}");
    }
}

class Program
{
    static void Main()
    {
        TestClass obj = new TestClass();
        obj.w = "ПримерСтроки";

        // Вызов методов Ix
        obj.IxF0(obj.w);
        obj.IxF1();

        // Вызов методов Iy (неявно)
        Iy iyRef = obj;
        iyRef.F0(obj.w);
        iyRef.F1();

        // Вызов методов Iz через приведение (явно)
        ((Iz)obj).F0(obj.w);
        ((Iz)obj).F1();

        // Вызов через интерфейсную ссылку
        Iz izRef = obj;
        izRef.F0(obj.w);
        izRef.F1();
    }
}