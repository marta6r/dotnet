class A
{
    private int a = 5;  // Инициализация при объявлении
    private int b = 3;

    // Свойство с выражением
    public int c
    {
        get { return a * b + 2; } // Формула: a*b + 2
    }

    // Конструктор по умолчанию
    public A() {}
}

class B : A
{
    private int d;

    // Свойство с управляющим оператором
    public int c2
    {
        get
        {
            int result = 0;
            int counter = 0;
            
            // Do-while для демонстрации
            do
            {
                result += (int)(base.c * d * 0.5); // Формула: (c * d)/2
                counter++;
            } while(counter < 1); // Однократное выполнение
            
            return result;
        }
    }

    // Наследуемый конструктор
    public B() : base() 
    {
        d = 4; // Значение по умолчанию
    }

    // Собственный конструктор
    public B(int dValue)
    {
        d = dValue;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Класс A ===");
        A objA = new A();
        Console.WriteLine($"Свойство c: {objA.c}"); // 5*3 + 2 = 17

        Console.WriteLine("\n=== Класс B (конструктор по умолчанию) ===");
        B objB1 = new B();
        Console.WriteLine($"Свойство c2: {objB1.c2}"); // (17*4)/2 = 34

        Console.WriteLine("\n=== Класс B (пользовательский конструктор) ===");
        B objB2 = new B(10);
        Console.WriteLine($"Свойство c2: {objB2.c2}"); // (17*10)/2 = 85
    }
}